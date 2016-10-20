using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZahiraSIS.com.zahira.view.promotestudents
{
    public partial class frmPromoteStudents : Form
    {
        public frmPromoteStudents()
        {
            InitializeComponent();
            Console.WriteLine("Accessed Promote Students");
            
        }

        private void frmPromoteStudents_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zahira_SISDataSet.student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.zahira_SISDataSet.student);
            // TODO: This line of code loads data into the 'zahira_SISDataSet.teacher' table. You can move, or remove it, as needed.
            this.teacherTableAdapter.Fill(this.zahira_SISDataSet.teacher);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

          
            try
            {
                listView1.BeginUpdate();
                foreach (ListViewItem item in this.listView1.SelectedItems)
                {
                    listView2.Items.Add(item.Text);

                    this.listView1.Items.Remove(item);
                }
            }
            finally
            {
                this.listView1.EndUpdate();
            }


        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
