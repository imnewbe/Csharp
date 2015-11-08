namespace None
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvi_Show = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ipABStart = new IPAddressControl.IPAddressBox();
            this.ipABStop = new IPAddressControl.IPAddressBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnShDown = new System.Windows.Forms.Button();
            this.btnRebot = new System.Windows.Forms.Button();
            this.btnShDownT = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvi_Show
            // 
            this.lvi_Show.Location = new System.Drawing.Point(3, 13);
            this.lvi_Show.Name = "lvi_Show";
            this.lvi_Show.ShowItemToolTips = true;
            this.lvi_Show.Size = new System.Drawing.Size(688, 255);
            this.lvi_Show.TabIndex = 0;
            this.lvi_Show.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvi_Show);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 271);
            this.panel1.TabIndex = 1;
            // 
            // ipABStart
            // 
            this.ipABStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ipABStart.BackgroundImage")));
            this.ipABStart.Location = new System.Drawing.Point(63, 12);
            this.ipABStart.MaximumSize = new System.Drawing.Size(157, 22);
            this.ipABStart.MinimumSize = new System.Drawing.Size(157, 22);
            this.ipABStart.Name = "ipABStart";
            this.ipABStart.Size = new System.Drawing.Size(157, 22);
            this.ipABStart.TabIndex = 2;
            // 
            // ipABStop
            // 
            this.ipABStop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ipABStop.BackgroundImage")));
            this.ipABStop.Location = new System.Drawing.Point(63, 61);
            this.ipABStop.MaximumSize = new System.Drawing.Size(157, 22);
            this.ipABStop.MinimumSize = new System.Drawing.Size(157, 22);
            this.ipABStop.Name = "ipABStop";
            this.ipABStop.Size = new System.Drawing.Size(157, 22);
            this.ipABStop.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "起始IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "终止IP";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(241, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 71);
            this.btnScan.TabIndex = 5;
            this.btnScan.Text = "扫描";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnShDown
            // 
            this.btnShDown.Location = new System.Drawing.Point(339, 12);
            this.btnShDown.Name = "btnShDown";
            this.btnShDown.Size = new System.Drawing.Size(75, 71);
            this.btnShDown.TabIndex = 5;
            this.btnShDown.Text = "关机";
            this.btnShDown.UseVisualStyleBackColor = true;
            this.btnShDown.Click += new System.EventHandler(this.btnShDown_Click);
            // 
            // btnRebot
            // 
            this.btnRebot.Location = new System.Drawing.Point(443, 12);
            this.btnRebot.Name = "btnRebot";
            this.btnRebot.Size = new System.Drawing.Size(75, 71);
            this.btnRebot.TabIndex = 5;
            this.btnRebot.Text = "重启";
            this.btnRebot.UseVisualStyleBackColor = true;
            this.btnRebot.Click += new System.EventHandler(this.btnRebot_Click);
            // 
            // btnShDownT
            // 
            this.btnShDownT.Location = new System.Drawing.Point(536, 12);
            this.btnShDownT.Name = "btnShDownT";
            this.btnShDownT.Size = new System.Drawing.Size(75, 71);
            this.btnShDownT.TabIndex = 5;
            this.btnShDownT.Text = "定时关机";
            this.btnShDownT.UseVisualStyleBackColor = true;
            this.btnShDownT.Click += new System.EventHandler(this.btnShDownT_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 372);
            this.Controls.Add(this.btnShDownT);
            this.Controls.Add(this.btnRebot);
            this.Controls.Add(this.btnShDown);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ipABStop);
            this.Controls.Add(this.ipABStart);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "管理终端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvi_Show;
        private System.Windows.Forms.Panel panel1;
        private IPAddressControl.IPAddressBox ipABStart;
        private IPAddressControl.IPAddressBox ipABStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnShDown;
        private System.Windows.Forms.Button btnRebot;
        private System.Windows.Forms.Button btnShDownT;
    }
}

