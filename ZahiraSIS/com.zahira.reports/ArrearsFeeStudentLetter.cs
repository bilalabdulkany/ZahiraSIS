

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ZahiraSIS.com.zahira.bean.student;

using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace ZahiraSIS.com.zahira.reports
{
    public partial class ArrearsFeeStudentLetter : Form
    {
        private volatile System.Data.DataTable totalDatatable = null;
        private double currArrears = 0;
        private double totalPaid = 0;
        ClassDAO clsDao = new ClassDAO();
        int selectedClass1 = 0;
        string path = null;

        public ArrearsFeeStudentLetter()
        {
            InitializeComponent();
            path = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"Templates\StudentArrearsLetterTemplate.doc");
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
            totalDatatable = new System.Data.DataTable();
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Word.Application ap = new Microsoft.Office.Interop.Word.Application();
            
            Microsoft.Office.Interop.Word.Document document = ap.Documents.Open(path);
        }


        //WORD PROCESSING

        //Methode Find and Replace:
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }



        string pathImage = "TEST11";
        private string tArrearsAsAt = "TEST11";
        private string tFeePaid = "TEST11";
        private string tFeeBalance = "TEST11";
        private string tParentName = "TEST11";
        private string tStudentAddress = "TEST11";
        private string tStudentName = "TEST11";
        private string tAdmno = "TEST11";
        private string tClassCode = "TEST11";
        private string tMedium = "TEST11";
        private string tArrearsAmount = "TEST11";
        private string tFeeBeginMon = "TEST11";
        private string tFeeEndMon = "TEST11";
        private string tFeeBeginToEndMon = "TEST11";
        private string tPayBefore = "TEST11";
        //Methode Create the document :
        private void CreateWordDocument(object filename, object savaAs, object image)
        {
            List<int> processesbeforegen = getRunningProcesses();
            object missing = Missing.Value;
            string tempPath = null;

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            Microsoft.Office.Interop.Word.Document aDoc = null;

            if (File.Exists((string)filename))
            {
                DateTime today = DateTime.Now;

                object readOnly = false; //default
                object isVisible = false;

                wordApp.Visible = false;

                aDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing,
                                            ref missing, ref missing, ref missing, ref missing);

                aDoc.Activate();

                //Find and replace:
                this.FindAndReplace(wordApp, "CurrentDate", DateTime.Now.ToShortDateString());
                this.FindAndReplace(wordApp, "Parent's Name", tParentName);
                this.FindAndReplace(wordApp, "Student Address", tStudentAddress);
                this.FindAndReplace(wordApp, "Student Name", tStudentName);
                this.FindAndReplace(wordApp, "Admission No.", tAdmno);
                this.FindAndReplace(wordApp, "Class Code", tClassCode);
                this.FindAndReplace(wordApp, "Medium Name", tMedium);
                this.FindAndReplace(wordApp, "Arrears as at date as \"dd/mm/yyyy\"", tArrearsAsAt);
                this.FindAndReplace(wordApp, "Arrears amount", tArrearsAmount);
                this.FindAndReplace(wordApp, "Fees begin month as \"month yyyy\"", tFeeBeginMon);
                this.FindAndReplace(wordApp, "Fees end month as \"month yyyy\"", tFeeEndMon);
                this.FindAndReplace(wordApp, "Fees amount from begin month to end month", tFeeBeginToEndMon);
                this.FindAndReplace(wordApp, "Fees paid amount for period", tFeePaid);
                this.FindAndReplace(wordApp, "Balance amount to be paid", tFeeBalance);
                this.FindAndReplace(wordApp, "PayBefore", tFeeBalance);


                //insert the picture:
                /* Image img = resizeImage(pathImage, new Size(200, 90));
                 tempPath = System.Windows.Forms.Application.StartupPath + "\\Images\\~Temp\\temp.jpg";
                 img.Save(tempPath);

                 Object oMissed = aDoc.Paragraphs[1].Range; //the position you want to insert
                 Object oLinkToFile = false;  //default
                 Object oSaveWithDocument = true;//default
                 aDoc.InlineShapes.AddPicture(tempPath, ref  oLinkToFile, ref  oSaveWithDocument, ref oMissed);
 */
                #region Print Document :
                /*object copies = "1";
                object pages = "1";
                object range = Word.WdPrintOutRange.wdPrintCurrentPage;
                object items = Word.WdPrintOutItem.wdPrintDocumentContent;
                object pageType = Word.WdPrintOutPages.wdPrintAllPages;
                object oTrue = true;
                object oFalse = false;

                Word.Document document = aDoc;
                object nullobj = Missing.Value;
                int dialogResult = wordApp.Dialogs[Microsoft.Office.Interop.Word.WdWordDialog.wdDialogFilePrint].Show(ref nullobj);
                wordApp.Visible = false;
                if (dialogResult == 1)
                {
                    document.PrintOut(
                    ref oTrue, ref oFalse, ref range, ref missing, ref missing, ref missing,
                    ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                    ref missing, ref oFalse, ref missing, ref missing, ref missing, ref missing);
                }
                */
                #endregion

            }
            else
            {
                MessageBox.Show("file dose not exist.");
                return;
            }

            //Save as: filename
            aDoc.SaveAs2(ref savaAs, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing);

            //Close Document:
            aDoc.Close(ref missing, ref missing, ref missing);
            if (tempPath != null) File.Delete(tempPath);
            MessageBox.Show("File created.");
            List<int> processesaftergen = getRunningProcesses();
            killProcesses(processesbeforegen, processesaftergen);
        }


        public List<int> getRunningProcesses()
        {
            List<int> ProcessIDs = new List<int>();
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcesses())
            {
                //Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Names.txt")

                if (Process.GetCurrentProcess().Id == clsProcess.Id)
                    continue;
                if (clsProcess.ProcessName.Contains("WINWORD"))
                {
                    ProcessIDs.Add(clsProcess.Id);
                }
            }
            return ProcessIDs;
        }


        private void killProcesses(List<int> processesbeforegen, List<int> processesaftergen)
        {
            foreach (int pidafter in processesaftergen)
            {
                bool processfound = false;
                foreach (int pidbefore in processesbeforegen)
                {
                    if (pidafter == pidbefore)
                    {
                        processfound = true;
                    }
                }

                if (processfound == false)
                {
                    Process clsProcess = Process.GetProcessById(pidafter);
                    clsProcess.Kill();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SaveDoc.ShowDialog() == DialogResult.OK)
            {
                CreateWordDocument(path, SaveDoc.FileName, pathImage);
                //tEnabled(false);
                //printDocument1.DocumentName = SaveDoc.FileName;
            }
        }
    }
}
