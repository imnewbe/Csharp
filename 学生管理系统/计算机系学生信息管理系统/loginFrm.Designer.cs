namespace 计算机系学生信息管理系统
{
    partial class loginFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbnLogin = new System.Windows.Forms.Button();
            this.btnEsc = new System.Windows.Forms.Button();
            this.txtUserNm = new System.Windows.Forms.TextBox();
            this.rbnAdmin = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.rbnTeach = new System.Windows.Forms.RadioButton();
            this.rbnStudent = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbnLogin
            // 
            this.tbnLogin.BackColor = System.Drawing.Color.White;
            this.tbnLogin.Location = new System.Drawing.Point(202, 197);
            this.tbnLogin.Name = "tbnLogin";
            this.tbnLogin.Size = new System.Drawing.Size(75, 23);
            this.tbnLogin.TabIndex = 0;
            this.tbnLogin.Text = "登陆";
            this.tbnLogin.UseVisualStyleBackColor = false;
            this.tbnLogin.Click += new System.EventHandler(this.tbnLogin_Click);
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.Color.White;
            this.btnEsc.Location = new System.Drawing.Point(324, 197);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(75, 23);
            this.btnEsc.TabIndex = 0;
            this.btnEsc.Text = "取消";
            this.btnEsc.UseVisualStyleBackColor = false;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // txtUserNm
            // 
            this.txtUserNm.Location = new System.Drawing.Point(218, 74);
            this.txtUserNm.Name = "txtUserNm";
            this.txtUserNm.Size = new System.Drawing.Size(170, 21);
            this.txtUserNm.TabIndex = 1;
            // 
            // rbnAdmin
            // 
            this.rbnAdmin.AutoSize = true;
            this.rbnAdmin.Checked = true;
            this.rbnAdmin.Location = new System.Drawing.Point(218, 36);
            this.rbnAdmin.Name = "rbnAdmin";
            this.rbnAdmin.Size = new System.Drawing.Size(59, 16);
            this.rbnAdmin.TabIndex = 2;
            this.rbnAdmin.TabStop = true;
            this.rbnAdmin.Text = "管理员";
            this.rbnAdmin.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码：";
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(218, 120);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '#';
            this.txtPasswd.Size = new System.Drawing.Size(170, 21);
            this.txtPasswd.TabIndex = 1;
            // 
            // rbnTeach
            // 
            this.rbnTeach.AutoSize = true;
            this.rbnTeach.Location = new System.Drawing.Point(341, 36);
            this.rbnTeach.Name = "rbnTeach";
            this.rbnTeach.Size = new System.Drawing.Size(47, 16);
            this.rbnTeach.TabIndex = 2;
            this.rbnTeach.TabStop = true;
            this.rbnTeach.Text = "教师";
            this.rbnTeach.UseVisualStyleBackColor = true;
            // 
            // rbnStudent
            // 
            this.rbnStudent.AutoSize = true;
            this.rbnStudent.Location = new System.Drawing.Point(284, 35);
            this.rbnStudent.Name = "rbnStudent";
            this.rbnStudent.Size = new System.Drawing.Size(47, 16);
            this.rbnStudent.TabIndex = 4;
            this.rbnStudent.TabStop = true;
            this.rbnStudent.Text = "学生";
            this.rbnStudent.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "忘记密码没办法";
            // 
            // loginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(447, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rbnStudent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rbnTeach);
            this.Controls.Add(this.rbnAdmin);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.txtUserNm);
            this.Controls.Add(this.btnEsc);
            this.Controls.Add(this.tbnLogin);
            this.MaximizeBox = false;
            this.Name = "loginFrm";
            this.Text = "登陆";
            this.Load += new System.EventHandler(this.loginFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button tbnLogin;
        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.TextBox txtUserNm;
        private System.Windows.Forms.RadioButton rbnAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.RadioButton rbnTeach;
        private System.Windows.Forms.RadioButton rbnStudent;
        private System.Windows.Forms.Label label3;
    }
}

