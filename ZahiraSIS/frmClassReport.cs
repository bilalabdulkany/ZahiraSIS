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
    public partial class frmClassReport : Form
    {

        dbConnector dbCon;
        public frmClassReport()
        {
            InitializeComponent();
        }

        private void frmClassReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zahira_SISDataSet.stuclass' table. You can move, or remove it, as needed.
            this.stuclassTableAdapter.Fill(this.zahira_SISDataSet.stuclass);

        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            Console.WriteLine(cmbClass.SelectedValue.ToString());
            dbCon = new dbConnector();
            txtTeacherName.Text = dbCon.getTeacherName(cmbClass.SelectedValue.ToString());
        }
    }
}
