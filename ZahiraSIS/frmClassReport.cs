using Microsoft.Office.Interop.Excel;
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
    public partial class frmClassReport : Form
    {

        dbConnector dbCon;
        public frmClassReport()
        {
            InitializeComponent();
            Console.WriteLine("Accessed Class Report");
        }

        private void frmClassReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zahira_SISDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.zahira_SISDataSet.student);
            // TODO: This line of code loads data into the 'zahira_SISDataSet.stuclass' table. You can move, or remove it, as needed.
            this.stuclassTableAdapter.Fill(this.zahira_SISDataSet.stuclass);

        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {

            Console.WriteLine("Selected index:" +cmbClass.SelectedValue.ToString());
            dbCon = new dbConnector();
            txtTeacherName.Text = dbCon.getTeacherName(cmbClass.SelectedValue.ToString());
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                object ParameterName = new object();
                this.studentTableAdapter.FillBy(this.zahira_SISDataSet.student, ParameterName);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByClassToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.studentTableAdapter.FillByClass(this.zahira_SISDataSet.student, new System.Nullable<int>(((int)(System.Convert.ChangeType(txtClassKey.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportToExcel();        
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void ExportToExcel()
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
                for (int i = 0; i < grdStudents.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grdStudents.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grdStudents.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grdStudents.Rows[i].Cells[j].Value.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                this.studentTableAdapter.FillByClass(this.zahira_SISDataSet.student, new System.Nullable<int>(((int)(System.Convert.ChangeType(txtClassKey.Text, typeof(int))))));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtClassKey_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stuclassBindingSource_CurrentChanged(object sender, EventArgs e)
        {

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
    }
}
