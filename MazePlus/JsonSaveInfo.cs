using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazePlus
{
    [Serializable]
    public class MyData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Time { get; set; }
    }

    [Serializable]
    public class JsonSaveInfo
    {
        public int MapSize { get; set; }
        public int UserMoveCount { get; set; }
        public int BestMoveCount { get; set; }
        public Point ExitLocation { get; set; }
        public List<MyData> ReplayInfo { get; set; }
        public int[,] Map { get; set; }
    }
}
