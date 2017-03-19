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
            tblStudents.ColumnCount = 5;
            tblStudents.Columns[0].Name = "Admno";
            tblStudents.Columns[1].Name = "Name";
            tblStudents.Columns[2].Name = "Class";
            tblStudents.Columns[3].Name = "Arrears";
            tblStudents.Columns[4].Name = "Fee Paid for the year";
            


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

            //tblStudents.DataSource = null;
            tblStudents.Refresh();
            txtCurArrears.Text = "0";
            txtCurBFArrears.Text = "0";
           
            if (!backgroundWorker1.IsBusy)
            {
                tblStudents.Rows.Clear();

                button2.Enabled = false;
                button3.Enabled = true;
                StudentArrearsBean arrearsBean = new StudentArrearsBean();
                backgroundWorker1.RunWorkerAsync(arrearsBean);
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
            bool logging = true;
            
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
                //TODO run this inside a thread and ask the method to report progress.

                //StudentArrearsBean arrearsBean = studentDAO.getStudentArrearsByDatePerClass(classCode,              fromdate, todate,true);

                /**
                 * TODO add the StudentDAO implementation here.
                 **/
                var classwiseStudents = studentDAO.getStudentIndexFromClass(classCode);
                StudentArrearsBean arrearsBean = null;//new StudentArrearsBean();
                StudentArrearsBean aBean = (StudentArrearsBean)e.Argument;
                //############################################################
                if (!backgroundWorker1.CancellationPending)
                    for (int i = 0; i < classwiseStudents.Rows.Count; i++)
                {
                    string admno = classwiseStudents.Rows[i]["admno"].ToString().Trim();
                    string name= classwiseStudents.Rows[i]["name"].ToString().Trim();
                    try
                    {
                        arrearsBean = studentDAO.NewForwardBalance(admno, classCode, DateTime.Parse(todate), false, false);
                       
                        if(arrearsBean==null)
                        {
                            //Student on fee concession.
                            arrearsBean.curArrears = "0";
                            arrearsBean.feePaidForTheYear =0;
                            arrearsBean.paidTill = new DateTime();
                            //classwiseStudents.Rows[i][COLUMN_TOTAL_PAID] = "0";
                            //cumArrears = 0;
                            //totalPaid = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("e:" + ex);
                    }
                    //Report Progress
                    aBean.admNo = admno;
                    aBean.studentName = name;
                    aBean.classCode = classCode;
                    aBean.curArrears = arrearsBean.curArrears;
                    aBean.feePaidForTheYear = arrearsBean.feePaidForTheYear;
                    aBean.paidTill = arrearsBean.paidTill;
                 //   int k = 0;
                    // totalDatatable = arrearsBean.stPaidData;
                    int count = classwiseStudents.Rows.Count;
                    decimal pct = ((decimal)i * 100 / (decimal)(count - 1));
                    int pct1 = Convert.ToInt32(pct);
                    backgroundWorker1.ReportProgress(pct1, aBean);

                    if (backgroundWorker1.CancellationPending)
                    {
                        // Set the e.Cancel flag so that the WorkerCompleted event
                        // knows that the process was cancelled.
                        e.Cancel = true;
                        backgroundWorker1.ReportProgress(0);
                        return;
                    }

                }//end of for loop
                //############################################################
                

               
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
           
            if (!backgroundWorker1.CancellationPending)
            {
                StudentArrearsBean bean = (StudentArrearsBean)e.UserState;
                if (bean != null)
                {
                    tblStudents.Rows.Add(bean.admNo,bean.studentName,bean.classCode, bean.curArrears, bean.feePaidForTheYear, bean.paidTill.ToString("dd-MMM-yyyy"));
                    currArrears += Double.Parse(bean.curArrears);
                    totalPaid += bean.feePaidForTheYear;
                }
                tsStatus.Text = e.ProgressPercentage + "%";
                progressBar1.Value = e.ProgressPercentage;
                txtCurArrears.Text = currArrears + "";
                txtCurBFArrears.Text = totalPaid + "";
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                //TODO fill datatable with Lists. also check the date range.
                //tblStudents.Refresh();
               // tblStudents.DataSource = totalDatatable;
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
