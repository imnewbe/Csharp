namespace 计算机系学生信息管理系统
{
    partial class StuAdd
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
            this.txtStuName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtStuNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStuID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbnMale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnFemale = new System.Windows.Forms.RadioButton();
            this.cmbMajor = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnModiStu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtStuName
            // 
            this.txtStuName.Location = new System.Drawing.Point(193, 19);
            this.txtStuName.Name = "txtStuName";
            this.txtStuName.Size = new System.Drawing.Size(186, 21);
            this.txtStuName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓名：";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(64, 279);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "增加";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtStuNo
            // 
            this.txtStuNo.Location = new System.Drawing.Point(194, 52);
            this.txtStuNo.Name = "txtStuNo";
            this.txtStuNo.Size = new System.Drawing.Size(185, 21);
            this.txtStuNo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "学号：";
            // 
            // txtStuID
            // 
            this.txtStuID.Location = new System.Drawing.Point(193, 85);
            this.txtStuID.Name = "txtStuID";
            this.txtStuID.Size = new System.Drawing.Size(186, 21);
            this.txtStuID.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(124, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "身份证号：";
            // 
            // rbnMale
            // 
            this.rbnMale.AutoSize = true;
            this.rbnMale.Checked = true;
            this.rbnMale.Location = new System.Drawing.Point(110, 41);
            this.rbnMale.Name = "rbnMale";
            this.rbnMale.Size = new System.Drawing.Size(35, 16);
            this.rbnMale.TabIndex = 3;
            this.rbnMale.TabStop = true;
            this.rbnMale.Text = "男";
            this.rbnMale.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbnFemale);
            this.groupBox1.Controls.Add(this.rbnMale);
            this.groupBox1.Location = new System.Drawing.Point(16, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 86);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "性别";
            // 
            // rbnFemale
            // 
            this.rbnFemale.AutoSize = true;
            this.rbnFemale.Location = new System.Drawing.Point(26, 41);
            this.rbnFemale.Name = "rbnFemale";
            this.rbnFemale.Size = new System.Drawing.Size(35, 16);
            this.rbnFemale.TabIndex = 3;
            this.rbnFemale.TabStop = true;
            this.rbnFemale.Text = "女";
            this.rbnFemale.UseVisualStyleBackColor = true;
            // 
            // cmbMajor
            // 
            this.cmbMajor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMajor.FormattingEnabled = true;
            this.cmbMajor.Location = new System.Drawing.Point(343, 135);
            this.cmbMajor.Name = "cmbMajor";
            this.cmbMajor.Size = new System.Drawing.Size(121, 20);
            this.cmbMajor.TabIndex = 5;
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(343, 189);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 20);
            this.cmbClass.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "专业：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "班级：";
            // 
            // btnModiStu
            // 
            this.btnModiStu.Location = new System.Drawing.Point(343, 279);
            this.btnModiStu.Name = "btnModiStu";
            this.btnModiStu.Size = new System.Drawing.Size(75, 23);
            this.btnModiStu.TabIndex = 6;
            this.btnModiStu.Text = "修改";
            this.btnModiStu.UseVisualStyleBackColor = true;
            this.btnModiStu.Click += new System.EventHandler(this.btnModiStu_Click);
            // 
            // StuAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 328);
            this.Controls.Add(this.btnModiStu);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.cmbMajor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStuID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStuNo);
            this.Controls.Add(this.txtStuName);
            this.Name = "StuAdd";
            this.Text = "学生信息操作";
            this.Load += new System.EventHandler(this.StuAdd_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStuName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtStuNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStuID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbnMale;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnFemale;
        private System.Windows.Forms.ComboBox cmbMajor;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnModiStu;
    }
}