namespace Client
{
    partial class Client
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
            this.btnGetList = new System.Windows.Forms.Button();
            this.lst_print = new System.Windows.Forms.ListBox();
            this.btnDownFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetList
            // 
            this.btnGetList.Location = new System.Drawing.Point(41, 267);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(144, 23);
            this.btnGetList.TabIndex = 0;
            this.btnGetList.Text = "获取图片列表";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // lst_print
            // 
            this.lst_print.FormattingEnabled = true;
            this.lst_print.ItemHeight = 12;
            this.lst_print.Location = new System.Drawing.Point(12, 12);
            this.lst_print.Name = "lst_print";
            this.lst_print.Size = new System.Drawing.Size(244, 148);
            this.lst_print.TabIndex = 1;
            // 
            // btnDownFile
            // 
            this.btnDownFile.Location = new System.Drawing.Point(311, 267);
            this.btnDownFile.Name = "btnDownFile";
            this.btnDownFile.Size = new System.Drawing.Size(75, 23);
            this.btnDownFile.TabIndex = 2;
            this.btnDownFile.Text = "下载图片";
            this.btnDownFile.UseVisualStyleBackColor = true;
            this.btnDownFile.Click += new System.EventHandler(this.btnDownFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 321);
            this.Controls.Add(this.btnDownFile);
            this.Controls.Add(this.lst_print);
            this.Controls.Add(this.btnGetList);
            this.Name = "Form1";
            this.Text = "Client";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetList;
        private System.Windows.Forms.ListBox lst_print;
        private System.Windows.Forms.Button btnDownFile;
    }
}

