namespace MazePlus
{
    partial class MazePlus
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MazePlus));
            this.pannel_maze = new System.Windows.Forms.Panel();
            this.move_Exit = new System.Windows.Forms.Label();
            this.move_Cat = new System.Windows.Forms.Button();
            this.move_CatReplay = new System.Windows.Forms.Label();
            this.btn_Hint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_BestCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_MoveCount = new System.Windows.Forms.Label();
            this.pannel_maze.SuspendLayout();
            this.SuspendLayout();
            // 
            // pannel_maze
            // 
            this.pannel_maze.AllowDrop = true;
            this.pannel_maze.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pannel_maze.Controls.Add(this.move_Exit);
            this.pannel_maze.Controls.Add(this.move_Cat);
            this.pannel_maze.Controls.Add(this.move_CatReplay);
            this.pannel_maze.Location = new System.Drawing.Point(15, 40);
            this.pannel_maze.Margin = new System.Windows.Forms.Padding(0);
            this.pannel_maze.Name = "pannel_maze";
            this.pannel_maze.Size = new System.Drawing.Size(760, 760);
            this.pannel_maze.TabIndex = 1;
            this.pannel_maze.Paint += new System.Windows.Forms.PaintEventHandler(this.mazePannel_Paint);
            this.pannel_maze.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mazePannel_MouseUp);
            // 
            // move_Exit
            // 
            this.move_Exit.Image = global::MazePlus.Properties.Resources.icons8_exit_door_38;
            this.move_Exit.Location = new System.Drawing.Point(680, 680);
            this.move_Exit.Name = "move_Exit";
            this.move_Exit.Size = new System.Drawing.Size(38, 38);
            this.move_Exit.TabIndex = 10;
            this.move_Exit.Click += new System.EventHandler(this.move_Exit_Click);
            // 
            // move_Cat
            // 
            this.move_Cat.AllowDrop = true;
            this.move_Cat.BackColor = System.Drawing.Color.Transparent;
            this.move_Cat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.move_Cat.CausesValidation = false;
            this.move_Cat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.move_Cat.ForeColor = System.Drawing.Color.Transparent;
            this.move_Cat.Image = global::MazePlus.Properties.Resources.pixel_cat_48;
            this.move_Cat.Location = new System.Drawing.Point(40, 40);
            this.move_Cat.Name = "move_Cat";
            this.move_Cat.Size = new System.Drawing.Size(38, 38);
            this.move_Cat.TabIndex = 20;
            this.move_Cat.UseVisualStyleBackColor = false;
            this.move_Cat.Move += new System.EventHandler(this.move_Cat_Move);
            // 
            // move_CatReplay
            // 
            this.move_CatReplay.Font = new System.Drawing.Font("굴림", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.move_CatReplay.ForeColor = System.Drawing.Color.Red;
            this.move_CatReplay.Image = global::MazePlus.Properties.Resources.re_pixel_cat_48;
            this.move_CatReplay.Location = new System.Drawing.Point(40, 40);
            this.move_CatReplay.Margin = new System.Windows.Forms.Padding(0);
            this.move_CatReplay.Name = "move_CatReplay";
            this.move_CatReplay.Size = new System.Drawing.Size(38, 38);
            this.move_CatReplay.TabIndex = 1;
            this.move_CatReplay.Text = "Re";
            this.move_CatReplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.move_CatReplay.Click += new System.EventHandler(this.move_CatReplay_Click);
            // 
            // btn_Hint
            // 
            this.btn_Hint.BackColor = System.Drawing.Color.Black;
            this.btn_Hint.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Hint.ForeColor = System.Drawing.Color.White;
            this.btn_Hint.Location = new System.Drawing.Point(691, 5);
            this.btn_Hint.Name = "btn_Hint";
            this.btn_Hint.Size = new System.Drawing.Size(70, 30);
            this.btn_Hint.TabIndex = 2;
            this.btn_Hint.Text = "! Hint !";
            this.btn_Hint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Hint.Click += new System.EventHandler(this.btn_hint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(426, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Best MoveCount :";
            // 
            // lb_BestCount
            // 
            this.lb_BestCount.AutoSize = true;
            this.lb_BestCount.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_BestCount.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lb_BestCount.Location = new System.Drawing.Point(595, 10);
            this.lb_BestCount.Name = "lb_BestCount";
            this.lb_BestCount.Size = new System.Drawing.Size(0, 24);
            this.lb_BestCount.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(15, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "MoveCount :";
            // 
            // lb_MoveCount
            // 
            this.lb_MoveCount.AutoSize = true;
            this.lb_MoveCount.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_MoveCount.ForeColor = System.Drawing.Color.Teal;
            this.lb_MoveCount.Location = new System.Drawing.Point(136, 12);
            this.lb_MoveCount.Name = "lb_MoveCount";
            this.lb_MoveCount.Size = new System.Drawing.Size(0, 24);
            this.lb_MoveCount.TabIndex = 7;
            // 
            // MazePlus
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(792, 813);
            this.Controls.Add(this.lb_MoveCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_BestCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Hint);
            this.Controls.Add(this.pannel_maze);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "MazePlus";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Random Maze ";
            this.Load += new System.EventHandler(this.MazePlus_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MazePlus_KeyUp);
            this.pannel_maze.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pannel_maze;
        public System.Windows.Forms.Button move_Cat;
        private System.Windows.Forms.Label btn_Hint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label move_CatReplay;
        public System.Windows.Forms.Label lb_MoveCount;
        public System.Windows.Forms.Label lb_BestCount;
        public System.Windows.Forms.Label move_Exit;
    }
}

