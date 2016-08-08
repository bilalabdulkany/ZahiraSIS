namespace ZahiraSIS
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Report = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceFeesReceiptReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceFeesArrearsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.serviceFeesYearlySummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentBFArrearsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentDetailReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStudentClassReport = new System.Windows.Forms.ToolStripMenuItem();
            this.generalReceiptParticularsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.serviceFeesReceiptReportToolStripMenuItem,
            this.serviceFeesArrearsReportToolStripMenuItem,
            this.toolStripSeparator1,
            this.serviceFeesYearlySummaryToolStripMenuItem,
            this.studentBFArrearsToolStripMenuItem,
            this.studentDetailReportToolStripMenuItem,
            this.mnuStudentClassReport,
            this.generalReceiptParticularsToolStripMenuItem});
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(59, 20);
            this.Report.Text = "Reports";
            this.Report.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // serviceFeesReceiptReportToolStripMenuItem
            // 
            this.serviceFeesReceiptReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classTeacherToolStripMenuItem});
            this.serviceFeesReceiptReportToolStripMenuItem.Name = "serviceFeesReceiptReportToolStripMenuItem";
            this.serviceFeesReceiptReportToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.serviceFeesReceiptReportToolStripMenuItem.Text = "Service Fees Receipt Report";
            // 
            // classTeacherToolStripMenuItem
            // 
            this.classTeacherToolStripMenuItem.Name = "classTeacherToolStripMenuItem";
            this.classTeacherToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.classTeacherToolStripMenuItem.Text = "Class Wise";
            this.classTeacherToolStripMenuItem.Click += new System.EventHandler(this.classTeacherToolStripMenuItem_Click);
            // 
            // serviceFeesArrearsReportToolStripMenuItem
            // 
            this.serviceFeesArrearsReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summartToolStripMenuItem,
            this.detailToolStripMenuItem});
            this.serviceFeesArrearsReportToolStripMenuItem.Name = "serviceFeesArrearsReportToolStripMenuItem";
            this.serviceFeesArrearsReportToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.serviceFeesArrearsReportToolStripMenuItem.Text = "Service Fees Arrears Report";
            this.serviceFeesArrearsReportToolStripMenuItem.Click += new System.EventHandler(this.serviceFeesArrearsReportToolStripMenuItem_Click);
            // 
            // summartToolStripMenuItem
            // 
            this.summartToolStripMenuItem.Name = "summartToolStripMenuItem";
            this.summartToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.summartToolStripMenuItem.Text = "Class Wise";
            this.summartToolStripMenuItem.Click += new System.EventHandler(this.summartToolStripMenuItem_Click);
            // 
            // detailToolStripMenuItem
            // 
            this.detailToolStripMenuItem.Name = "detailToolStripMenuItem";
            this.detailToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.detailToolStripMenuItem.Text = "Summary";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // serviceFeesYearlySummaryToolStripMenuItem
            // 
            this.serviceFeesYearlySummaryToolStripMenuItem.Name = "serviceFeesYearlySummaryToolStripMenuItem";
            this.serviceFeesYearlySummaryToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.serviceFeesYearlySummaryToolStripMenuItem.Text = "Service Fees Yearly Summary";
            // 
            // studentBFArrearsToolStripMenuItem
            // 
            this.studentBFArrearsToolStripMenuItem.Name = "studentBFArrearsToolStripMenuItem";
            this.studentBFArrearsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.studentBFArrearsToolStripMenuItem.Text = "Student B/F Arrears";
            // 
            // studentDetailReportToolStripMenuItem
            // 
            this.studentDetailReportToolStripMenuItem.Name = "studentDetailReportToolStripMenuItem";
            this.studentDetailReportToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.studentDetailReportToolStripMenuItem.Text = "Student Detail Report";
            // 
            // mnuStudentClassReport
            // 
            this.mnuStudentClassReport.BackColor = System.Drawing.SystemColors.Highlight;
            this.mnuStudentClassReport.Name = "mnuStudentClassReport";
            this.mnuStudentClassReport.Size = new System.Drawing.Size(226, 22);
            this.mnuStudentClassReport.Text = "Student Class Report";
            this.mnuStudentClassReport.Click += new System.EventHandler(this.mnuStudentClassReport_Click);
            // 
            // generalReceiptParticularsToolStripMenuItem
            // 
            this.generalReceiptParticularsToolStripMenuItem.Name = "generalReceiptParticularsToolStripMenuItem";
            this.generalReceiptParticularsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.generalReceiptParticularsToolStripMenuItem.Text = "General Receipt Particulars";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 274);
            this.Controls.Add(this.menuStrip1);
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
        private System.Windows.Forms.ToolStripMenuItem Report;
        private System.Windows.Forms.ToolStripMenuItem mnuStudentClassReport;
        private System.Windows.Forms.ToolStripMenuItem studentDetailReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem serviceFeesYearlySummaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceFeesArrearsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentBFArrearsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalReceiptParticularsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceFeesReceiptReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem summartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailToolStripMenuItem;
    }
}