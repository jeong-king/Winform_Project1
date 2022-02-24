using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MazePlus
{
    public partial class MazePlus : Form
    {
        enum MazeType
        {
            Pathway = 0,
            Wall = 1
        }

        Random random = new Random();
        Stopwatch stopwatch = new Stopwatch();
        Point[] pointWall = new Point[MazeSize * MazeSize];
        Point[] pointResult = new Point[MazeSize * MazeSize];
        Queue<Tuple<int, int, int, string>> queueBFS = new Queue<Tuple<int, int, int, string>>();
        Queue<Tuple<int, int, string>> queueReplay = new Queue<Tuple<int, int, string>>();
        Queue<Tuple<int, int, string>> queueJsonReplay = new Queue<Tuple<int, int, string>>();

        public SolidBrush Brush = new SolidBrush(Color.Gray);
        public Pen PenSolution = new Pen(Color.Red, 10);
        public Pen PenSolution2 = new Pen(Color.WhiteSmoke, 10);
        public Pen PenGrid = new Pen(Color.WhiteSmoke, 1);

        public int[,] Maze = new int[MazeSize, MazeSize];
        public const int MazeSize = 19;
        public int Space = 40;
        public int WallCount = 0;
        public int MoveCount = 0;
        public static int ResultCount;
        public static string Result = "";
        public string MoveTime;
        public int LocationX, LocationY, CurrentX, CurrentY, ExitX, ExitY;
    }
}
