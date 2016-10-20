using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            outputToFile();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "") {
                MessageBox.Show("Fields cannot be blank!");
                return;
            }
            dbConnector dbcon = new dbConnector();
            if (dbcon.connectDB(txtUsername.Text, txtPassword.Text))
            {
                frmDashboard home = new frmDashboard();
                this.Hide();
                home.ShowDialog();
            }
            else {
                Console.WriteLine("invalid credentials");
                MessageBox.Show("Invalid Login Credentials");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void outputToFile()
        {
            DateTime today = DateTime.Today;
           String date= today.ToString("dd-MM-yyyy");
            FileStream filestream = new FileStream("./trace."+ date+".log", FileMode.Append);
            var streamwriter = new StreamWriter(filestream);
            streamwriter.AutoFlush = true;
            Console.SetOut(streamwriter);
            Console.SetError(streamwriter);

        }
    }
}
