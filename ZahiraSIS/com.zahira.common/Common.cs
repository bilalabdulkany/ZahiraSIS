using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZahiraSIS.com.zahira.common
{
    class Common
    {
        /**
        * Export to Excel
        */
        public void ExportToExcel(DataGridView grd,double fullArrears,double lastYearPay,String grade)
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;

                worksheet.Name = "ExportedFromDatGrid";

                int cellRowIndex = 4;
                int cellColumnIndex = 1;
                int i = 0;
                //Loop through each row and read value from each column. 
                for (i=0; i < grd.Rows.Count; i++)
                {
                    if (cellRowIndex-1 == 3)
                    {
                        worksheet.Cells[cellRowIndex-1, cellColumnIndex] = "Grade: " + grade;
                    }
                    
                        for (int j = 0; j < grd.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                         if (cellRowIndex ==4)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grd.Columns[j].HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grd.Rows[i-1].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }
                // i++;
                //
               //Range cells = workbook.Worksheets[1].Cells;
                //cells.Cells[1,1].EntireColumn.NumberFormat = "@";
                worksheet.Columns[1].NumberFormat = "@";
                worksheet.Cells[cellRowIndex + 4, cellColumnIndex+1] = "Full Arrears: ";
                worksheet.Cells[cellRowIndex + 4, cellColumnIndex + 2] = fullArrears;
                worksheet.Cells[cellRowIndex + 4, cellColumnIndex+1].Font.Bold = true;
                worksheet.Cells[cellRowIndex + 4, cellColumnIndex + 2].Font.Bold = true;
                


                worksheet.Cells[cellRowIndex + 5, cellColumnIndex+1] = "Tot. Fee Paid:";
                worksheet.Cells[cellRowIndex + 5, cellColumnIndex + 1].Font.Bold = true;
                worksheet.Cells[cellRowIndex + 5, cellColumnIndex + 2] = lastYearPay;
                worksheet.Cells[cellRowIndex + 5, cellColumnIndex + 2].Font.Bold = true;

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
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
