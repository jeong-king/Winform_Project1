using System;
using System.Windows.Forms;

namespace MazePlus
{
    public partial class MazePlus : Form
    {
        private void FindBFS(int[,] myMaze, int mazeSizeX, int mazeSizeY, int startX, int startY, int exitX, int exitY)
        {
            int shortDist = Int32.MaxValue;
            string path = "";

            queueBFS.Enqueue(new Tuple<int, int, int, string>(startX, startY, 0, ""));
            while (queueBFS.Count > 0)
            {
                var queueVal = queueBFS.Dequeue();
                int queueX = queueVal.Item1;
                int queueY = queueVal.Item2;
                int queueDist = queueVal.Item3;
                string queueLog = queueVal.Item4;

                if (queueX == exitX && queueY == exitY)
                {
                    if (shortDist > queueDist)
                    {
                        shortDist = queueDist;
                        path = queueLog + queueX + "," + queueY;
                    }
                }
                else
                {
                    if (shortDist > queueDist && IsPossibleMove(myMaze, mazeSizeX, mazeSizeY, queueX, queueY, queueLog))
                    {
                        queueDist++;
                        queueLog += queueX + "," + queueY + " ";
                        queueBFS.Enqueue(new Tuple<int, int, int, string>(queueX + 1, queueY, queueDist, queueLog));
                        queueBFS.Enqueue(new Tuple<int, int, int, string>(queueX - 1, queueY, queueDist, queueLog));
                        queueBFS.Enqueue(new Tuple<int, int, int, string>(queueX, queueY + 1, queueDist, queueLog));
                        queueBFS.Enqueue(new Tuple<int, int, int, string>(queueX, queueY - 1, queueDist, queueLog));
                    }
                }
            }
            ResultCount = shortDist;
            Result = path;
        }

        static bool IsPossibleMove(int[,] myMaze, int mapSizeX, int mapSizeY, int x, int y, string log)
        {
            if (x < 0 || x >= mapSizeX || y < 0 || y >= mapSizeY)
            {
                return false;
            }

            if (myMaze[x, y] == (int)MazeType.Wall)
            {
                return false;
            }

            if (log.Length == 0)
            {
                return true;
            }

            var tokens1 = log.Trim().Split(' ');
            foreach (var token1 in tokens1)
            {
                var tokens2 = token1.Split(',');
                var lx = Convert.ToInt32(tokens2[0]);
                var ly = Convert.ToInt32(tokens2[1]);

                if (lx == x && ly == y)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
