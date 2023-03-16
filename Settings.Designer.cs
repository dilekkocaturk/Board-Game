namespace BoardGame
{
    partial class Settings
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
            this.lblDiffLvl = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblRow = new System.Windows.Forms.Label();
            this.lblClmn = new System.Windows.Forms.Label();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.txtCol = new System.Windows.Forms.TextBox();
            this.lblSttngs = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.grpBxShape = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpBxShape.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDiffLvl
            // 
            this.lblDiffLvl.AutoSize = true;
            this.lblDiffLvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblDiffLvl.Location = new System.Drawing.Point(12, 73);
            this.lblDiffLvl.Name = "lblDiffLvl";
            this.lblDiffLvl.Size = new System.Drawing.Size(172, 29);
            this.lblDiffLvl.TabIndex = 0;
            this.lblDiffLvl.Text = "Difficulty Level:";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Easy",
            "Intermediate",
            "Hard",
            "Custom"});
            this.comboBox1.Location = new System.Drawing.Point(189, 70);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 37);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblRow
            // 
            this.lblRow.AutoSize = true;
            this.lblRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRow.Location = new System.Drawing.Point(469, 78);
            this.lblRow.Name = "lblRow";
            this.lblRow.Size = new System.Drawing.Size(68, 29);
            this.lblRow.TabIndex = 2;
            this.lblRow.Text = "Row:";
            this.lblRow.Visible = false;
            // 
            // lblClmn
            // 
            this.lblClmn.AutoSize = true;
            this.lblClmn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblClmn.Location = new System.Drawing.Point(469, 126);
            this.lblClmn.Name = "lblClmn";
            this.lblClmn.Size = new System.Drawing.Size(102, 29);
            this.lblClmn.TabIndex = 3;
            this.lblClmn.Text = "Column:";
            this.lblClmn.Visible = false;
            // 
            // txtRow
            // 
            this.txtRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtRow.Location = new System.Drawing.Point(632, 70);
            this.txtRow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(100, 34);
            this.txtRow.TabIndex = 4;
            this.txtRow.Visible = false;
            // 
            // txtCol
            // 
            this.txtCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCol.Location = new System.Drawing.Point(632, 122);
            this.txtCol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(100, 34);
            this.txtCol.TabIndex = 5;
            this.txtCol.Visible = false;
            // 
            // lblSttngs
            // 
            this.lblSttngs.AutoSize = true;
            this.lblSttngs.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSttngs.Location = new System.Drawing.Point(303, 9);
            this.lblSttngs.Name = "lblSttngs";
            this.lblSttngs.Size = new System.Drawing.Size(172, 36);
            this.lblSttngs.TabIndex = 6;
            this.lblSttngs.Text = "SETTINGS";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.Location = new System.Drawing.Point(97, 20);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 33);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Square";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox2.Location = new System.Drawing.Point(97, 57);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(125, 33);
            this.checkBox2.TabIndex = 9;
            this.checkBox2.Text = "Triangle";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox3.Location = new System.Drawing.Point(97, 96);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(98, 33);
            this.checkBox3.TabIndex = 10;
            this.checkBox3.Text = "Circle";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Location = new System.Drawing.Point(327, 362);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(163, 48);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBack.Location = new System.Drawing.Point(676, 386);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(112, 52);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox4.Location = new System.Drawing.Point(129, 18);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(80, 33);
            this.checkBox4.TabIndex = 14;
            this.checkBox4.Text = "Red";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox5.Location = new System.Drawing.Point(129, 53);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(102, 33);
            this.checkBox5.TabIndex = 15;
            this.checkBox5.Text = "Green";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox6.Location = new System.Drawing.Point(129, 92);
            this.checkBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(84, 33);
            this.checkBox6.TabIndex = 16;
            this.checkBox6.Text = "Blue";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // grpBxShape
            // 
            this.grpBxShape.Controls.Add(this.checkBox1);
            this.grpBxShape.Controls.Add(this.checkBox2);
            this.grpBxShape.Controls.Add(this.checkBox3);
            this.grpBxShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpBxShape.Location = new System.Drawing.Point(17, 200);
            this.grpBxShape.Name = "grpBxShape";
            this.grpBxShape.Size = new System.Drawing.Size(254, 135);
            this.grpBxShape.TabIndex = 17;
            this.grpBxShape.TabStop = false;
            this.grpBxShape.Text = "Shape:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox5);
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(478, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 135);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Color:";
            // 
            // Settings
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpBxShape);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSttngs);
            this.Controls.Add(this.txtCol);
            this.Controls.Add(this.txtRow);
            this.Controls.Add(this.lblClmn);
            this.Controls.Add(this.lblRow);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblDiffLvl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.grpBxShape.ResumeLayout(false);
            this.grpBxShape.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiffLvl;
        private System.Windows.Forms.Label lblRow;
        private System.Windows.Forms.Label lblClmn;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.Label lblSttngs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox grpBxShape;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}