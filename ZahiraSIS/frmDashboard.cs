using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ZahiraSIS
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
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
                default:
                    break;
            }
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
