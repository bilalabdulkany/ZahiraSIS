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
            ((System.ComponentModel.ISupportInitialize)(this.stuclassBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahiraSISDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zahira_SISDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teacherBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
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
            // frmClassReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 317);
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
    }
}