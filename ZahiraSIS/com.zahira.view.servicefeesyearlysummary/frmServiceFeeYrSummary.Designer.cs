using System.Windows.Forms;

namespace ZahiraSIS
{
    partial class frmServiceFeeYrSummary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceFeeYrSummary));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.stuclassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zahiraSISDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zahira_SISDataSet = new ZahiraSIS.Zahira_SISDataSet();
            this.stuclassTableAdapter = new ZahiraSIS.Zahira_SISDataSetTableAdapters.stuclassTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableAdapter = new ZahiraSIS.Zahira_SISDataSetTableAdapters.studentTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.studentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dtStudentArrears = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtKeyClass = new System.Windows.Forms.TextBox();
            this.txtClassCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblArrearsDate = new System.Windows.Forms.Label();
            this.txtArrearsToDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBreakdown = new System.Windows.Forms.TextBox();
            this.dtpAsAt = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahiraSISDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStudentArrears)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Class";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.stuclassBindingSource;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(101, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(181, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.ValueMember = "key_fld";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // stuclassBindingSource
            // 
            this.stuclassBindingSource.DataMember = "stuclass";
            this.stuclassBindingSource.DataSource = this.zahiraSISDataSetBindingSource;
            // 
            // zahiraSISDataSetBindingSource
            // 
            this.zahiraSISDataSetBindingSource.DataSource = this.zahira_SISDataSet;
            this.zahiraSISDataSetBindingSource.Position = 0;
            // 
            // zahira_SISDataSet
            // 
            this.zahira_SISDataSet.DataSetName = "Zahira_SISDataSet";
            this.zahira_SISDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // stuclassTableAdapter
            // 
            this.stuclassTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Admission No";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(101, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(181, 21);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox2_KeyDown);
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "student";
            this.studentBindingSource.DataSource = this.zahiraSISDataSetBindingSource;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 87);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(177, 20);
            this.txtName.TabIndex = 3;
            // 
            // studentBindingSource1
            // 
            this.studentBindingSource1.DataMember = "student";
            this.studentBindingSource1.DataSource = this.zahira_SISDataSet;
            // 
            // dtStudentArrears
            // 
            this.dtStudentArrears.AllowUserToOrderColumns = true;
            this.dtStudentArrears.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtStudentArrears.Location = new System.Drawing.Point(26, 184);
            this.dtStudentArrears.Name = "dtStudentArrears";
            this.dtStudentArrears.Size = new System.Drawing.Size(609, 120);
            this.dtStudentArrears.TabIndex = 6;
            this.dtStudentArrears.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(560, 310);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(184, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "View Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Payment History";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPaid);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtKeyClass);
            this.groupBox1.Controls.Add(this.txtClassCode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFees);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblArrearsDate);
            this.groupBox1.Controls.Add(this.txtArrearsToDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(303, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(332, 153);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Arrears Info";
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(182, 100);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.ReadOnly = true;
            this.txtPaid.Size = new System.Drawing.Size(129, 20);
            this.txtPaid.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Total Paid";
            // 
            // txtKeyClass
            // 
            this.txtKeyClass.Location = new System.Drawing.Point(12, 127);
            this.txtKeyClass.Name = "txtKeyClass";
            this.txtKeyClass.Size = new System.Drawing.Size(100, 20);
            this.txtKeyClass.TabIndex = 7;
            this.txtKeyClass.Visible = false;
            // 
            // txtClassCode
            // 
            this.txtClassCode.Enabled = false;
            this.txtClassCode.Location = new System.Drawing.Point(182, 20);
            this.txtClassCode.Name = "txtClassCode";
            this.txtClassCode.ReadOnly = true;
            this.txtClassCode.Size = new System.Drawing.Size(129, 20);
            this.txtClassCode.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Class Code";
            // 
            // txtFees
            // 
            this.txtFees.Location = new System.Drawing.Point(182, 74);
            this.txtFees.Name = "txtFees";
            this.txtFees.ReadOnly = true;
            this.txtFees.Size = new System.Drawing.Size(129, 20);
            this.txtFees.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Monthly Fees";
            // 
            // lblArrearsDate
            // 
            this.lblArrearsDate.AutoSize = true;
            this.lblArrearsDate.Location = new System.Drawing.Point(75, 56);
            this.lblArrearsDate.Name = "lblArrearsDate";
            this.lblArrearsDate.Size = new System.Drawing.Size(16, 13);
            this.lblArrearsDate.TabIndex = 2;
            this.lblArrearsDate.Text = "---";
            // 
            // txtArrearsToDate
            // 
            this.txtArrearsToDate.Enabled = false;
            this.txtArrearsToDate.Location = new System.Drawing.Point(182, 49);
            this.txtArrearsToDate.Name = "txtArrearsToDate";
            this.txtArrearsToDate.ReadOnly = true;
            this.txtArrearsToDate.Size = new System.Drawing.Size(129, 20);
            this.txtArrearsToDate.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Arrears from";
            // 
            // txtBreakdown
            // 
            this.txtBreakdown.Location = new System.Drawing.Point(26, 311);
            this.txtBreakdown.Multiline = true;
            this.txtBreakdown.Name = "txtBreakdown";
            this.txtBreakdown.Size = new System.Drawing.Size(380, 78);
            this.txtBreakdown.TabIndex = 11;
            // 
            // dtpAsAt
            // 
            this.dtpAsAt.CustomFormat = "dd-MMM-yyyy";
            this.dtpAsAt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAsAt.Location = new System.Drawing.Point(26, 115);
            this.dtpAsAt.Name = "dtpAsAt";
            this.dtpAsAt.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpAsAt.Size = new System.Drawing.Size(152, 20);
            this.dtpAsAt.TabIndex = 12;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(413, 309);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(110, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "Generate Receipt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmServiceFeeYrSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 401);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dtpAsAt);
            this.Controls.Add(this.txtBreakdown);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtStudentArrears);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmServiceFeeYrSummary";
            this.Text = "Student Fee Arrears";
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahiraSISDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStudentArrears)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Zahira_SISDataSet zahira_SISDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DataGridView dtStudentArrears;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.BindingSource zahiraSISDataSetBindingSource;
        public System.Windows.Forms.BindingSource stuclassBindingSource;
        public Zahira_SISDataSetTableAdapters.stuclassTableAdapter stuclassTableAdapter;
        public System.Windows.Forms.BindingSource studentBindingSource;
        public Zahira_SISDataSetTableAdapters.studentTableAdapter studentTableAdapter;
        public System.Windows.Forms.BindingSource studentBindingSource1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblArrearsDate;
        private System.Windows.Forms.TextBox txtArrearsToDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtClassCode;
        private System.Windows.Forms.Label label7;
        private TextBox txtBreakdown;
        private DateTimePicker dtpAsAt;
        private TextBox txtKeyClass;
        private TextBox txtPaid;
        private Label label8;
        private Button button3;
    }
}