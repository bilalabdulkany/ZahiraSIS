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
        public frmALStudentFee()
        {
            InitializeComponent();
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
    }
}
