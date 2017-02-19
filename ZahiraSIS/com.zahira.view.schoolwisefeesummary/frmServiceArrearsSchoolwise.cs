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
        public readonly String COLUMN_CLASS = "Class";
        public readonly String COLUMN_TOTAL_PAID = "Total Fee paid this year";
        public readonly String COLUMN_ARREARS = "Arrears";
        public frmServiceArrearsSchoolwise()
        {
            InitializeComponent();
            Console.WriteLine("Accessed School Total Arrears");
            backgroundWorker1.WorkerReportsProgress = true;
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
          
            btCancel.Enabled = false;
            tblStudents.ColumnCount = 3;
            tblStudents.Columns[0].Name=COLUMN_CLASS;
            tblStudents.Columns[1].Name = COLUMN_ARREARS;
            tblStudents.Columns[2].Name = COLUMN_TOTAL_PAID;
            
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
           
            if (!backgroundWorker1.IsBusy)
            {
                StudentArrearsBean arrearsBean = new StudentArrearsBean();
                tblStudents.Rows.Clear();
                btExecute.Enabled = false;
                btCancel.Enabled = true;
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
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                    btCancel.Enabled = false;
                    btExecute.Enabled = true;
                }
                e.Cancel = true;
                Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbClassType_SelectedIndexChanged(object sender, EventArgs e)
        {
          

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
                

                int ClassLen = AllClasses.Rows.Count;
                for (int i = 0; i < ClassLen; i++) {
                    string classCode = AllClasses.Rows[i]["classcode"].ToString().Trim();
                    
                    StudentArrearsBean arrearsBean = dao.getStudentArrearsByDatePerClass(classCode,
                        fromdate, todate, true);
                    StudentArrearsBean aBean = (StudentArrearsBean)e.Argument;
                    //totalDatatable = arrearsBean.stPaidData;
                        double classArrears = Double.Parse(arrearsBean.curArrears);
                      
                        try
                        {
                            
                            //totalDatatable.Rows[i][COLUMN_CLASS] = classCode.ToString().Trim();
                       
                                aBean.classCode = classCode;
                                aBean.curArrears = arrearsBean.curArrears;
                                aBean.feePaidForTheYear = arrearsBean.feePaidForTheYear;
                        decimal pct = ((decimal)i*100 / (decimal)(ClassLen-1));
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


                    }
                        catch (Exception e1) {
                            Console.WriteLine(e1); 
                           
                        }
                            currArrears += classArrears;

                        totalPaid += arrearsBean.feePaidForTheYear;
                        stBeanList.Add(arrearsBean);
                    
                        //backgroundWorker1.ReportProgress((i+1)/(ClassLen+1)*100);
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
            if (!backgroundWorker1.CancellationPending)
            {
                StudentArrearsBean bean = (StudentArrearsBean)e.UserState;
                if (bean != null) { 
                tblStudents.Rows.Add(bean.classCode, bean.curArrears, bean.feePaidForTheYear);
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
                if (e.Cancelled)
                {
                    tsStatus.Text = "Cancelled by User Intentionally...";
                    progressBar1.Value = 0;
                }
                else if (e.Error != null)
                {
                    //TODO fill datatable with Lists. also check the date range.
                    //tblStudents.Refresh();
                    //tblStudents.DataSource = totalDatatable;
                    tblStudents.Refresh();
                    txtCurArrears.Text = currArrears + "";
                    txtCurBFArrears.Text = totalPaid + "";
                    currArrears = 0;
                    totalPaid = 0;
                }
                btExecute.Enabled = true;
                btCancel.Enabled = false;


            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                btCancel.Enabled = false;
                btExecute.Enabled = true;
            }
        }
    }
}
