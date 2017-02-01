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

        private volatile DataTable totalDatatable = null;
        private double currArrears = 0;
        private double totalPaid = 0;
        ClassDAO clsDao = new ClassDAO();
        int selectedClass1 = 0;
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
            //this.studentTableAdapter.Fill(this.zahira_SISDataSet.student);
            // TODO: This line of code loads data into the 'zahira_SISDataSet.stuclass' table. You can move, or remove it, as needed.
            // this.stuclassTableAdapter.Fill(this.zahira_SISDataSet.stuclass);

            Console.WriteLine("select changed:");
            cmbClassType.DataSource = clsDao.GetClassByType();
            cmbClassType.DisplayMember = "description";
            cmbClassType.DisplayMember.Trim();
            cmbClassType.ValueMember = "statuscode";
            cmbClassType.Refresh();
            cmbClass.DataSource = clsDao.GetClass("ACT");
            cmbClass.DisplayMember = "name";
            cmbClass.ValueMember = "key_fld";
            cmbClass.Refresh();

            button3.Enabled = false;




        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                object ParameterName = new object();
               // this.studentTableAdapter.FillBy(this.zahira_SISDataSet.student, ParameterName);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedClass1 = (int)cmbClass.SelectedValue;
            //tsStatus.Text = "User Cancelled";

            tblStudents.DataSource = null;
            tblStudents.Refresh();
            txtCurArrears.Text = "0";
            txtCurBFArrears.Text = "0";
            if (totalDatatable != null)
            {
                totalDatatable.Reset();
            }
            if (!backgroundWorker1.IsBusy)
            {

                button2.Enabled = false;
                button3.Enabled = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Common().ExportToExcel(tblStudents,Double.Parse(txtCurArrears.Text), Double.Parse(txtCurBFArrears.Text));

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

        private void cmbClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = "ACT";

            if (!cmbClassType.SelectedValue.Equals(null))
            {
                selectedType = cmbClassType.SelectedValue.ToString();
                Console.WriteLine(selectedType);
            }
            cmbClass.DataSource = clsDao.GetClass(selectedType);
            cmbClass.DisplayMember = "name";
            cmbClass.ValueMember = "key_fld";
            cmbClass.Refresh();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            string fromdate = null;
            string todate = null;
            StudentDAO dao = new StudentDAO();
            totalDatatable = new DataTable();
            backgroundWorker1.ReportProgress(0);
            try
            {
                //TODO fill datatable with Lists. also check the date range.
                if (dateTimePicker2.Value != null)
                {
                    todate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                }

                //StudentArrearsBean bean = null;
                StudentDAO studentDAO = new StudentDAO();
                
                string classCode = (dao.getStudentClasses(selectedClass1).Code).Trim();
                StudentArrearsBean arrearsBean = studentDAO.getStudentArrearsByDatePerClass(classCode,
                    fromdate, todate,true);

                totalDatatable = arrearsBean.stPaidData;
                currArrears = Double.Parse(arrearsBean.curArrears);
                totalPaid += arrearsBean.feePaidForTheYear;
                backgroundWorker1.ReportProgress(100);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsStatus.Text = e.ProgressPercentage + "%";
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                //TODO fill datatable with Lists. also check the date range.
                tblStudents.Refresh();
                tblStudents.DataSource = totalDatatable;
                tblStudents.Refresh();
                txtCurArrears.Text = currArrears + "";
                txtCurBFArrears.Text = totalPaid + "";
                currArrears = 0;
                totalPaid = 0;
                button2.Enabled = true;
                button3.Enabled = false;

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
