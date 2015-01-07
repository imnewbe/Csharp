namespace 计算机系学生信息管理系统
{
    partial class techFrm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lviStuInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStuClass = new System.Windows.Forms.TextBox();
            this.btnStuClass = new System.Windows.Forms.Button();
            this.txtStuName = new System.Windows.Forms.TextBox();
            this.btnStuName = new System.Windows.Forms.Button();
            this.txtStuNo = new System.Windows.Forms.TextBox();
            this.btnStuNumber = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSureNewPwd = new System.Windows.Forms.TextBox();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtLoginUsrTeach = new System.Windows.Forms.TextBox();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.btnEscChange = new System.Windows.Forms.Button();
            this.btnOkChange = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(616, 390);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lviStuInfo);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(608, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "信息查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lviStuInfo
            // 
            this.lviStuInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lviStuInfo.GridLines = true;
            this.lviStuInfo.Location = new System.Drawing.Point(8, 117);
            this.lviStuInfo.Name = "lviStuInfo";
            this.lviStuInfo.Size = new System.Drawing.Size(592, 244);
            this.lviStuInfo.TabIndex = 3;
            this.lviStuInfo.UseCompatibleStateImageBehavior = false;
            this.lviStuInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "姓名";
            this.columnHeader1.Width = 101;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "班级";
            this.columnHeader2.Width = 93;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "学号";
            this.columnHeader3.Width = 101;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "专业";
            this.columnHeader4.Width = 128;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "身份证号";
            this.columnHeader5.Width = 353;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "性别";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtStuClass);
            this.groupBox1.Controls.Add(this.btnStuClass);
            this.groupBox1.Controls.Add(this.txtStuName);
            this.groupBox1.Controls.Add(this.btnStuName);
            this.groupBox1.Controls.Add(this.txtStuNo);
            this.groupBox1.Controls.Add(this.btnStuNumber);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "班级：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "学号：";
            // 
            // txtStuClass
            // 
            this.txtStuClass.Location = new System.Drawing.Point(362, 17);
            this.txtStuClass.Name = "txtStuClass";
            this.txtStuClass.Size = new System.Drawing.Size(100, 21);
            this.txtStuClass.TabIndex = 1;
            // 
            // btnStuClass
            // 
            this.btnStuClass.Location = new System.Drawing.Point(492, 17);
            this.btnStuClass.Name = "btnStuClass";
            this.btnStuClass.Size = new System.Drawing.Size(75, 23);
            this.btnStuClass.TabIndex = 0;
            this.btnStuClass.Text = "查询";
            this.btnStuClass.UseVisualStyleBackColor = true;
            this.btnStuClass.Click += new System.EventHandler(this.btnStuClass_Click);
            // 
            // txtStuName
            // 
            this.txtStuName.Location = new System.Drawing.Point(67, 69);
            this.txtStuName.Name = "txtStuName";
            this.txtStuName.Size = new System.Drawing.Size(100, 21);
            this.txtStuName.TabIndex = 1;
            // 
            // btnStuName
            // 
            this.btnStuName.Location = new System.Drawing.Point(195, 69);
            this.btnStuName.Name = "btnStuName";
            this.btnStuName.Size = new System.Drawing.Size(75, 23);
            this.btnStuName.TabIndex = 0;
            this.btnStuName.Text = "查询";
            this.btnStuName.UseVisualStyleBackColor = true;
            this.btnStuName.Click += new System.EventHandler(this.btnStuName_Click);
            // 
            // txtStuNo
            // 
            this.txtStuNo.Location = new System.Drawing.Point(67, 17);
            this.txtStuNo.Name = "txtStuNo";
            this.txtStuNo.Size = new System.Drawing.Size(100, 21);
            this.txtStuNo.TabIndex = 1;
            this.txtStuNo.TextChanged += new System.EventHandler(this.txtStuNo_TextChanged);
            // 
            // btnStuNumber
            // 
            this.btnStuNumber.Location = new System.Drawing.Point(195, 17);
            this.btnStuNumber.Name = "btnStuNumber";
            this.btnStuNumber.Size = new System.Drawing.Size(75, 23);
            this.btnStuNumber.TabIndex = 0;
            this.btnStuNumber.Text = "查询";
            this.btnStuNumber.UseVisualStyleBackColor = true;
            this.btnStuNumber.Click += new System.EventHandler(this.btnStuNumber_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(608, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "密码修改";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSureNewPwd);
            this.groupBox2.Controls.Add(this.txtNewPwd);
            this.groupBox2.Controls.Add(this.txtLoginUsrTeach);
            this.groupBox2.Controls.Add(this.txtOldPwd);
            this.groupBox2.Controls.Add(this.btnEscChange);
            this.groupBox2.Controls.Add(this.btnOkChange);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 358);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "密码修改";
            // 
            // txtSureNewPwd
            // 
            this.txtSureNewPwd.Location = new System.Drawing.Point(143, 221);
            this.txtSureNewPwd.Name = "txtSureNewPwd";
            this.txtSureNewPwd.Size = new System.Drawing.Size(145, 21);
            this.txtSureNewPwd.TabIndex = 2;
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(143, 158);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(145, 21);
            this.txtNewPwd.TabIndex = 2;
            // 
            // txtLoginUsrTeach
            // 
            this.txtLoginUsrTeach.Location = new System.Drawing.Point(143, 39);
            this.txtLoginUsrTeach.Name = "txtLoginUsrTeach";
            this.txtLoginUsrTeach.Size = new System.Drawing.Size(145, 21);
            this.txtLoginUsrTeach.TabIndex = 2;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(143, 95);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(145, 21);
            this.txtOldPwd.TabIndex = 2;
            // 
            // btnEscChange
            // 
            this.btnEscChange.Location = new System.Drawing.Point(213, 276);
            this.btnEscChange.Name = "btnEscChange";
            this.btnEscChange.Size = new System.Drawing.Size(75, 23);
            this.btnEscChange.TabIndex = 1;
            this.btnEscChange.Text = "取消";
            this.btnEscChange.UseVisualStyleBackColor = true;
            // 
            // btnOkChange
            // 
            this.btnOkChange.Location = new System.Drawing.Point(86, 276);
            this.btnOkChange.Name = "btnOkChange";
            this.btnOkChange.Size = new System.Drawing.Size(75, 23);
            this.btnOkChange.TabIndex = 1;
            this.btnOkChange.Text = "确定";
            this.btnOkChange.UseVisualStyleBackColor = true;
            this.btnOkChange.Click += new System.EventHandler(this.btnOkChange_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "确认新密：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "账号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "新密码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(84, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "原密码：";
            // 
            // techFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 390);
            this.Controls.Add(this.tabControl1);
            this.Name = "techFrm";
            this.Text = "学生管理系统（教师）";
            this.Load += new System.EventHandler(this.techFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lviStuInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStuClass;
        private System.Windows.Forms.Button btnStuClass;
        private System.Windows.Forms.TextBox txtStuName;
        private System.Windows.Forms.Button btnStuName;
        private System.Windows.Forms.TextBox txtStuNo;
        private System.Windows.Forms.Button btnStuNumber;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSureNewPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Button btnEscChange;
        private System.Windows.Forms.Button btnOkChange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLoginUsrTeach;
        private System.Windows.Forms.Label label7;
    }
}