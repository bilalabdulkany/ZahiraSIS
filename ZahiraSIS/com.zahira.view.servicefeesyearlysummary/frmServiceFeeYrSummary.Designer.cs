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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.studentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.admnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.registernoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyclassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bfarrearsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curarrearsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.curbfarresDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrearsfrmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arrearstoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahiraSISDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            this.comboBox2.DataSource = this.studentBindingSource;
            this.comboBox2.DisplayMember = "admno";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(101, 53);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(181, 21);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.ValueMember = "admno";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
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
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "name", true));
            this.textBox1.Location = new System.Drawing.Point(104, 87);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 5;
            // 
            // studentBindingSource1
            // 
            this.studentBindingSource1.DataMember = "student";
            this.studentBindingSource1.DataSource = this.zahira_SISDataSet;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.admnoDataGridViewTextBoxColumn,
            this.registernoDataGridViewTextBoxColumn,
            this.keyclassDataGridViewTextBoxColumn,
            this.bfarrearsDataGridViewTextBoxColumn,
            this.curarrearsDataGridViewTextBoxColumn,
            this.curbfarresDataGridViewTextBoxColumn,
            this.admonDataGridViewTextBoxColumn,
            this.arrearsfrmDataGridViewTextBoxColumn,
            this.arrearstoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.studentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(26, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(340, 150);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // admnoDataGridViewTextBoxColumn
            // 
            this.admnoDataGridViewTextBoxColumn.DataPropertyName = "admno";
            this.admnoDataGridViewTextBoxColumn.HeaderText = "admno";
            this.admnoDataGridViewTextBoxColumn.Name = "admnoDataGridViewTextBoxColumn";
            this.admnoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // registernoDataGridViewTextBoxColumn
            // 
            this.registernoDataGridViewTextBoxColumn.DataPropertyName = "registerno";
            this.registernoDataGridViewTextBoxColumn.HeaderText = "registerno";
            this.registernoDataGridViewTextBoxColumn.Name = "registernoDataGridViewTextBoxColumn";
            // 
            // keyclassDataGridViewTextBoxColumn
            // 
            this.keyclassDataGridViewTextBoxColumn.DataPropertyName = "key_class";
            this.keyclassDataGridViewTextBoxColumn.HeaderText = "key_class";
            this.keyclassDataGridViewTextBoxColumn.Name = "keyclassDataGridViewTextBoxColumn";
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
            // admonDataGridViewTextBoxColumn
            // 
            this.admonDataGridViewTextBoxColumn.DataPropertyName = "admon";
            this.admonDataGridViewTextBoxColumn.HeaderText = "admon";
            this.admonDataGridViewTextBoxColumn.Name = "admonDataGridViewTextBoxColumn";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(323, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Export";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmServiceFeeYrSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 347);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmServiceFeeYrSummary";
            this.Text = "Monthly Fees payment Summary";
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahiraSISDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn admnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn registernoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyclassDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bfarrearsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curarrearsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curbfarresDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn admonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrearsfrmDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn arrearstoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.BindingSource zahiraSISDataSetBindingSource;
        public System.Windows.Forms.BindingSource stuclassBindingSource;
        public Zahira_SISDataSetTableAdapters.stuclassTableAdapter stuclassTableAdapter;
        public System.Windows.Forms.BindingSource studentBindingSource;
        public Zahira_SISDataSetTableAdapters.studentTableAdapter studentTableAdapter;
        public System.Windows.Forms.BindingSource studentBindingSource1;
    }
}