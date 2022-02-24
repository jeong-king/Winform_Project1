using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace MazePlus
{
    public partial class MazePlus : Form
    {
        private void SaveJson(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장경로를 지정하세요.";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "json";
            string fileName = "";

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName; 

                Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter serializer = new BinaryFormatter();

                var jsonObject = new JsonSaveInfo
                {
                    MapSize = MazeSize,
                    UserMoveCount = MoveCount,
                    BestMoveCount = ResultCount,
                    ExitLocation = move_Exit.Location,
                    ReplayInfo = new List<MyData>(),
                    Map = Maze
                };

                while (queueJsonReplay.Count > 0)
                {
                    var queueJsonReplayVal = queueJsonReplay.Dequeue();

                    MyData data = new MyData();
                    data.X = queueJsonReplayVal.Item1;
                    data.Y = queueJsonReplayVal.Item2;
                    data.Time = queueJsonReplayVal.Item3;

                    jsonObject.ReplayInfo.Add(data);

                    serializer.Serialize(stream, data);
                }
                stream.Close();

                var json = JObject.FromObject(jsonObject);

                File.WriteAllText(fileName, json.ToString());
            }
        }

        private void OpenJson(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Json File 불러오기";
            openFileDialog.FileName = "";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<Tuple<int, int, string>> openJsonList = new List<Tuple<int, int, string>>();

                StreamReader streamReader = new StreamReader(openFileDialog.FileName, Encoding.Default);

                var openJson = File.ReadAllText(openFileDialog.FileName);
                JsonSaveInfo openInfo = JsonConvert.DeserializeObject<JsonSaveInfo>(openJson);
                
                JsonOpenInfo jsonOpenInfo = new JsonOpenInfo();
                jsonOpenInfo.SetJsonValues(openInfo.UserMoveCount, openInfo.BestMoveCount, openInfo.MapSize, openInfo.ExitLocation, openInfo.Map);
                jsonOpenInfo.SetAddList(openInfo.ReplayInfo.Count, openInfo.ReplayInfo, openJsonList);
                jsonOpenInfo.SetInit(this);
                SetJsonRefresh();
                jsonOpenInfo.SetJsonLocation(move_CatReplay, openJsonList);
                streamReader.Close();
            }
            MessageBox.Show("게임을 새로 시작합니다.");
            Application.Restart();
        }
    }
}
