namespace udpSev
{
    partial class Server
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
            this.lviDisplay = new System.Windows.Forms.ListView();
            this.shij = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lviDisplay
            // 
            this.lviDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.shij});
            this.lviDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lviDisplay.GridLines = true;
            this.lviDisplay.Location = new System.Drawing.Point(0, 0);
            this.lviDisplay.Name = "lviDisplay";
            this.lviDisplay.Size = new System.Drawing.Size(726, 385);
            this.lviDisplay.TabIndex = 0;
            this.lviDisplay.UseCompatibleStateImageBehavior = false;
            this.lviDisplay.View = System.Windows.Forms.View.Details;
            this.lviDisplay.SelectedIndexChanged += new System.EventHandler(this.lviDisplay_SelectedIndexChanged);
            // 
            // shij
            // 
            this.shij.Text = "事件";
            this.shij.Width = 124;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 385);
            this.Controls.Add(this.lviDisplay);
            this.MaximizeBox = false;
            this.Name = "Server";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Server_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lviDisplay;
        private System.Windows.Forms.ColumnHeader shij;
    }
}

