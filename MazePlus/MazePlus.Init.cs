using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazePlus
{
    public partial class MazePlus : Form
    {
        private void InitMaze(int size)
        {
            Maze = new int[MazeSize, MazeSize];
            size = MazeSize;
            
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x == 0 || x == size - 1 || y == 0 || y == size - 1)
                    {
                        Maze[y, x] = (int)MazeType.Wall;
                    }
                    else
                    {
                        Maze[y, x] = (int)MazeType.Pathway;
                    }

                    if (x % 2 == 0 || y % 2 == 0)
                    {
                        Maze[y, x] = (int)MazeType.Wall;
                    }
                    else
                    {
                        Maze[y, x] = (int)MazeType.Pathway;
                    }
                }
            }
            
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (x % 2 == 0 || y % 2 == 0)
                        continue;

                    if (x == size - 2 && y == size - 2)
                        continue;

                    if (y == size - 2)
                    {
                        Maze[y, x + 1] = (int)MazeType.Pathway;
                        continue;
                    }

                    if (x == size - 2)
                    {
                        Maze[y + 1, x] = (int)MazeType.Pathway;
                        continue;
                    }

                    if (random.Next(0, 2) == 0)
                    {
                        Maze[y, x + 1] = (int)MazeType.Pathway;
                    }
                    else
                    {
                        Maze[y + 1, x] = (int)MazeType.Pathway;
                    }
                }
            }
            
            for (int y = 0; y < MazeSize; y++)
            {
                for (int x = 0; x < MazeSize; x++)
                {
                    if (Maze[y, x] == (int)MazeType.Wall)
                    {
                        pointWall[WallCount] = new Point(x * Space, y * Space);
                        WallCount++;
                    }
                }
            }
        }

        private void DrawWall(Graphics g)
        {
            for (int y = 0; y < MazeSize; y++)
            {
                for (int x = 0; x < MazeSize; x++)
                {
                    if (Maze[y, x] == (int)MazeType.Wall)
                    {
                        g.FillRectangle(Brush, new Rectangle(x * Space + 1, y * Space + 1, Space - 2, Space - 2));
                    }
                }
            }
        }

        private void SetRandomLocation()
        {
            ExitX = random.Next(1, 6);
            ExitY = random.Next(12, 18);

            if (Maze[ExitX, ExitY] == (int)MazeType.Pathway)
            {
                move_Exit.Location = new Point(ExitY * Space, ExitX * Space);
            }
            else
            {
                SetRandomLocation();
            }
        }

        public void SetJsonRefresh()
        {
            pannel_maze.Refresh();
            move_CatReplay.Visible = true;
            move_Cat.Visible = false;
            move_CatReplay.Refresh();
            btn_Hint.Visible = false;
            btn_Hint.Refresh();
            lb_BestCount.Refresh();

            Delay(1000);
        }
        
        public static DateTime Delay(int ms)
        {
            DateTime moment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime afterWards = moment.Add(duration);

            while (afterWards >= moment)
            {
                Application.DoEvents();
                moment = DateTime.Now;
            }

            return DateTime.Now;
        }
    }
}
