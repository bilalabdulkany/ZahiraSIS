namespace ZahiraSIS.com.zahira.view.reports
{
    partial class frmServiceArrearsClasswise
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grdStudents = new System.Windows.Forms.DataGridView();
            this.admnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bfarrearsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curarrearsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curbfarresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrearsfrmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrearstoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyfldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyclassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zahira_SISDataSet = new ZahiraSIS.Zahira_SISDataSet();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.stuclassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.stuclassTableAdapter = new ZahiraSIS.Zahira_SISDataSetTableAdapters.stuclassTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.studentTableAdapter = new ZahiraSIS.Zahira_SISDataSetTableAdapters.studentTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBFArrears = new System.Windows.Forms.TextBox();
            this.txtCurArrears = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCurBFArrears = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(285, 103);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 16;
            this.button2.Text = "View Results";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(432, 337);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // grdStudents
            // 
            this.grdStudents.AutoGenerateColumns = false;
            this.grdStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.admnoDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.bfarrearsDataGridViewTextBoxColumn,
            this.curarrearsDataGridViewTextBoxColumn,
            this.curbfarresDataGridViewTextBoxColumn,
            this.arrearsfrmDataGridViewTextBoxColumn,
            this.arrearstoDataGridViewTextBoxColumn,
            this.keyfldDataGridViewTextBoxColumn,
            this.keyclassDataGridViewTextBoxColumn});
            this.grdStudents.DataSource = this.studentBindingSource;
            this.grdStudents.Location = new System.Drawing.Point(59, 148);
            this.grdStudents.Name = "grdStudents";
            this.grdStudents.Size = new System.Drawing.Size(448, 150);
            this.grdStudents.TabIndex = 14;
            // 
            // admnoDataGridViewTextBoxColumn
            // 
            this.admnoDataGridViewTextBoxColumn.DataPropertyName = "admno";
            this.admnoDataGridViewTextBoxColumn.HeaderText = "admno";
            this.admnoDataGridViewTextBoxColumn.Name = "admnoDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // bfarrearsDataGridViewTextBoxColumn
            // 
            this.bfarrearsDataGridViewTextBoxColumn.DataPropertyName = "bfarrears";
            this.bfarrearsDataGridViewTextBoxColumn.HeaderText = "bfarrears";
            this.bfarrearsDataGridViewTextBoxColumn.Name = "bfarrearsDataGridViewTextBoxColumn";
            // 
            // curarrearsDataGridViewTextBoxColumn
            // 
            this.curarrearsDataGridViewTextBoxColumn.DataPropertyName = "curarrears";
            this.curarrearsDataGridViewTextBoxColumn.HeaderText = "curarrears";
            this.curarrearsDataGridViewTextBoxColumn.Name = "curarrearsDataGridViewTextBoxColumn";
            // 
            // curbfarresDataGridViewTextBoxColumn
            // 
            this.curbfarresDataGridViewTextBoxColumn.DataPropertyName = "curbfarres";
            this.curbfarresDataGridViewTextBoxColumn.HeaderText = "curbfarres";
            this.curbfarresDataGridViewTextBoxColumn.Name = "curbfarresDataGridViewTextBoxColumn";
            // 
            // arrearsfrmDataGridViewTextBoxColumn
            // 
            this.arrearsfrmDataGridViewTextBoxColumn.DataPropertyName = "arrearsfrm";
            this.arrearsfrmDataGridViewTextBoxColumn.HeaderText = "arrearsfrm";
            this.arrearsfrmDataGridViewTextBoxColumn.Name = "arrearsfrmDataGridViewTextBoxColumn";
            // 
            // arrearstoDataGridViewTextBoxColumn
            // 
            this.arrearstoDataGridViewTextBoxColumn.DataPropertyName = "arrearsto";
            this.arrearstoDataGridViewTextBoxColumn.HeaderText = "arrearsto";
            this.arrearstoDataGridViewTextBoxColumn.Name = "arrearstoDataGridViewTextBoxColumn";
            // 
            // keyfldDataGridViewTextBoxColumn
            // 
            this.keyfldDataGridViewTextBoxColumn.DataPropertyName = "key_fld";
            this.keyfldDataGridViewTextBoxColumn.HeaderText = "key_fld";
            this.keyfldDataGridViewTextBoxColumn.Name = "keyfldDataGridViewTextBoxColumn";
            // 
            // keyclassDataGridViewTextBoxColumn
            // 
            this.keyclassDataGridViewTextBoxColumn.DataPropertyName = "key_class";
            this.keyclassDataGridViewTextBoxColumn.HeaderText = "key_class";
            this.keyclassDataGridViewTextBoxColumn.Name = "keyclassDataGridViewTextBoxColumn";
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "student";
            this.studentBindingSource.DataSource = this.zahira_SISDataSet;
            // 
            // zahira_SISDataSet
            // 
            this.zahira_SISDataSet.DataSetName = "Zahira_SISDataSet";
            this.zahira_SISDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbClass
            // 
            this.cmbClass.DataSource = this.stuclassBindingSource;
            this.cmbClass.DisplayMember = "name";
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(140, 4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(251, 21);
            this.cmbClass.TabIndex = 12;
            this.cmbClass.ValueMember = "key_fld";
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // stuclassBindingSource
            // 
            this.stuclassBindingSource.DataMember = "stuclass";
            this.stuclassBindingSource.DataSource = this.zahira_SISDataSet;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Class";
            // 
            // stuclassTableAdapter
            // 
            this.stuclassTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "From Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "To Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(140, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(140, 67);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "BF Arrears";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtBFArrears
            // 
            this.txtBFArrears.Location = new System.Drawing.Point(59, 322);
            this.txtBFArrears.Name = "txtBFArrears";
            this.txtBFArrears.ReadOnly = true;
            this.txtBFArrears.Size = new System.Drawing.Size(100, 20);
            this.txtBFArrears.TabIndex = 22;
            // 
            // txtCurArrears
            // 
            this.txtCurArrears.Location = new System.Drawing.Point(165, 322);
            this.txtCurArrears.Name = "txtCurArrears";
            this.txtCurArrears.ReadOnly = true;
            this.txtCurArrears.Size = new System.Drawing.Size(100, 20);
            this.txtCurArrears.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Current Arrears";
            // 
            // txtCurBFArrears
            // 
            this.txtCurBFArrears.Location = new System.Drawing.Point(271, 322);
            this.txtCurBFArrears.Name = "txtCurBFArrears";
            this.txtCurBFArrears.ReadOnly = true;
            this.txtCurBFArrears.Size = new System.Drawing.Size(100, 20);
            this.txtCurBFArrears.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(271, 305);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Current BF Arrears";
            // 
            // frmServiceArrearsClasswise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 386);
            this.Controls.Add(this.txtCurBFArrears);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCurArrears);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBFArrears);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdStudents);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Name = "frmServiceArrearsClasswise";
            this.Text = "Fees Arrears - Class Wise";
            this.Load += new System.EventHandler(this.frmServiceArrearsClasswise_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView grdStudents;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
        private Zahira_SISDataSet zahira_SISDataSet;
        private System.Windows.Forms.BindingSource stuclassBindingSource;
        private Zahira_SISDataSetTableAdapters.stuclassTableAdapter stuclassTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private Zahira_SISDataSetTableAdapters.studentTableAdapter studentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn admnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bfarrearsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curarrearsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curbfarresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrearsfrmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrearstoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyfldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyclassDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBFArrears;
        private System.Windows.Forms.TextBox txtCurArrears;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCurBFArrears;
        private System.Windows.Forms.Label label6;
    }
}