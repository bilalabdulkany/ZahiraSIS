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

        String TrnNo, AdmNo,name, paid, Arrears,ClassCode=null;
        public StudentReceiptViewer(String TrnNo,String AdmNo,String Name,String paid, String Arrears,String ClassCode)
        {
            InitializeComponent();
            this.name = Name;
            this.ClassCode = ClassCode;
            this.TrnNo = TrnNo;
            this.AdmNo = AdmNo;
            this.Arrears = Arrears;
            this.paid = paid;

        }
        public StudentReceiptViewer() {
        }

        private void StudentReceiptViewer_Load(object sender, EventArgs e)
        {

            setupParameters();
        }

        private void setupParameters() {
            DateTime datetimenow = new DateTime();
            datetimenow= DateTime.Now;
            ReportParameter p1 = new ReportParameter("TrnNo", TrnNo);
             ReportParameter p2 = new ReportParameter("TrnDate", datetimenow.ToString("dd-MM-yyyy"));
            ReportParameter p22 = new ReportParameter("TrnTime", datetimenow.ToString("HH:MM"));

            ReportParameter p3 = new ReportParameter("AdmNo", AdmNo);

            ReportParameter p4 = new ReportParameter("Name", name);

            ReportParameter p5 = new ReportParameter("Paid", paid);

            ReportParameter p6 = new ReportParameter("Arrears", Arrears);

            ReportParameter p7 = new ReportParameter("Code", ClassCode);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1,p2,p22, p3, p4,p5,p6,p7 });
            this.reportViewer1.RefreshReport();

        }
    }
}
