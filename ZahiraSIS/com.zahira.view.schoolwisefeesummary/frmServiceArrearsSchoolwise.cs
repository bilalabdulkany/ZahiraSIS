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

namespace ZahiraSIS.com.zahira.view.schoolwise
{
    public partial class frmServiceArrearsSchoolwise : Form
    {

        private volatile DataTable totalDatatable = null;
        private double currArrears = 0;
        private double totalPaid = 0;
        ClassDAO clsDao = new ClassDAO();
        int selectedClass1 = 0;
        public readonly String COLUMN_CLASS = "Class";
        public readonly String COLUMN_TOTAL_PAID = "Total Fee paid this year";
        public readonly String COLUMN_ARREARS = "Arrears";
        public frmServiceArrearsSchoolwise()
        {
            InitializeComponent();
            Console.WriteLine("Accessed Service Arrears");
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void frmServiceArrearsSchoolwise_Load(object sender, EventArgs e)
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
            //selectedClass1 = (int)cmbClass.SelectedValue;
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
            if (totalDatatable.Rows.Count != 0) {
                totalDatatable.Clear();
            }
           
            backgroundWorker1.ReportProgress(0);
            List<StudentArrearsBean> stBeanList = null;
            try
            {
                //TODO fill datatable with Lists. also check the date range.
                if (dateTimePicker2.Value != null)
                {
                    todate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                }                
                stBeanList = new List<StudentArrearsBean>();


                //TODO the Student bean should be taken from ClassDAO and output the 
                //student bean.     
                DataTable AllClasses = clsDao.GetAllActiveClasses();
                totalDatatable.Columns.Add(COLUMN_ARREARS);
                totalDatatable.Columns.Add(COLUMN_CLASS);
                totalDatatable.Columns.Add(COLUMN_TOTAL_PAID);


                int ClassLen = AllClasses.Rows.Count;
                for (int i = 0; i < ClassLen; i++) {
                    string classCode = AllClasses.Rows[i]["classcode"].ToString().Trim();
                    StudentArrearsBean arrearsBean = dao.getStudentArrearsByDatePerClass(classCode,
                        fromdate, todate, true);
                    //totalDatatable = arrearsBean.stPaidData;
                    double classArrears= Double.Parse(arrearsBean.curArrears);
                    totalDatatable.Rows[i][COLUMN_CLASS] = classCode;
                    totalDatatable.Rows[i][COLUMN_ARREARS] = classArrears;
                    totalDatatable.Rows[i][COLUMN_TOTAL_PAID] = arrearsBean.feePaidForTheYear;
                    currArrears += classArrears;
                    totalPaid += arrearsBean.feePaidForTheYear;
                    stBeanList.Add(arrearsBean);
                    backgroundWorker1.ReportProgress((i+1)/(ClassLen+1)*100);
                }               
                
                
                //Data Table end
                
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
