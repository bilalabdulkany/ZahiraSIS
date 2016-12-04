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
using ZahiraSIS.com.zahira.common;

namespace ZahiraSIS.com.zahira.view.reports
{
    public partial class frmServiceArrearsClasswise : Form
    {
        public frmServiceArrearsClasswise()
        {
            InitializeComponent();
            Console.WriteLine("Accessed Service Arrears");
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
            string fromdate=null;
            string todate=null;
            StudentDAO dao  = new StudentDAO();
            try
            {
                //TODO fill datatable with Lists. also check the date range.
               if (dateTimePicker2.Value != null)
                {
                    todate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    
                }
               
                StudentArrearsBean bean = null;
                StudentDAO studentDAO = new StudentDAO();
                int selectedClass1 = (int)cmbClass.SelectedValue;
                string classCode = (dao.getStudentClasses(selectedClass1).Code).Trim();
                StudentArrearsBean arrearsBean = studentDAO.getStudentArrearsByDate(classCode,
                    fromdate, todate);
                tblStudents.DataSource = arrearsBean.stPaidData;
                txtCurArrears.Text = arrearsBean.curArrears;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Common().ExportToExcel(tblStudents);

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
