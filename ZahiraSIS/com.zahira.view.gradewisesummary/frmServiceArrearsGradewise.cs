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
    public partial class frmServiceArrearsGradewise : Form
    {
        private volatile DataTable totalDatatable = null;
        private  double currArrears = 0;
        private double totalPaid = 0;

        ClassDAO clsDao = new ClassDAO();
        public frmServiceArrearsGradewise()
        {
            InitializeComponent();
            Console.WriteLine("Accessed Gradewise Service Arrears");
            cmbMedium.SelectedIndex = -1;
            //backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            //backgroundWorker1.ProgressChanged+=backgroundWorker1_ProgressChanged;
            //backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;


        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            chkSelectedClasses.Refresh();

        }

        private void frmServiceArrearsGradewise_Load(object sender, EventArgs e)
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

            cmbClass.DataSource = clsDao.GetGrades();
            cmbClass.DisplayMember = "name";
            cmbClass.ValueMember = "key_fld";
            cmbClass.Refresh();

            cmbMedium.DataSource = clsDao.GetMedium();
            cmbMedium.DisplayMember = "name";
            cmbMedium.ValueMember = "key_fld";
            cmbMedium.Refresh();
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
            tsStatus.Text = "User Cancelled";
            tblStudents.DataSource = null;
            tblStudents.Refresh();
            txtCurArrears.Text = "";
            txtCurBFArrears.Text = "";
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
            new Common().ExportToExcel(tblStudents,Double.Parse(txtCurArrears.Text),Double.Parse(txtCurBFArrears.Text));

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
            cmbClass.DataSource = clsDao.GetGrades();
            cmbClass.DisplayMember = "name";
            cmbClass.ValueMember = "key_fld";
            cmbClass.Refresh();

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void cmbMedium_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkSelectedClasses.Refresh();
            if (cmbClass.SelectedValue != null) {
                try
                {
                    int grade = int.Parse(cmbClass.SelectedValue.ToString());
                    int medium = int.Parse(cmbMedium.SelectedValue.ToString());
                    Console.WriteLine("selected grade: " + grade + " medium: " + medium);
                    ((ListBox)chkSelectedClasses).DataSource = clsDao.GetClassByGrade(grade, medium);
                    ((ListBox)chkSelectedClasses).DisplayMember = "sname";
                    ((ListBox)chkSelectedClasses).ValueMember = "sfield";
                }
                catch (Exception ex) {
                    Console.WriteLine("excepion", ex);
                }
        }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
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
                    
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

                tsStatus.Text = "Done";               
            }
            else if (e.Cancelled)
            {
                tsStatus.Text = "User Cancelled";
                tblStudents.Refresh();
                txtCurArrears.Text = currArrears + "";
                totalDatatable.Reset();
            }
            else {
                tsStatus.Text = "An Error Occurred";               
            }
            button2.Enabled = true;
            button3.Enabled = false;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            tsStatus.Text = e.ProgressPercentage + "%";
            progressBar1.Value = e.ProgressPercentage;


        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           // DataGridView view = tblStudents;
            BackgroundWorker sendingWorker = (BackgroundWorker)sender;
            totalDatatable = new DataTable();
            progressBar1.BeginInvoke((MethodInvoker)delegate ()
            {
                progressBar1.Value = 0;
                backgroundWorker1.ReportProgress(0);
                progressBar1.Refresh();

            });
           
                tsStatus.Text = "Loading...";
                string fromdate = null;
                string todate = null;
                if (dateTimePicker2.Value != null)
                {
                    todate = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                }

              
                
                StudentDAO studentDAO = new StudentDAO();
              //  var totalDatatable = new DataTable();
                totalDatatable.Columns.Add("Class");
                totalDatatable.Columns.Add("Arrears");
               // double curArrears = 0;
                int count = chkSelectedClasses.CheckedItems.Count;
            int k = 0;
            foreach (object itemChecked in chkSelectedClasses.CheckedItems)
                {
                if (!sendingWorker.CancellationPending)
                {
                    
                    progressBar1.BeginInvoke((MethodInvoker)delegate ()
                    {

                        backgroundWorker1.ReportProgress((k * 100) / count);

                        progressBar1.Refresh();

                    });
                    DataRowView castedItem = itemChecked as DataRowView;
                    int selectedClass1 = (int)castedItem["sfield"];//nt)cmbClass.SelectedValue;
                    string selectedText = (string)castedItem["sname"];
                    Console.WriteLine("item:" + selectedClass1 + " text:" + selectedText);


                    string classCode = (studentDAO.getStudentClasses(selectedClass1).Code).Trim();
                    StudentArrearsBean arrearsBean = studentDAO.getStudentArrearsByDatePerClass(classCode,
                        fromdate, todate);
                    DataRow row = totalDatatable.NewRow();
                    currArrears += Double.Parse(arrearsBean.curArrears);
                    totalPaid += arrearsBean.feePaidLastYear;
                    row["Class"] = selectedText;
                    row["Arrears"] = arrearsBean.curArrears;
                    // tblStudents.DataSource = arrearsBean.stPaidData;               
                    totalDatatable.Rows.Add(row);
                    k++;
                    

                }
                else
                {
                    e.Cancel = true;
                    break;
                }
            }

            backgroundWorker1.ReportProgress(100);
            /*  }
              else {
                  e.Cancel = true;                
              }
             */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
