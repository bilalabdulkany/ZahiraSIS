namespace ZahiraSIS
{
    partial class Dashboard
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Report = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStudentClassReport = new System.Windows.Forms.ToolStripMenuItem();
            this.studentDetailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Report});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(433, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Report
            // 
            this.Report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStudentClassReport,
            this.studentDetailReportToolStripMenuItem});
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(54, 20);
            this.Report.Text = "Report";
            this.Report.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // mnuStudentClassReport
            // 
            this.mnuStudentClassReport.Name = "mnuStudentClassReport";
            this.mnuStudentClassReport.Size = new System.Drawing.Size(186, 22);
            this.mnuStudentClassReport.Text = "Student Class Report";
            this.mnuStudentClassReport.Click += new System.EventHandler(this.mnuStudentClassReport_Click);
            // 
            // studentDetailReportToolStripMenuItem
            // 
            this.studentDetailReportToolStripMenuItem.Name = "studentDetailReportToolStripMenuItem";
            this.studentDetailReportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.studentDetailReportToolStripMenuItem.Text = "Student Detail Report";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 274);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Report;
        private System.Windows.Forms.ToolStripMenuItem mnuStudentClassReport;
        private System.Windows.Forms.ToolStripMenuItem studentDetailReportToolStripMenuItem;
    }
}