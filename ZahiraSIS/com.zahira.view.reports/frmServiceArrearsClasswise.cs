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
            String fromdate=null;
            String todate=null;
            try
            {
                //TODO fill datatable with Lists. also check the date range.
                if (dateTimePicker1.Value != null) {
                    fromdate=dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    Console.WriteLine(fromdate);

                }
                if (dateTimePicker2.Value != null)
                {
                    todate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                    
                }
                /**
                 * SELECT key_fld, active, enamfcnsn, mfeecnsn, admno, name, dob, address, registerno, bloodgr, comments, prntname, prntphone, prntemail,
                 *  key_class, bfarrears, curarrears, key_change, curbfarres, admon,
                 *   arrearsfrm, arrearsto FROM dbo.student
                 *   where key_class = @ClassKey and arrearsfrm =@from arrearsto <= @to
                 **/
               // this.studentTableAdapter.FillByClass(this.zahira_SISDataSet.student, new System.Nullable<int>(((int)(System.Convert.ChangeType(cmbClass.SelectedValue, typeof(int))))));
                StudentArrearsBean bean = null;
                StudentDAO studentDAO = new StudentDAO();
                String selectedClass = cmbClass.SelectedValue.ToString();
                tblStudents.DataSource = studentDAO.getStudentArrearsByDate(cmbClass.SelectedValue.ToString(), fromdate, todate);
                bean = studentDAO.getStudentArrears(selectedClass);
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
