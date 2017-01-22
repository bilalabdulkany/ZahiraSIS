using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZahiraSIS.com.zahira.reports
{
    public partial class StudentReceiptViewer : Form
    {
        ReportParameter p1 = new ReportParameter("TrnNo", "1234");



        // ReportParameter p2 = new ReportParameter("TrnDate", new DateTime().ToShortDateString());

        ReportParameter p3 = new ReportParameter("AdmNo", "19941");

        ReportParameter p4 = new ReportParameter("Name", "M. Bilal Abdulkany");

        ReportParameter p5 = new ReportParameter("Paid", "19000");

        ReportParameter p6 = new ReportParameter("Arrears", "19000");

        public StudentReceiptViewer()
        {
            InitializeComponent();
        }

        private void StudentReceiptViewer_Load(object sender, EventArgs e)
        {

            setupParameters();
        }

        private void setupParameters() {

          

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p3, p4,p5,p6 });
            this.reportViewer1.RefreshReport();

        }
    }
}
