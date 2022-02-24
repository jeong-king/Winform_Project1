using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MazePlus
{
    public partial class MazePlus : Form
    {
        private void btn_hint_Click(object sender, EventArgs e)
        {
            Graphics graphics = pannel_maze.CreateGraphics();
            PenSolution.EndCap = LineCap.ArrowAnchor;
            PenSolution2.EndCap = LineCap.ArrowAnchor;

            CurrentX = LocationY / Space;
            CurrentY = LocationX / Space;

            FindBFS(Maze, MazeSize, MazeSize, CurrentX, CurrentY, ExitX, ExitY);

            string[] splitResult = Result.Split(' ');

            for (int i = 0; i < ResultCount + 1; i++)
            {
                int splitResultX = Convert.ToInt32(splitResult[i].Split(',')[0]);
                int splitResultY = Convert.ToInt32(splitResult[i].Split(',')[1]);

                pointResult[i] = new Point(splitResultY * Space + 24, splitResultX * Space + 24);
            }

            for (int j = 0; j < ResultCount; j++)
            {
                graphics.DrawLine(PenSolution, pointResult[j], pointResult[j + 1]);
                Delay(75);
            }
            for (int j = 0; j < ResultCount; j++)
            {
                graphics.DrawLine(PenSolution2, pointResult[j], pointResult[j + 1]);
                Delay(50);
            }
        }
        private void mazePannel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu conMenu = new ContextMenu();
                conMenu.MenuItems.Add(new MenuItem("Save", SaveJson));
                conMenu.MenuItems.Add(new MenuItem("Open", OpenJson));
                conMenu.MenuItems.Add(new MenuItem("Exit", ExitGame));
                conMenu.MenuItems.Add(new MenuItem("Restart", RestartGame));

                pannel_maze.ContextMenu = conMenu;
                pannel_maze.ContextMenu.Show(pannel_maze, e.Location);
            }
        }

        private void move_Exit_Click(object sender, EventArgs e)
        {
            ExitGame(sender, e);
        }

        private void move_CatReplay_Click(object sender, EventArgs e)
        {
            RestartGame(sender, e);
        }

        private void ExitGame(object sender, EventArgs e)
        {
            if (MessageBox.Show("게임을 종료하시겠습니까?", "게임 나가기", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void RestartGame(object sender, EventArgs e)
        {
            if (MessageBox.Show("게임을 재시작하시겠습니까?", "게임 재시작", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
    }
}
