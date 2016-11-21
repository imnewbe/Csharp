namespace client
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCon = new System.Windows.Forms.Button();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.txtSerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabComPro = new System.Windows.Forms.TabControl();
            this.commandexc = new System.Windows.Forms.TabPage();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbMsg = new System.Windows.Forms.TextBox();
            this.proxychoose = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvLog = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabComPro.SuspendLayout();
            this.commandexc.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCon);
            this.panel1.Controls.Add(this.nudPort);
            this.panel1.Controls.Add(this.txtSerIP);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 47);
            this.panel1.TabIndex = 0;
            // 
            // btnCon
            // 
            this.btnCon.Location = new System.Drawing.Point(453, 17);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(75, 23);
            this.btnCon.TabIndex = 12;
            this.btnCon.Text = "链接";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(324, 19);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Minimum = new decimal(new int[] {
            1025,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(64, 21);
            this.nudPort.TabIndex = 11;
            this.nudPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudPort.Value = new decimal(new int[] {
            6666,
            0,
            0,
            0});
            // 
            // txtSerIP
            // 
            this.txtSerIP.Location = new System.Drawing.Point(93, 19);
            this.txtSerIP.Name = "txtSerIP";
            this.txtSerIP.Size = new System.Drawing.Size(117, 21);
            this.txtSerIP.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "服务器IP：";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.tabComPro);
            this.panel2.Location = new System.Drawing.Point(2, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(592, 180);
            this.panel2.TabIndex = 15;
            // 
            // tabComPro
            // 
            this.tabComPro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabComPro.Controls.Add(this.commandexc);
            this.tabComPro.Controls.Add(this.proxychoose);
            this.tabComPro.Location = new System.Drawing.Point(4, 21);
            this.tabComPro.Name = "tabComPro";
            this.tabComPro.SelectedIndex = 0;
            this.tabComPro.Size = new System.Drawing.Size(582, 156);
            this.tabComPro.TabIndex = 0;
            // 
            // commandexc
            // 
            this.commandexc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.commandexc.Controls.Add(this.btnSend);
            this.commandexc.Controls.Add(this.tbMsg);
            this.commandexc.Location = new System.Drawing.Point(4, 22);
            this.commandexc.Name = "commandexc";
            this.commandexc.Padding = new System.Windows.Forms.Padding(3);
            this.commandexc.Size = new System.Drawing.Size(574, 130);
            this.commandexc.TabIndex = 0;
            this.commandexc.Text = "Poweshell";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(446, 80);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // tbMsg
            // 
            this.tbMsg.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbMsg.Location = new System.Drawing.Point(4, 6);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(567, 68);
            this.tbMsg.TabIndex = 2;
            // 
            // proxychoose
            // 
            this.proxychoose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.proxychoose.Location = new System.Drawing.Point(4, 22);
            this.proxychoose.Name = "proxychoose";
            this.proxychoose.Padding = new System.Windows.Forms.Padding(3);
            this.proxychoose.Size = new System.Drawing.Size(574, 130);
            this.proxychoose.TabIndex = 1;
            this.proxychoose.Text = "Proxy";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lvLog);
            this.panel3.Location = new System.Drawing.Point(6, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(584, 120);
            this.panel3.TabIndex = 16;
            // 
            // lvLog
            // 
            this.lvLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLog.FullRowSelect = true;
            this.lvLog.GridLines = true;
            this.lvLog.Location = new System.Drawing.Point(0, 0);
            this.lvLog.Name = "lvLog";
            this.lvLog.Size = new System.Drawing.Size(584, 120);
            this.lvLog.TabIndex = 15;
            this.lvLog.UseCompatibleStateImageBehavior = false;
            this.lvLog.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "源主机";
            this.columnHeader2.Width = 103;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "目的主机";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "数据";
            this.columnHeader4.Width = 262;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 374);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Client";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.panel2.ResumeLayout(false);
            this.tabComPro.ResumeLayout(false);
            this.commandexc.ResumeLayout(false);
            this.commandexc.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.TextBox txtSerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabComPro;
        private System.Windows.Forms.TabPage commandexc;
        private System.Windows.Forms.TabPage proxychoose;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbMsg;

    }
}

