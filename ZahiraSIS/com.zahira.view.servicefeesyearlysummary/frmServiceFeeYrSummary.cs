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
        private static String classCode = null;
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

           // setName();
           Console.WriteLine("is enter key pressed: "+isEnterPressed);

            if (!isEnterPressed) {
                //user did not click enter but selected from the list.
                Console.WriteLine(comboBox1.SelectedValue.ToString());
                keyClass = (int)comboBox1.SelectedValue;
                //keyClass = dao.getStudentInfoFromIndex(comboBox2.Text.Trim()).Key_class;
                classCode = (dao.getStudentClasses(keyClass).Code + "").Trim();
                txtClassCode.Text = classCode;
                comboBox2.DataSource = dao.getStudentIndexFromClass(keyClass + "").DefaultView;
            comboBox2.DisplayMember = "admno";
            comboBox2.DisplayMember.Trim();
            comboBox2.ValueMember = "name";
           
                
            }
            if (isEnterPressed)
                isEnterPressed = false;


        }

        /*
         * When the View Result button is clicked.
         */
        private void button2_Click(object sender, EventArgs e)
        {
            setName();
            fillTable();
            if(isEnterPressed)
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
            //TODO should display current year in the text boxes. Then must get the paid till year and continue adding for subsequent years.
            //only current year and paid till grades are known.
            String admno = "";
            Double feesArrears = 0;
            try
            {
                admno = comboBox2.Text.Trim();
                dt = dao.getStudentArrearsByIndex(admno);
                dtStudentArrears.DataSource = dt;
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                //comboBox1.Text = dao.getStudentClasses((int)lastRow["key_class"]).Name;
                classCode = dao.getStudentClasses((int) lastRow["key_class"]).Classcode;
                double feeRate = 0;

                DateTime paidTill = (DateTime)lastRow["payto"];
                DateTime paidTo = paidTill;
                DateTime todayDate = DateTime.Now;

               int dateDifference = todayDate.Year - paidTo.Year;
                //if dateDifference>=1
                int countYear = 0;
                for (int i=todayDate.Year;i>=paidTill.Year;i-- )
                {
                    countYear++;
                    Console.WriteLine("today:" +i);
                    Console.WriteLine("till:" + paidTill.Year);
                    classCode = dao.getStudentClasses((int) comboBox1.SelectedValue).Code.Trim();
                    Console.WriteLine("class code:" + classCode+" length:"+classCode.Trim().Length);
                    
                    //Get the grade from the students records. check primary or secondary or senior.
                   char guessedClass = classCode[classCode.Length - 2];
                int grade = int.Parse(classCode[classCode.Length - 3]+"");
                    Console.WriteLine("Current grade:"+grade+" adding:"+(countYear-1));
                    Console.WriteLine("guessed class: " + guessedClass);
                    if (i == paidTill.Year)//i == paidTill.Year&&
                    {

                        //If for current years' arrears.
                        //if paid till is not current year??
                        if (paidTill.Year == todayDate.Year)
                        {
                            Console.WriteLine("calculating fee arrears for the current years'" +
                                              " Arrears: "+feesArrears);
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
                            feesArrears = feeRate*((thisMonth - paidMonth)) + feesArrears;
                        }
                        else
                        {
                            int paidMonth1 = paidTill.Month;
                            if (paidMonth1 != 12 && paidMonth1 < 12)
                            {
                                paidMonth1 = 12 - paidMonth1;
                                feeRate = Double.Parse(lastRow["mfeerate"] + "");
                                feesArrears = feeRate * paidMonth1 + feesArrears;

                            }
                        }
                        Console.WriteLine("fee is not paid fully for the year "+i+": "+feesArrears);
                       
                    }
                    else
                    {
                        //If for other years' arrears.
                        //Check the medium and then guess the key_fee.
                        Console.WriteLine("Calculating fee for other years.");
                        //int feecode = dao.getStudentClasses(keyClass).Key_fee;

                        //get the grades in order and check if primary, secondary or senior.
                        //calculate the rates with respect to the effective year fee. 
                        //Also check student concessions.  
                        string input = Prompt.ShowDialog("ClassCode: "+classCode+" Years: "+countYear+"-grade:"+grade, "Year: " + i);
                        feeRate =
                              double.Parse(
                                  dao.getMonthFeeRevision(int.Parse(input.Trim()), i + "").Rows[0]["amount"].ToString());

                        Console.WriteLine(input.Trim() + " with arrears: " + feesArrears+" feeRate:"+feeRate);
                        if (i == todayDate.Year)
                        {
                            int paidMonth = paidTill.Month + 1;
                            if (paidMonth > 12)
                            {
                                paidMonth = paidMonth % 12;
                            }
                            int thisMonth = DateTime.Now.Month;
                            int monthDiff = (thisMonth - paidMonth);
                            if (monthDiff < 0)
                            {
                                monthDiff = -(monthDiff);
                            }


                               feesArrears = feeRate * ((thisMonth - paidMonth)) + feesArrears;

                        }
                        else
                        {
                           
                           
                            feesArrears = feeRate*12 + feesArrears;
                        }
                        Console.WriteLine("Fee rate: " + feeRate + " Arrears: " + feesArrears);

                    }
                }
                
                paidTill = paidTill.AddMonths(1);
                if (paidTill.Year > DateTime.Now.Year || feesArrears < 0)
                {
                    Console.WriteLine("resetting to 0");
                    if (dateDifference == 0)
                    {
                        feesArrears = 0;
                    }
                }
                Console.WriteLine("Date Diff:"+dateDifference+" arrears: "+feesArrears);
                    
                //int paidYear = paidTill.Year;
                //int thisYear = DateTime.Now.Year;
               // int yearDiff = thisYear - paidYear;
                
                lblArrearsDate.Text = paidTill.ToString("dd-MMM-yyyy");
               

                string arrearsToDate = lastRow["payto"] + "";
                txtFees.Text = feeRate + "";
               
                txtArrearsToDate.Text = feesArrears + "";
                
                Console.WriteLine("resetting class code:"+classCode);
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
            txtClassCode.Text = "";
            txtArrearsToDate.Text = "";
            txtFees.Text = "";
            txtName.Text = "";
            lblArrearsDate.Text = "";
            String name = "";

            if (comboBox2.Text.Trim()!="")
            {
                try
                { //the index
                
                    /*
               
               */

                    name = dao.getStudentInfoFromIndex(comboBox2.Text).Name;
                    txtName.Text = name.Trim();
                }
                catch (Exception e1)
                {
                    Console.WriteLine("null exception:" + e1);
                }
            }
            //(int)comboBox1.SelectedValue;
            if (isEnterPressed)
            {
                try
                {
                    keyClass = dao.getStudentInfoFromIndex(comboBox2.Text.Trim()).Key_class;
                    comboBox1.Text = dao.getStudentClasses(keyClass).Name;
                }
                catch (Exception e)
                {
                    comboBox1.Text = "";
                }
            }
                Console.WriteLine("Selected class:" + keyClass);

            //select * from student where key_class='191'

          
           
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

    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 170,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 15,Width = 350,Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
