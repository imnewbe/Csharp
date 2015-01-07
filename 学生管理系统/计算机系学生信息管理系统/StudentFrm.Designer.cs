namespace 计算机系学生信息管理系统
{
    partial class StudentFrm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lviStuInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSeachStuNo = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtSearchClass = new System.Windows.Forms.TextBox();
            this.btnSearchGrade = new System.Windows.Forms.Button();
            this.btnSearchMajor = new System.Windows.Forms.Button();
            this.btnSearchClass = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOk = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.btnEsc = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(657, 373);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.lviStuInfo);
            this.tabPage1.Controls.Add(this.btnSeachStuNo);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.txtSearchClass);
            this.tabPage1.Controls.Add(this.btnSearchGrade);
            this.tabPage1.Controls.Add(this.btnSearchMajor);
            this.tabPage1.Controls.Add(this.btnSearchClass);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(649, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "信息查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "学号查询：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "年级查询：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "专业查询：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "课程查询：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(429, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
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
            this.lviStuInfo.FullRowSelect = true;
            this.lviStuInfo.GridLines = true;
            this.lviStuInfo.Location = new System.Drawing.Point(10, 124);
            this.lviStuInfo.Name = "lviStuInfo";
            this.lviStuInfo.Size = new System.Drawing.Size(633, 215);
            this.lviStuInfo.TabIndex = 2;
            this.lviStuInfo.UseCompatibleStateImageBehavior = false;
            this.lviStuInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "课程名";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "专业名";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "学号";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "密码";
            this.columnHeader4.Width = 113;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "年级";
            this.columnHeader5.Width = 97;
            // 
            // btnSeachStuNo
            // 
            this.btnSeachStuNo.Location = new System.Drawing.Point(554, 14);
            this.btnSeachStuNo.Name = "btnSeachStuNo";
            this.btnSeachStuNo.Size = new System.Drawing.Size(75, 23);
            this.btnSeachStuNo.TabIndex = 0;
            this.btnSeachStuNo.Text = "查询";
            this.btnSeachStuNo.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(429, 81);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(79, 81);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 1;
            // 
            // txtSearchClass
            // 
            this.txtSearchClass.Location = new System.Drawing.Point(79, 16);
            this.txtSearchClass.Name = "txtSearchClass";
            this.txtSearchClass.Size = new System.Drawing.Size(100, 21);
            this.txtSearchClass.TabIndex = 1;
            // 
            // btnSearchGrade
            // 
            this.btnSearchGrade.Location = new System.Drawing.Point(554, 79);
            this.btnSearchGrade.Name = "btnSearchGrade";
            this.btnSearchGrade.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGrade.TabIndex = 0;
            this.btnSearchGrade.Text = "查询";
            this.btnSearchGrade.UseVisualStyleBackColor = true;
            // 
            // btnSearchMajor
            // 
            this.btnSearchMajor.Location = new System.Drawing.Point(204, 79);
            this.btnSearchMajor.Name = "btnSearchMajor";
            this.btnSearchMajor.Size = new System.Drawing.Size(75, 23);
            this.btnSearchMajor.TabIndex = 0;
            this.btnSearchMajor.Text = "查询";
            this.btnSearchMajor.UseVisualStyleBackColor = true;
            // 
            // btnSearchClass
            // 
            this.btnSearchClass.Location = new System.Drawing.Point(204, 14);
            this.btnSearchClass.Name = "btnSearchClass";
            this.btnSearchClass.Size = new System.Drawing.Size(75, 23);
            this.btnSearchClass.TabIndex = 0;
            this.btnSearchClass.Text = "查询";
            this.btnSearchClass.UseVisualStyleBackColor = true;
            this.btnSearchClass.Click += new System.EventHandler(this.btnSearchClass_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtConfirmPwd);
            this.tabPage2.Controls.Add(this.txtNewPwd);
            this.tabPage2.Controls.Add(this.txtOldPwd);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.btnEsc);
            this.tabPage2.Controls.Add(this.btnOk);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(649, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "修改密码";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "班级";
            this.columnHeader6.Width = 127;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(182, 297);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "原密码：";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(208, 60);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(161, 21);
            this.txtOldPwd.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "新密码：";
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.Location = new System.Drawing.Point(208, 131);
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.Size = new System.Drawing.Size(161, 21);
            this.txtNewPwd.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(137, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "确认密码：";
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.Location = new System.Drawing.Point(208, 203);
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.Size = new System.Drawing.Size(161, 21);
            this.txtConfirmPwd.TabIndex = 2;
            this.txtConfirmPwd.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // btnEsc
            // 
            this.btnEsc.Location = new System.Drawing.Point(294, 297);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(75, 23);
            this.btnEsc.TabIndex = 0;
            this.btnEsc.Text = "取消";
            this.btnEsc.UseVisualStyleBackColor = true;
            // 
            // StudentFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 373);
            this.Controls.Add(this.tabControl1);
            this.Name = "StudentFrm";
            this.Text = "信息管理系统(学生)";
            this.Load += new System.EventHandler(this.StudentFrm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView lviStuInfo;
        private System.Windows.Forms.Button btnSeachStuNo;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtSearchClass;
        private System.Windows.Forms.Button btnSearchGrade;
        private System.Windows.Forms.Button btnSearchMajor;
        private System.Windows.Forms.Button btnSearchClass;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnEsc;
    }
}