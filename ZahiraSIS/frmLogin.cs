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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            dbConnector dbcon = new dbConnector();
            if (dbcon.connectDB(txtUsername.Text, txtPassword.Text))
            {
                frmHome home = new frmHome();
                this.Hide();
                home.ShowDialog();
            }
            else {
                MessageBox.Show("Invalid Login Credentials");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
