namespace ZahiraSIS
{
    partial class frmClassReport
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
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.stuclassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zahiraSISDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zahira_SISDataSet = new ZahiraSIS.Zahira_SISDataSet();
            this.stuclassTableAdapter = new ZahiraSIS.Zahira_SISDataSetTableAdapters.stuclassTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.zahira_SISDataSet1 = new ZahiraSIS.Zahira_SISDataSet();
            this.teacherTableAdapter1 = new ZahiraSIS.Zahira_SISDataSetTableAdapters.teacherTableAdapter();
            this.txtTeacherName = new System.Windows.Forms.TextBox();
            this.teacherBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.Teacher = new System.Windows.Forms.Label();
            this.txtClassKey = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.keyfldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.admnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keyclassDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentTableAdapter = new ZahiraSIS.Zahira_SISDataSetTableAdapters.studentTableAdapter();
            this.fillByClassToolStrip = new System.Windows.Forms.ToolStrip();
            this.classKeyToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.classKeyToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.fillByClassToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahiraSISDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.fillByClassToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Class";
            // 
            // cmbClass
            // 
            this.cmbClass.DataSource = this.stuclassBindingSource;
            this.cmbClass.DisplayMember = "name";
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(113, 31);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(251, 21);
            this.cmbClass.TabIndex = 1;
            this.cmbClass.ValueMember = "key_tea";
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
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
            // zahira_SISDataSet1
            // 
            this.zahira_SISDataSet1.DataSetName = "Zahira_SISDataSet";
            this.zahira_SISDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // teacherTableAdapter1
            // 
            this.teacherTableAdapter1.ClearBeforeFill = true;
            // 
            // txtTeacherName
            // 
            this.txtTeacherName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.teacherBindingSource, "name", true));
            this.txtTeacherName.Location = new System.Drawing.Point(113, 70);
            this.txtTeacherName.Name = "txtTeacherName";
            this.txtTeacherName.Size = new System.Drawing.Size(251, 20);
            this.txtTeacherName.TabIndex = 3;
            // 
            // teacherBindingSource
            // 
            this.teacherBindingSource.DataMember = "teacher";
            this.teacherBindingSource.DataSource = this.zahira_SISDataSet;
            // 
            // bindingSource2
            // 
            this.bindingSource2.DataSource = this.teacherBindingSource;
            this.bindingSource2.CurrentChanged += new System.EventHandler(this.bindingSource2_CurrentChanged);
            // 
            // Teacher
            // 
            this.Teacher.AutoSize = true;
            this.Teacher.Location = new System.Drawing.Point(29, 73);
            this.Teacher.Name = "Teacher";
            this.Teacher.Size = new System.Drawing.Size(78, 13);
            this.Teacher.TabIndex = 4;
            this.Teacher.Text = "Teacher Name";
            // 
            // txtClassKey
            // 
            this.txtClassKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.stuclassBindingSource, "key_fld", true));
            this.txtClassKey.Location = new System.Drawing.Point(113, 96);
            this.txtClassKey.Name = "txtClassKey";
            this.txtClassKey.Size = new System.Drawing.Size(100, 20);
            this.txtClassKey.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyfldDataGridViewTextBoxColumn,
            this.admnoDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.keyclassDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.studentBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(32, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(332, 150);
            this.dataGridView1.TabIndex = 6;
            // 
            // keyfldDataGridViewTextBoxColumn
            // 
            this.keyfldDataGridViewTextBoxColumn.DataPropertyName = "key_fld";
            this.keyfldDataGridViewTextBoxColumn.HeaderText = "key_fld";
            this.keyfldDataGridViewTextBoxColumn.Name = "keyfldDataGridViewTextBoxColumn";
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
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "address";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
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
            // studentTableAdapter
            // 
            this.studentTableAdapter.ClearBeforeFill = true;
            // 
            // fillByClassToolStrip
            // 
            this.fillByClassToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.classKeyToolStripLabel,
            this.classKeyToolStripTextBox,
            this.fillByClassToolStripButton});
            this.fillByClassToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByClassToolStrip.Name = "fillByClassToolStrip";
            this.fillByClassToolStrip.Size = new System.Drawing.Size(395, 25);
            this.fillByClassToolStrip.TabIndex = 8;
            this.fillByClassToolStrip.Text = "fillByClassToolStrip";
            // 
            // classKeyToolStripLabel
            // 
            this.classKeyToolStripLabel.Name = "classKeyToolStripLabel";
            this.classKeyToolStripLabel.Size = new System.Drawing.Size(56, 22);
            this.classKeyToolStripLabel.Text = "ClassKey:";
            // 
            // classKeyToolStripTextBox
            // 
            this.classKeyToolStripTextBox.Name = "classKeyToolStripTextBox";
            this.classKeyToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // fillByClassToolStripButton
            // 
            this.fillByClassToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByClassToolStripButton.Name = "fillByClassToolStripButton";
            this.fillByClassToolStripButton.Size = new System.Drawing.Size(66, 22);
            this.fillByClassToolStripButton.Text = "FillByClass";
            this.fillByClassToolStripButton.Click += new System.EventHandler(this.fillByClassToolStripButton_Click);
            // 
            // frmClassReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 325);
            this.Controls.Add(this.fillByClassToolStrip);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtClassKey);
            this.Controls.Add(this.Teacher);
            this.Controls.Add(this.txtTeacherName);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Name = "frmClassReport";
            this.Text = "frmClassReport";
            this.Load += new System.EventHandler(this.frmClassReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahiraSISDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.fillByClassToolStrip.ResumeLayout(false);
            this.fillByClassToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.BindingSource zahiraSISDataSetBindingSource;
        private Zahira_SISDataSet zahira_SISDataSet;
        private System.Windows.Forms.BindingSource stuclassBindingSource;
        private Zahira_SISDataSetTableAdapters.stuclassTableAdapter stuclassTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private Zahira_SISDataSet zahira_SISDataSet1;
        private Zahira_SISDataSetTableAdapters.teacherTableAdapter teacherTableAdapter1;
        private System.Windows.Forms.TextBox txtTeacherName;
        private System.Windows.Forms.BindingSource teacherBindingSource;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.Label Teacher;
        private System.Windows.Forms.TextBox txtClassKey;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private Zahira_SISDataSetTableAdapters.studentTableAdapter studentTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyfldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn admnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyclassDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip fillByClassToolStrip;
        private System.Windows.Forms.ToolStripLabel classKeyToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox classKeyToolStripTextBox;
        private System.Windows.Forms.ToolStripButton fillByClassToolStripButton;
    }
}