namespace TcpClient
{
    partial class tcpClient
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
            this.btnRequste = new System.Windows.Forms.Button();
            this.lbxList = new System.Windows.Forms.ListBox();
            this.btnDownFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRequste
            // 
            this.btnRequste.Location = new System.Drawing.Point(36, 290);
            this.btnRequste.Name = "btnRequste";
            this.btnRequste.Size = new System.Drawing.Size(75, 23);
            this.btnRequste.TabIndex = 0;
            this.btnRequste.Text = "request";
            this.btnRequste.UseVisualStyleBackColor = true;
            this.btnRequste.Click += new System.EventHandler(this.btnRequste_Click);
            // 
            // lbxList
            // 
            this.lbxList.FormattingEnabled = true;
            this.lbxList.ItemHeight = 12;
            this.lbxList.Location = new System.Drawing.Point(12, 12);
            this.lbxList.Name = "lbxList";
            this.lbxList.Size = new System.Drawing.Size(161, 268);
            this.lbxList.TabIndex = 1;
            // 
            // btnDownFile
            // 
            this.btnDownFile.Location = new System.Drawing.Point(237, 290);
            this.btnDownFile.Name = "btnDownFile";
            this.btnDownFile.Size = new System.Drawing.Size(75, 23);
            this.btnDownFile.TabIndex = 2;
            this.btnDownFile.Text = "Down";
            this.btnDownFile.UseVisualStyleBackColor = true;
            this.btnDownFile.Click += new System.EventHandler(this.btnDownFile_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(193, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 261);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // tcpClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 348);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDownFile);
            this.Controls.Add(this.lbxList);
            this.Controls.Add(this.btnRequste);
            this.Name = "tcpClient";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRequste;
        private System.Windows.Forms.ListBox lbxList;
        private System.Windows.Forms.Button btnDownFile;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

