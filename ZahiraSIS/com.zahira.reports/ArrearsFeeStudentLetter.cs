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

namespace ZahiraSIS.com.zahira.reports
{
    public partial class ArrearsFeeStudentLetter : Form
    {
        private volatile DataTable totalDatatable = null;
        private double currArrears = 0;
        private double totalPaid = 0;
        ClassDAO clsDao = new ClassDAO();
        int selectedClass1 = 0;

        public ArrearsFeeStudentLetter()
        {
            InitializeComponent();
        }

        private void ArrearsFeeStudentLetter_Load(object sender, EventArgs e)
        {          
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedClass1 = (int)cmbClass.SelectedValue;
            //tsStatus.Text = "User Cancelled";

            //tblStudents.DataSource = null;
            tblStudents.Refresh();
           

            if (!backgroundWorker1.IsBusy)
            {
                tblStudents.Rows.Clear();

                button4.Enabled = false;
                button3.Enabled = true;
                StudentArrearsBean arrearsBean = new StudentArrearsBean();
                backgroundWorker1.RunWorkerAsync(arrearsBean);
            }
        }

       
        private void backgroundWorker1_ProgressChanged_1(object sender, ProgressChangedEventArgs e)
        {

            if (!backgroundWorker1.CancellationPending)
            {
                StudentArrearsBean bean = (StudentArrearsBean)e.UserState;
                if (bean != null)
                {
                    if (Double.Parse(bean.curArrears) >= 0) { 
                    tblStudents.Rows.Add(bean.admNo, bean.studentName, bean.classCode, bean.curArrears, bean.feePaidForTheYear, bean.paidTill.ToString("dd-MMM-yyyy"));
                    currArrears += Double.Parse(bean.curArrears);
                    totalPaid += bean.feePaidForTheYear;
                }
                }
                tsStatus.Text = e.ProgressPercentage + "%";
                progressBar1.Value = e.ProgressPercentage;
                
            }
        }

        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                //TODO fill datatable with Lists. also check the date range.
                //tblStudents.Refresh();
                // tblStudents.DataSource = totalDatatable;
                tblStudents.Refresh();                
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

       

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                button3.Enabled = false;
                button2.Enabled = true;
            }
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
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
                        string name = classwiseStudents.Rows[i]["name"].ToString().Trim();
                        try
                        {
                            arrearsBean = studentDAO.NewForwardBalance(admno, classCode, DateTime.Parse(todate), false, false);

                            if (arrearsBean == null)
                            {
                                //Student on fee concession.
                                arrearsBean.curArrears = "0";
                                arrearsBean.feePaidForTheYear = 0;
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
    }
}
