using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZahiraSIS
{
    public partial class frmServiceFeeYrSummary : Form
    {

        StudentDAO dao = new StudentDAO();
        static DataTable dt = new DataTable();
        bool isEnterPressed = false;
        private static string classCode = "";
        private int keyClass = 0;

        public frmServiceFeeYrSummary()
        {
            InitializeComponent();
            Console.WriteLine("Accessed Service Fee Yearly");
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'zahira_SISDataSet.student' table. You can move, or remove it, as needed.
                this.studentTableAdapter.Fill(this.zahira_SISDataSet.student);
                // TODO: This line of code loads data into the 'zahira_SISDataSet.stuclass' table. You can move, or remove it, as needed.
                this.stuclassTableAdapter.Fill(this.zahira_SISDataSet.stuclass);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        /**
         * When selecting admission numbers from the comboBox2.
         */
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
             setName();
            //fillTable();

            dtStudentArrears.DataSource = null;
            dtStudentArrears.Refresh();

        }

        /**
         * When enter key is pressed in the comboBox2 after entering admission no. 
         */
        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                isEnterPressed = true;
                dtStudentArrears.DataSource = null;
                dtStudentArrears.Refresh();   
                Console.WriteLine("on key press");
                // String className = dao.getStudentClasses((int)comboBox2.SelectedValue).Name;
                //comboBox1.Text = className;
                setName();
            
                fillTable();
                //
               


            }

        }

        /*
         * When the comboBox1 is changed.
         */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtStudentArrears.DataSource = null;
            dtStudentArrears.Refresh();
            
           
            setName();
            if (!isEnterPressed) { 
            comboBox2.DataSource = dao.getStudentIndexFromClass(keyClass + "").DefaultView;
            comboBox2.DisplayMember = "admno";
            comboBox2.DisplayMember.Trim();
            comboBox2.ValueMember = "name";
        }
        }

        /*
         * When the View Result button is clicked.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            setName();
            fillTable();
            isEnterPressed = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /**
         * Fill the data table from the comboBox2 admission number,
         * then fill the latest fee payments on the textboxes.
         **/
        private void fillTable() {
            String admno = "";

            try
            {
                admno = comboBox2.Text.Trim();
                dt = dao.getStudentArrearsByIndex(admno);
                dtStudentArrears.DataSource = dt;
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                double feeRate = 0;

                DateTime paidTill = (DateTime)lastRow["payto"];
                DateTime paidTo = paidTill;
                DateTime todayDate = DateTime.Now;

               int dateDifference = todayDate.Year - paidTo.Year;
                //if dateDifference>=1
                double feesArrears = 0;
                for (int i=todayDate.Year;i>=paidTill.Year;i-- )
                {
                    Console.WriteLine("today:" +i);
                    Console.WriteLine("till:" + paidTill.Year);
                    Console.WriteLine("class code:" + classCode);
                    //Get the grade from the students records. check primary or secondary or senior.
                    //dao.getStudentClasses((int)lastRow["key_class"]).Code;

                    string guessedClass = classCode.Substring(classCode.Length - 1, classCode.Length);
                    Console.WriteLine("guessed class: " + guessedClass);
                    if (i == paidTill.Year)
                    {
                        //If for current years' arrears.
                        int paidMonth = paidTill.Month + 1;
                        if (paidMonth > 12)
                        {
                            paidMonth = paidMonth%12;
                        }
                        int thisMonth = DateTime.Now.Month;
                        int monthDiff = (thisMonth - paidMonth);
                        if (monthDiff < 0)
                        {
                            monthDiff = -(monthDiff);
                        }
                        feeRate = Double.Parse(lastRow["mfeerate"] + "");
                        feesArrears = feeRate*((thisMonth - paidMonth));
                    }
                    else
                    {
                        //If for other years' arrears.
                        int feecode = dao.getStudentClasses(keyClass).Key_fee;
                        
                        //get the grades in order and check if primary, secondary or senior.
                        //calculate the rates with respect to the effective year fee.         
                        feeRate = (double)dao.getMonthFeeRevision(feecode, i + "").Rows[0]["amount"];
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Date Diff:"+dateDifference);
                    
                int paidYear = paidTill.Year;
                int thisYear = DateTime.Now.Year;
                int yearDiff = thisYear - paidYear;
                paidTill = paidTill.AddMonths(1);
                lblArrearsDate.Text = paidTill.ToString("dd-MMM-yyyy");
               

                string arrearsToDate = lastRow["payto"] + "";
                txtFees.Text = feeRate + "";
                if (paidTill.Year > DateTime.Now.Year|| feesArrears<0) {
                    feesArrears = 0;
                }
                txtArrearsToDate.Text = feesArrears + "";
                comboBox1.Text = dao.getStudentClasses((int)lastRow["key_class"]).Name;
                classCode = dao.getStudentClasses((int)lastRow["key_class"]).Code;
                txtClassCode.Text = classCode;
            }
            catch (Exception e1)
            {
                Console.WriteLine("error: " + e1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dtStudentArrears);            
        }

        /**
         * Set the name of the student in the textbox from the comboBox2
         **/
        private void setName()
        {
            String name = "";
            keyClass = (int)comboBox1.SelectedValue;
            Console.WriteLine("Selected class:" + keyClass);

            //select * from student where key_class='191'

            classCode = dao.getStudentClasses(keyClass).Code + "";
            txtClassCode.Text = classCode;
            try
            {
                if(comboBox2.Text!="")
                name = dao.getStudentInfoFromIndex(comboBox2.Text).Name;
                txtName.Text = name.Trim();
            }
            catch (Exception e1)
            {
                Console.WriteLine("null exception:" + e1);
            }
        }

        /**
         * Export to Excel
         */
        private void ExportToExcel(DataGridView grd)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < grd.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grd.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grd.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
    }
}
