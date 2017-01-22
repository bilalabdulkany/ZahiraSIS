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
using ZahiraSIS.com.zahira.common;
using ZahiraSIS.com.zahira.reports;

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

                comboBox2.DataSource = dao.getStudentIndexFromClass(classCode + "").DefaultView;
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
            try
            {
                txtBreakdown.Text = "";
                StuclassBean classBean = dao.getStudentClasses(int.Parse(txtKeyClass.Text.Trim()));
                classCode = classBean.Code.Trim();
                DateTime asAt = dtpAsAt.Value;
                StudentArrearsBean bean = dao.NewForwardBalance(comboBox2.Text.Trim(), classCode,asAt, false);
                if (bean != null)
                {
                    dtStudentArrears.DataSource = bean.stPaidData;
                    txtClassCode.Text = classCode;
                    txtArrearsToDate.Text = bean.curArrears;
                    lblArrearsDate.Text = bean.arrearsTo.ToString("dd-MMM-yyyy");
                    txtFees.Text =
                        dao.getMonthFeeRevision(classBean.Key_fee, asAt.Year).Rows[0]["amount"].ToString();
                    txtPaid.Text=bean.feePaidForTheYear+"";
                    if (bean.studentConcession == true) {
                        txtFees.Text = "0.00";
                        lblArrearsDate.Text = "fee concession";
                    } else { 
                    String lines = null;
                    foreach (KeyValuePair<int, string> kvp in bean.arrearsMap)
                    {
                        //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                        lines = "Year =" + kvp.Key + " fee rate: " + kvp.Value.Split('|')[0] + " months paid: " + kvp.Value.Split('|')[1] + " total: " + kvp.Value.Split('|')[2];
                        txtBreakdown.AppendText(lines);
                        txtBreakdown.AppendText(Environment.NewLine);
                    }
                }
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            //
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            new Common().ExportToExcel(dtStudentArrears,Double.Parse(txtArrearsToDate.Text),0);            
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
                    keyClass = dao.getStudentInfoFromIndex(comboBox2.Text.Trim()).Key_class;
                }
                catch (Exception e1)
                {
                    Console.WriteLine("null exception:" + e1);
                    MessageBox.Show(null,"Admission Number Not Found!","Warning");
                }
            }
            //(int)comboBox1.SelectedValue;
           

            if (isEnterPressed)
            {
                try
                {
                    StuclassBean classBean = dao.getStudentClasses(keyClass);
                    comboBox1.Text = classBean.Name;
                    txtClassCode.Text = classBean.Code;
                    txtKeyClass.Text = classBean.Key_fld+"";

                    Console.WriteLine("key class is:" + classBean.Key_fld);
                }
                catch (Exception e)
                {
                    comboBox1.Text = "";
                }
            }
                Console.WriteLine("Selected class:" + keyClass);

            
           
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

        private void button3_Click(object sender, EventArgs e)
        {
            StudentReceiptViewer rp = new StudentReceiptViewer("123",comboBox2.Text,txtName.Text,txtPaid.Text,txtArrearsToDate.Text, txtClassCode.Text);
            rp.Show();
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
