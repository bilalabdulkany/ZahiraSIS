using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZahiraSIS.com.zahira.bean.student;

namespace ZahiraSIS.com.zahira.view.reports
{
    public partial class frmServiceArrearsClasswise : Form
    {
        public frmServiceArrearsClasswise()
        {
            InitializeComponent();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmServiceArrearsClasswise_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zahira_SISDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.zahira_SISDataSet.student);
            // TODO: This line of code loads data into the 'zahira_SISDataSet.stuclass' table. You can move, or remove it, as needed.
            this.stuclassTableAdapter.Fill(this.zahira_SISDataSet.stuclass);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                object ParameterName = new object();
                this.studentTableAdapter.FillBy(this.zahira_SISDataSet.student, ParameterName);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.FillByClass(this.zahira_SISDataSet.student, new System.Nullable<int>(((int)(System.Convert.ChangeType(cmbClass.SelectedValue, typeof(int))))));
                StudentArrearsBean bean = null;
                StudentDAO studentDAO = new StudentDAO();
                bean = studentDAO.getStudentArrears(cmbClass.SelectedValue.ToString());
                txtBFArrears.Text = bean.getBfArrears();
                txtCurArrears.Text = bean.getCurArrears();
                txtCurBFArrears.Text = bean.getCurBfArrears();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
