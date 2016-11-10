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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            String name = "";
            try
            {
                name = comboBox2.SelectedValue.ToString();
                txtName.Text = name.Trim();
            }
            catch (Exception e1)
            {
                Console.WriteLine("null exception:" + e1);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        static DataTable dt = new DataTable();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String keyClass = comboBox1.SelectedValue.ToString();
            Console.WriteLine("Selected class:" + keyClass);
            //select * from student where key_class='191'
            StudentDAO dao = new StudentDAO();

                       
            comboBox2.DataSource = dao.getStudentIndexFromClass(keyClass).DefaultView;
            comboBox2.DisplayMember = "admno";
            comboBox2.DisplayMember.Trim();
            comboBox2.ValueMember = "name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String admno = "";
            StudentDAO dao = null;
            try
            {
                dao = new StudentDAO();
                admno = comboBox2.Text.Trim();                
                dt = dao.getStudentArrearsByIndex(admno);
                dtStudentArrears.DataSource = dt;

               
                DataRow lastRow = dt.Rows[dt.Rows.Count - 1];
                double feeRate = Double.Parse(lastRow["mfeerate"] + "");

                DateTime paidTill = (DateTime)lastRow["payto"];
                int paidMonth = paidTill.Month+1;
                int thisMonth = DateTime.Now.Month;
                Console.WriteLine("paid month:" + paidMonth + " today's month:" + thisMonth+" rate:"+feeRate);
                double feesArrears = feeRate * (thisMonth - paidMonth);

               paidTill= paidTill.AddMonths(1);
                lblArrearsDate.Text = paidTill.ToString("dd-MMM-yyyy");
                string arrearsToDate = lastRow["payto"] + "";                
                txtFees.Text= feeRate + "";
                txtArrearsToDate.Text = feesArrears +"";

            }
            catch (Exception e1)
            {
                Console.WriteLine("error: " + e1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel(dtStudentArrears);
            //try
            //{
            //   XLWorkbook wb = new XLWorkbook();
            //    wb.Worksheets.Add(dt, "Student Arrears");
            //    wb.SaveAs("F:\\Zahira SIS\\" + "DataGridViewExport.xlsx");
            //}
            //catch (Exception ex) {
            //    Console.WriteLine(ex);
            //}

        }

        /**
         * Move this to common
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
