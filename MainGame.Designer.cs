namespace BoardGame
{
    partial class MainGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGame));
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnManage = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnStngs = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblScr = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.lblBstScr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Location = new System.Drawing.Point(1071, 341);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(128, 46);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogOut.Location = new System.Drawing.Point(1071, 285);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(128, 50);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnManage
            // 
            this.btnManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnManage.Location = new System.Drawing.Point(1071, 5);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(128, 50);
            this.btnManage.TabIndex = 3;
            this.btnManage.Text = "Manage";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnProfile.Location = new System.Drawing.Point(1071, 117);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(128, 50);
            this.btnProfile.TabIndex = 4;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnStngs
            // 
            this.btnStngs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStngs.Location = new System.Drawing.Point(1071, 61);
            this.btnStngs.Name = "btnStngs";
            this.btnStngs.Size = new System.Drawing.Size(128, 50);
            this.btnStngs.TabIndex = 5;
            this.btnStngs.Text = "Settings";
            this.btnStngs.UseVisualStyleBackColor = true;
            this.btnStngs.Click += new System.EventHandler(this.btnStngs_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAbout.Location = new System.Drawing.Point(1071, 173);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(128, 50);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "redSquare.png");
            this.ımageList1.Images.SetKeyName(1, "redTriangle.PNG");
            this.ımageList1.Images.SetKeyName(2, "redCircle.PNG");
            this.ımageList1.Images.SetKeyName(3, "greenSquare.png");
            this.ımageList1.Images.SetKeyName(4, "greenTriangle.PNG");
            this.ımageList1.Images.SetKeyName(5, "greenCircle.PNG");
            this.ımageList1.Images.SetKeyName(6, "blueSquare.png");
            this.ımageList1.Images.SetKeyName(7, "blueTriangle.png");
            this.ımageList1.Images.SetKeyName(8, "blueCircle.PNG");
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStart.Location = new System.Drawing.Point(504, 299);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(168, 62);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblWelcome.Location = new System.Drawing.Point(354, 243);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(467, 36);
            this.lblWelcome.TabIndex = 8;
            this.lblWelcome.Text = "WELCOME TO BOARD GAME !";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScore.Location = new System.Drawing.Point(1073, 484);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(69, 25);
            this.lblScore.TabIndex = 9;
            this.lblScore.Text = "Score";
            // 
            // lblScr
            // 
            this.lblScr.AutoSize = true;
            this.lblScr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblScr.Location = new System.Drawing.Point(1148, 482);
            this.lblScr.Name = "lblScr";
            this.lblScr.Size = new System.Drawing.Size(27, 29);
            this.lblScr.TabIndex = 10;
            this.lblScr.Text = "0";
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHelp.Location = new System.Drawing.Point(1071, 229);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(128, 50);
            this.btnHelp.TabIndex = 11;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBestScore.Location = new System.Drawing.Point(1073, 407);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(69, 50);
            this.lblBestScore.TabIndex = 12;
            this.lblBestScore.Text = "Best\r\nScore";
            this.lblBestScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBstScr
            // 
            this.lblBstScr.AutoSize = true;
            this.lblBstScr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBstScr.Location = new System.Drawing.Point(1148, 417);
            this.lblBstScr.Name = "lblBstScr";
            this.lblBstScr.Size = new System.Drawing.Size(27, 29);
            this.lblBstScr.TabIndex = 13;
            this.lblBstScr.Text = "0";
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1202, 873);
            this.Controls.Add(this.lblBstScr);
            this.Controls.Add(this.lblBestScore);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblScr);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnStngs);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnExit);
            this.Name = "MainGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainGame";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnStngs;
        private System.Windows.Forms.Button btnAbout;
        public System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblScr;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.Label lblBstScr;
    }
}