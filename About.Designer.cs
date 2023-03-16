namespace BoardGame
{
    partial class About
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
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblGameName = new System.Windows.Forms.Label();
            this.lblDvlpmntDate = new System.Windows.Forms.Label();
            this.lblDvlpr = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAbout.Location = new System.Drawing.Point(332, 19);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(123, 36);
            this.lblAbout.TabIndex = 7;
            this.lblAbout.Text = "ABOUT";
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGameName.Location = new System.Drawing.Point(12, 91);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(297, 29);
            this.lblGameName.TabIndex = 8;
            this.lblGameName.Text = "Game Name: Board Game";
            // 
            // lblDvlpmntDate
            // 
            this.lblDvlpmntDate.AutoSize = true;
            this.lblDvlpmntDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDvlpmntDate.Location = new System.Drawing.Point(12, 198);
            this.lblDvlpmntDate.Name = "lblDvlpmntDate";
            this.lblDvlpmntDate.Size = new System.Drawing.Size(314, 29);
            this.lblDvlpmntDate.TabIndex = 9;
            this.lblDvlpmntDate.Text = "Development Date: 21.03.22";
            // 
            // lblDvlpr
            // 
            this.lblDvlpr.AutoSize = true;
            this.lblDvlpr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDvlpr.Location = new System.Drawing.Point(12, 145);
            this.lblDvlpr.Name = "lblDvlpr";
            this.lblDvlpr.Size = new System.Drawing.Size(344, 29);
            this.lblDvlpr.TabIndex = 10;
            this.lblDvlpr.Text = "Developer: DİLEK KOCATÜRK";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(253, 397);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 29);
            this.label1.TabIndex = 11;
            this.label1.Text = "© 2022 All Rights Reserved.";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDvlpr);
            this.Controls.Add(this.lblDvlpmntDate);
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.lblAbout);
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.Label lblDvlpmntDate;
        private System.Windows.Forms.Label lblDvlpr;
        private System.Windows.Forms.Label label1;
    }
}