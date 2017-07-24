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
    public partial class FacilityFeeInvoiceViewer : Form
    {
        public FacilityFeeInvoiceViewer()
        {
            InitializeComponent();
        }

        private void FacilityFeeInvoiceViewer_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
