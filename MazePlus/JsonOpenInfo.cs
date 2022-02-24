using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MazePlus
{
    class JsonOpenInfo
    {
        public int JsonMoveCount { get; set; }
        public int JsonBestCount { get; set; }
        public int JsonMazeSize { get; set; }

        public Point JsonExitLocation { get; set; }

        public int[,] JsonMaze { get; set; }
        
        public void SetJsonValues(int mc, int bc, int ms, Point jp, int[,] jm )
        {
            this.JsonMoveCount = mc;
            this.JsonBestCount = bc;
            this.JsonMazeSize = ms;
            this.JsonExitLocation = jp;
            this.JsonMaze = jm;
        }
        
        public void SetAddList(int addCount, List<MyData> myData, List<Tuple<int, int, string>> catLocationList)
        {
            for (int i = 0; i < addCount; i++)
            {
                catLocationList.Add(new Tuple<int, int, string>(myData[i].X, myData[i].Y, myData[i].Time));
            }
        }

        public void SetInit(MazePlus mazePlus)
        {
            mazePlus.Maze = JsonMaze;
            mazePlus.move_Exit.Location = JsonExitLocation;
            mazePlus.lb_BestCount.Text = JsonBestCount.ToString();
        }

        public void SetJsonLocation(Label catRelay, List<Tuple<int, int, string>> catLocationList)
        {
            for (int i = 0; i < catLocationList.Count; i++)
            {
                MazePlus.Delay(Convert.ToInt32(catLocationList[i].Item3));
                catRelay.Location = new Point(catLocationList[i].Item1, catLocationList[i].Item2);
            }
        }
    }
}
