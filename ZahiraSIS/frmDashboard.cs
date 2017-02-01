using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZahiraSIS.com.zahira.view.promotestudents;
using ZahiraSIS.com.zahira.view.reports;
using FoxProUpdate;

namespace ZahiraSIS
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            //outputToFile();
            Console.WriteLine("Accessed Dashboard");
        }
        /**
        * Log the console output to trace files.
        * 
        **/
        private void outputToFile()
        {
            try
            {
                DateTime today = DateTime.Today;
                String date = today.ToString("dd-MM-yyyy");
                FileStream filestream = new FileStream("./trace." + date + ".log", FileMode.Append);
                var streamwriter = new StreamWriter(filestream);
                streamwriter.AutoFlush = true;
                Console.SetOut(streamwriter);
                Console.SetError(streamwriter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void mnuStudentClassReport_Click(object sender, EventArgs e)
        {
            frmClassReport home = new frmClassReport();
            home.ShowDialog();
        }

        private void serviceFeesArrearsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void summartToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void classTeacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            com.zahira.view.reports.frmServiceArrearsClasswise frmServiceArrears = new com.zahira.view.reports.frmServiceArrearsClasswise();
            frmServiceArrears.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;                    
                    break;
                case DialogResult.Yes:
                   
                    System.Windows.Forms.Application.Exit();
                 break;

                default:
                    break;
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void serviceFeesYearlySummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiceFeeYrSummary formSummary = new frmServiceFeeYrSummary();
            formSummary.Show();
            
        }

        private void studentPromotionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPromoteStudents promotion = new frmPromoteStudents();
            promotion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            com.zahira.view.reports.frmServiceArrearsClasswise frmServiceArrears = new com.zahira.view.reports.frmServiceArrearsClasswise();
            frmServiceArrears.Show();
        }

        private void btnStuArrears_Click(object sender, EventArgs e)
        {
            frmServiceFeeYrSummary formSummary = new frmServiceFeeYrSummary();
            formSummary.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClassReport classReport = new frmClassReport();
            classReport.Show();
        }

        private void syncBackupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FoxProUpdate.Form1 foxProSync = new FoxProUpdate.Form1();
            foxProSync.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new frmServiceArrearsGradewise().Show();
        }
    }
}
