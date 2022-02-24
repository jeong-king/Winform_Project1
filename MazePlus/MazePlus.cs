using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazePlus
{
    public partial class MazePlus : Form
    {
        public MazePlus()
        {
            InitializeComponent();
            
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        private void MazePlus_Load(object sender, EventArgs e)
        {
            move_CatReplay.Visible = false; 
            pannel_maze.Width = Space * MazeSize;
            pannel_maze.Height = Space * MazeSize;

            LocationX = move_Cat.Location.X;
            LocationY = move_Cat.Location.Y;

            InitMaze(MazeSize);
            SetRandomLocation();

            FindBFS(Maze, MazeSize, MazeSize, 1, 1, ExitX, ExitY);
            lb_BestCount.Text = ResultCount.ToString();
        }
        
        private void mazePannel_Paint(object sender, PaintEventArgs e)
        {
            DrawWall(e.Graphics);
        }
        
        private void MazePlus_KeyUp(object sender, KeyEventArgs e)
        {
            if (move_Cat.Location != move_Exit.Location)
            {
                if (LocationX < 0)
                {
                    LocationX += Space;
                }
                else if (LocationY < 0)
                {
                    LocationY += Space;
                }
                else if (LocationX > pannel_maze.Width - Space)
                {
                    LocationX -= Space;
                }
                else if (LocationY > pannel_maze.Height - Space)
                {
                    LocationY -= Space;
                }

                switch (e.KeyCode) {
                    case Keys.Up:
                        LocationY -= Space;
                        break;
                    case Keys.Left:
                        LocationX -= Space; 
                        break;
                    case Keys.Down:
                        LocationY += Space;
                        break;
                    case Keys.Right:
                        LocationX += Space;
                        break;
                }

                for (int i = 0; i < WallCount; i++)
                {
                    if (LocationX == pointWall[i].X && LocationY == pointWall[i].Y)
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Up:
                                LocationY += Space;
                                break;
                            case Keys.Left:
                                LocationX += Space;
                                break;
                            case Keys.Down:
                                LocationY -= Space;
                                break;
                            case Keys.Right:
                                LocationX -= Space;
                                break;
                        }
                    }
                }
                move_Cat.Location = new Point(LocationX, LocationY);
            }
        }

        private void move_Cat_Move(object sender, EventArgs e)
        {
            MoveCount++;
            lb_MoveCount.Text = MoveCount.ToString();

            var threadMaze = new Thread(EnqueueReplay);

            if (move_Cat.Location == move_Exit.Location)
            {
                move_CatReplay.Visible = true;
                stopwatch.Stop();
                
                string endMessage = ResultCount == MoveCount ? "++Perfect++!" : "! 탈출 성공 !";
                MessageBox.Show(endMessage);

                DequeueReplay((Control)sender, LocationX, LocationY);

                if (MessageBox.Show("Json파일로 저장하시겠습니까?", ".json 저장하기", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveJson(sender, e);

                }
                else
                {
                    if (MessageBox.Show("Game을 새로 시작하시겠습니까?", "! Game Restart !", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                }
            }

            threadMaze.Start();

            stopwatch.Stop();
            MoveTime = stopwatch.ElapsedMilliseconds.ToString();
            stopwatch.Reset();
            stopwatch.Start();
        }

        private void EnqueueReplay()
        {
            Task tEnq = Task.Factory.StartNew(() =>
            {
                queueReplay.Enqueue(new Tuple<int, int, string>(LocationX, LocationY, MoveTime));
                queueJsonReplay.Enqueue(new Tuple<int, int, string>(LocationX, LocationY, MoveTime));
            });
        }

        delegate void CrossThread(Control b, Int32 x, Int32 y);

        private void DequeueReplay(Control b, Int32 x, Int32 y)
        {
            while (queueReplay.Count > 0)
            {
                var queueReplayVal = queueReplay.Dequeue();
                int replayLocationX = queueReplayVal.Item1;
                int replayLocationY = queueReplayVal.Item2;
                string replayTime = queueReplayVal.Item3;

                Delay(Convert.ToInt32(replayTime));
                move_CatReplay.Location = new Point(replayLocationX, replayLocationY);

                if (b.InvokeRequired)
                {
                    b.Invoke(new CrossThread(DequeueReplay), b, x, y);
                }
                else
                {
                    b.Location = new Point(x, y);
                    move_Cat.Location = b.Location;
                }
            }
        }
    }
}
