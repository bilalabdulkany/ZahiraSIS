﻿namespace ZahiraSIS
{
    partial class frmDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.proceduresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentPromotionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncBackupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStuArrears = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnArrearsLetters = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proceduresToolStripMenuItem,
            this.syncBackupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(489, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // proceduresToolStripMenuItem
            // 
            this.proceduresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentPromotionsToolStripMenuItem});
            this.proceduresToolStripMenuItem.Name = "proceduresToolStripMenuItem";
            this.proceduresToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.proceduresToolStripMenuItem.Text = "Procedures";
            // 
            // studentPromotionsToolStripMenuItem
            // 
            this.studentPromotionsToolStripMenuItem.Name = "studentPromotionsToolStripMenuItem";
            this.studentPromotionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.studentPromotionsToolStripMenuItem.Text = "Student Promotions";
            this.studentPromotionsToolStripMenuItem.Click += new System.EventHandler(this.studentPromotionsToolStripMenuItem_Click);
            // 
            // syncBackupToolStripMenuItem
            // 
            this.syncBackupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncBackupToolStripMenuItem1});
            this.syncBackupToolStripMenuItem.Name = "syncBackupToolStripMenuItem";
            this.syncBackupToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.syncBackupToolStripMenuItem.Text = "Tools";
            // 
            // syncBackupToolStripMenuItem1
            // 
            this.syncBackupToolStripMenuItem1.Name = "syncBackupToolStripMenuItem1";
            this.syncBackupToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.syncBackupToolStripMenuItem1.Text = "Sync Backup";
            this.syncBackupToolStripMenuItem1.Click += new System.EventHandler(this.syncBackupToolStripMenuItem1_Click);
            // 
            // btnStuArrears
            // 
            this.btnStuArrears.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStuArrears.Location = new System.Drawing.Point(236, 85);
            this.btnStuArrears.Name = "btnStuArrears";
            this.btnStuArrears.Size = new System.Drawing.Size(101, 52);
            this.btnStuArrears.TabIndex = 2;
            this.btnStuArrears.Text = "Student Arrears";
            this.btnStuArrears.UseVisualStyleBackColor = false;
            this.btnStuArrears.Click += new System.EventHandler(this.btnStuArrears_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(355, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "Classwise Arrears";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(35, 229);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 52);
            this.button2.TabIndex = 4;
            this.button2.Text = "Class Info\r\n";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button3.Location = new System.Drawing.Point(355, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 52);
            this.button3.TabIndex = 5;
            this.button3.Text = "Gradewise Arrears";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button4.Location = new System.Drawing.Point(355, 143);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 52);
            this.button4.TabIndex = 6;
            this.button4.Text = "Schoolwise Arrears";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnArrearsLetters
            // 
            this.btnArrearsLetters.BackColor = System.Drawing.Color.Honeydew;
            this.btnArrearsLetters.Location = new System.Drawing.Point(355, 229);
            this.btnArrearsLetters.Name = "btnArrearsLetters";
            this.btnArrearsLetters.Size = new System.Drawing.Size(93, 52);
            this.btnArrearsLetters.TabIndex = 7;
            this.btnArrearsLetters.Text = "Print Arrears Letters";
            this.btnArrearsLetters.UseVisualStyleBackColor = false;
            this.btnArrearsLetters.Click += new System.EventHandler(this.btnArrearsLetters_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Turquoise;
            this.button5.Location = new System.Drawing.Point(189, 229);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 52);
            this.button5.TabIndex = 8;
            this.button5.Text = "AL Student Fees";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(489, 293);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.btnArrearsLetters);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnStuArrears);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem proceduresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentPromotionsToolStripMenuItem;
        private System.Windows.Forms.Button btnStuArrears;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem syncBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncBackupToolStripMenuItem1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnArrearsLetters;
        private System.Windows.Forms.Button button5;
    }
}