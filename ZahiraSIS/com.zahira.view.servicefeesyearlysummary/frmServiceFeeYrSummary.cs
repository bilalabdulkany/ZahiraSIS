using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZahiraSIS.com.zahira.bean;
using ZahiraSIS.com.zahira.bean.student;

namespace ZahiraSIS
{
    public partial class frmServiceFeeYrSummary : Form
    {

        StudentDAO dao = new StudentDAO();
        //static DataTable dt = new DataTable();
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
            //getStudentArrearsInfo();

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
                setupArrearsFormData();
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
            setupArrearsFormData();
          //  getStudentArrearsInfo(comboBox2.Text.Trim(), dao.getStudentClasses((int)comboBox1.SelectedValue).Code.Trim());
            if(isEnterPressed)
            isEnterPressed = false;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void setupArrearsFormData()
        {
            StuclassBean classBean = dao.getStudentClasses((int)comboBox1.SelectedValue);
            classCode = classBean.Code.Trim();
            StudentArrearsBean bean = dao.getStudentArrearsInfo(comboBox2.Text.Trim(), classCode);
            dtStudentArrears.DataSource = bean.stPaidData;
            txtClassCode.Text = classCode;
            txtArrearsToDate.Text = bean.curArrears;
            lblArrearsDate.Text = bean.paidTill.ToString("dd-MMM-yyyy");
            txtFees.Text = dao.getMonthFeeRevision(classBean.Key_fee, DateTime.Now.Year + "").Rows[0]["amount"].ToString();
            //
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
