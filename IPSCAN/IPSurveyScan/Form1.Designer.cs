namespace IPSurveyScan
{
    partial class MainFrom
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_StarIP = new System.Windows.Forms.TextBox();
            this.txt_endIP = new System.Windows.Forms.TextBox();
            this.btn_Star = new System.Windows.Forms.Button();
            this.lvi__Main = new System.Windows.Forms.ListView();
            this.lbx_ShowInfo = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "起始IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "终止IP";
            // 
            // txt_StarIP
            // 
            this.txt_StarIP.Location = new System.Drawing.Point(203, 36);
            this.txt_StarIP.Name = "txt_StarIP";
            this.txt_StarIP.Size = new System.Drawing.Size(164, 21);
            this.txt_StarIP.TabIndex = 2;
            // 
            // txt_endIP
            // 
            this.txt_endIP.Location = new System.Drawing.Point(203, 64);
            this.txt_endIP.Name = "txt_endIP";
            this.txt_endIP.Size = new System.Drawing.Size(164, 21);
            this.txt_endIP.TabIndex = 3;
            // 
            // btn_Star
            // 
            this.btn_Star.Location = new System.Drawing.Point(408, 36);
            this.btn_Star.Name = "btn_Star";
            this.btn_Star.Size = new System.Drawing.Size(75, 49);
            this.btn_Star.TabIndex = 4;
            this.btn_Star.Text = "开始";
            this.btn_Star.UseVisualStyleBackColor = true;
            this.btn_Star.Click += new System.EventHandler(this.btn_Star_Click);
            // 
            // lvi__Main
            // 
            this.lvi__Main.Location = new System.Drawing.Point(5, 104);
            this.lvi__Main.Name = "lvi__Main";
            this.lvi__Main.Size = new System.Drawing.Size(672, 263);
            this.lvi__Main.TabIndex = 5;
            this.lvi__Main.UseCompatibleStateImageBehavior = false;
            // 
            // lbx_ShowInfo
            // 
            this.lbx_ShowInfo.FormattingEnabled = true;
            this.lbx_ShowInfo.ItemHeight = 12;
            this.lbx_ShowInfo.Location = new System.Drawing.Point(5, 374);
            this.lbx_ShowInfo.Name = "lbx_ShowInfo";
            this.lbx_ShowInfo.Size = new System.Drawing.Size(672, 100);
            this.lbx_ShowInfo.TabIndex = 6;
            // 
            // MainFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 488);
            this.Controls.Add(this.lbx_ShowInfo);
            this.Controls.Add(this.lvi__Main);
            this.Controls.Add(this.btn_Star);
            this.Controls.Add(this.txt_endIP);
            this.Controls.Add(this.txt_StarIP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainFrom";
            this.Text = "IPScan";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_StarIP;
        private System.Windows.Forms.TextBox txt_endIP;
        private System.Windows.Forms.Button btn_Star;
        private System.Windows.Forms.ListView lvi__Main;
        private System.Windows.Forms.ListBox lbx_ShowInfo;
    }
}

