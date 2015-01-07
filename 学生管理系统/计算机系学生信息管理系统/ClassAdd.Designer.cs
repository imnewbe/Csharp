namespace 计算机系学生信息管理系统
{
    partial class ClassAdd
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
            this.txtClassNumber = new System.Windows.Forms.TextBox();
            this.btnOkClassMa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMajorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGrade = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWHT = new System.Windows.Forms.TextBox();
            this.btnEscClMa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "班级号：";
            // 
            // txtClassNumber
            // 
            this.txtClassNumber.Location = new System.Drawing.Point(74, 24);
            this.txtClassNumber.Name = "txtClassNumber";
            this.txtClassNumber.Size = new System.Drawing.Size(160, 21);
            this.txtClassNumber.TabIndex = 1;
            // 
            // btnOkClassMa
            // 
            this.btnOkClassMa.Location = new System.Drawing.Point(39, 242);
            this.btnOkClassMa.Name = "btnOkClassMa";
            this.btnOkClassMa.Size = new System.Drawing.Size(75, 23);
            this.btnOkClassMa.TabIndex = 2;
            this.btnOkClassMa.Text = "确定";
            this.btnOkClassMa.UseVisualStyleBackColor = true;
            this.btnOkClassMa.Click += new System.EventHandler(this.btnOkClassMa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "专业名：";
            // 
            // txtMajorName
            // 
            this.txtMajorName.Location = new System.Drawing.Point(74, 63);
            this.txtMajorName.Name = "txtMajorName";
            this.txtMajorName.Size = new System.Drawing.Size(160, 21);
            this.txtMajorName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "人数：";
            // 
            // txtPersonCount
            // 
            this.txtPersonCount.Location = new System.Drawing.Point(74, 104);
            this.txtPersonCount.Name = "txtPersonCount";
            this.txtPersonCount.Size = new System.Drawing.Size(160, 21);
            this.txtPersonCount.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "年级：";
            // 
            // txtGrade
            // 
            this.txtGrade.Location = new System.Drawing.Point(74, 151);
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new System.Drawing.Size(160, 21);
            this.txtGrade.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "系别";
            // 
            // txtWHT
            // 
            this.txtWHT.Location = new System.Drawing.Point(74, 190);
            this.txtWHT.Name = "txtWHT";
            this.txtWHT.Size = new System.Drawing.Size(160, 21);
            this.txtWHT.TabIndex = 1;
            // 
            // btnEscClMa
            // 
            this.btnEscClMa.Location = new System.Drawing.Point(178, 242);
            this.btnEscClMa.Name = "btnEscClMa";
            this.btnEscClMa.Size = new System.Drawing.Size(75, 23);
            this.btnEscClMa.TabIndex = 2;
            this.btnEscClMa.Text = "取消";
            this.btnEscClMa.UseVisualStyleBackColor = true;
            // 
            // ClassAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 277);
            this.Controls.Add(this.btnEscClMa);
            this.Controls.Add(this.btnOkClassMa);
            this.Controls.Add(this.txtWHT);
            this.Controls.Add(this.txtGrade);
            this.Controls.Add(this.txtPersonCount);
            this.Controls.Add(this.txtMajorName);
            this.Controls.Add(this.txtClassNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ClassAdd";
            this.Text = "班级管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassNumber;
        private System.Windows.Forms.Button btnOkClassMa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMajorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersonCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGrade;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWHT;
        private System.Windows.Forms.Button btnEscClMa;
    }
}