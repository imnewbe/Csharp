namespace 计算机系学生信息管理系统
{
    partial class AddTeach
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddTName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddTNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddTID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddTPhone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddTLoginPwd = new System.Windows.Forms.TextBox();
            this.btnok = new System.Windows.Forms.Button();
            this.btnTeachMod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名：";
            // 
            // txtAddTName
            // 
            this.txtAddTName.Location = new System.Drawing.Point(82, 31);
            this.txtAddTName.Name = "txtAddTName";
            this.txtAddTName.Size = new System.Drawing.Size(422, 21);
            this.txtAddTName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "教师号：";
            // 
            // txtAddTNumber
            // 
            this.txtAddTNumber.Location = new System.Drawing.Point(82, 65);
            this.txtAddTNumber.Name = "txtAddTNumber";
            this.txtAddTNumber.Size = new System.Drawing.Size(422, 21);
            this.txtAddTNumber.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "身份证号：";
            // 
            // txtAddTID
            // 
            this.txtAddTID.Location = new System.Drawing.Point(82, 108);
            this.txtAddTID.Name = "txtAddTID";
            this.txtAddTID.Size = new System.Drawing.Size(422, 21);
            this.txtAddTID.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "手机号：";
            // 
            // txtAddTPhone
            // 
            this.txtAddTPhone.Location = new System.Drawing.Point(82, 146);
            this.txtAddTPhone.Name = "txtAddTPhone";
            this.txtAddTPhone.Size = new System.Drawing.Size(422, 21);
            this.txtAddTPhone.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "登陆密码：";
            // 
            // txtAddTLoginPwd
            // 
            this.txtAddTLoginPwd.Location = new System.Drawing.Point(82, 187);
            this.txtAddTLoginPwd.Name = "txtAddTLoginPwd";
            this.txtAddTLoginPwd.Size = new System.Drawing.Size(422, 21);
            this.txtAddTLoginPwd.TabIndex = 1;
            // 
            // btnok
            // 
            this.btnok.Location = new System.Drawing.Point(101, 247);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(75, 23);
            this.btnok.TabIndex = 2;
            this.btnok.Text = "增加";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // btnTeachMod
            // 
            this.btnTeachMod.Location = new System.Drawing.Point(352, 247);
            this.btnTeachMod.Name = "btnTeachMod";
            this.btnTeachMod.Size = new System.Drawing.Size(75, 23);
            this.btnTeachMod.TabIndex = 3;
            this.btnTeachMod.Text = "修改";
            this.btnTeachMod.UseVisualStyleBackColor = true;
            this.btnTeachMod.Click += new System.EventHandler(this.btnTeachMod_Click);
            // 
            // AddTeach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 302);
            this.Controls.Add(this.btnTeachMod);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.txtAddTLoginPwd);
            this.Controls.Add(this.txtAddTPhone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddTID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddTNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddTName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddTeach";
            this.Text = "教师信息维护";
            this.Load += new System.EventHandler(this.AddTeach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddTName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddTNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddTID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddTPhone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddTLoginPwd;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Button btnTeachMod;
    }
}