using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZahiraSIS.com.zahira.bean;

namespace ZahiraSIS.com.zahira.view.alstudentfees
{
    public partial class frmALStudentFee : Form
    {
        StudentDAO dao = null;
        ClassDAO clsDao = null;
        public frmALStudentFee()
        {
            InitializeComponent();
            dao = new StudentDAO();
            clsDao = new ClassDAO();
            makeCash(false);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkInput()) {
                MessageBox.Show("Validation Success", "Successful!");
                PaymentBean payBean = new PaymentBean();
                payBean.Admno = txtAdmNo.Text;
                payBean.Paid = double.Parse(txtAmount.Text);
                payBean.IsCash = radioButton1.Checked;
                payBean.PayFrom = dtPayFrom.Value;
                payBean.PayTo = dtPayTo.Value;
                payBean.SetCheque(payBean.IsCash);


            }
            //TODO
            /**
             * Insert into mnthfeepay table, 
             * update the student table.  
             */

            //class: select key_fee,key_grd,key_med,key_tea from stuclass where key_fld=185;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            makeCash(false);

        }

        private void makeCash(Boolean flag) {
            if (flag)
            {
                lblCheque.Visible = true;
                txtCheque.Visible = true;
            }
            else {
                lblCheque.Visible = false;
                txtCheque.Visible = false;
            }
        }

        private Boolean checkInput() {
            if (txtAdmNo.Text == "" || txtAmount.Text == "")
            {
                MessageBox.Show("Validation Error", "Mandatory Fields are missing");
                return false;
            }
            else if (radioButton2.Checked == true) {
                if (txtCheque.Text == "") {
                    MessageBox.Show("Validation Error", "Mandatory Fields are missing");
                    return false;
                }
            }
            return true;
                
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            makeCash(true);
        }

        private void frmALStudentFee_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtAdmNo.Text.Trim()!= "") {
                makeCommandsVisible(true);
                string admno = txtAdmNo.Text.Trim();
                if (dao.getStudentInfoFromIndex(admno) != null) { 
                StudentBean bean = dao.getStudentInfoFromIndex(admno);
                txtName.Text = bean.Name.Trim();
                txtAddress.Text= bean.Address.Trim();
                int keyClass = bean.Key_class;
                StuclassBean classBean = dao.getStudentClasses(keyClass);
                cmbClass.Text = classBean.Name;
                txtClass.Text = classBean.Code;
                    if (!clsDao.CheckALClass(keyClass))
                    {
                        MessageBox.Show("The student is not from an AL class!", "Not AL");
                        makeCommandsVisible(false);
                    }
                    else {
                        double feeRate = dao.guessClassAndFee(classBean.Code, DateTime.Today.Year, DateTime.Today.Year);
                        txtFeeRate.Text= feeRate+"";
                        txtFullAmount.Text = feeRate * 24+"";
                    }
                }
            }
        }

        private void makeCommandsVisible(Boolean flag) {
            btnExp.Enabled = flag;
            btnGen.Enabled = flag;
            btnPay.Enabled = flag;
        }
    }
}
