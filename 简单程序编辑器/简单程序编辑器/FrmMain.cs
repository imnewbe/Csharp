using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace 简单程序编辑器
{
    public partial class FrmMain : Form
    {
        ArrayList Keywords;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Keywords = new ArrayList();
            Keywords.Add("using");
            Keywords.Add("System");
            Keywords.Add("public");
            Keywords.Add("private");
            Keywords.Add("void");
            Keywords.Add("int");
            Keywords.Add("char");
            Keywords.Add("string");
            Keywords.Add("return");
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowNewForm(object sender, EventArgs e)
        {
            FrmChild child = new FrmChild();
            child.MdiParent = this;
            child.Text = "Class" + this.MdiChildren.Length + ".cpp";
            child.Keywords = this.Keywords;
            child.Show();
            child.FormClosed += new FormClosedEventHandler(child_FormClosed);

            TreeNode node = new TreeNode();
            node.Text = child.Text;
            this.tvSolution.Nodes.Add(node);
        }

        /// <summary>
        /// 子窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (e.CloseReason == CloseReason.FormOwnerClosing)
            {
                return;
            }

            FrmChild child = (FrmChild)sender;
            foreach (TreeNode node in tvSolution.Nodes)
            {
                if (node.Text == child.Text)
                {
                    node.Remove();
                }
            }
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "代码文件(*.cs)|*.cs|所有文件(*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }

            FrmChild child = new FrmChild();
            child.MdiParent = this;
            child.Text = openFileDialog.FileName;
            child.Keywords = this.Keywords;
            child.Show();
            child.ContentText.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed);
        }

        /// <summary>
        /// 颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiColor_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            ColorDialog colorDlg = new ColorDialog();
            DialogResult dr = colorDlg.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.StopTextChanged();
            child.ContentText.SelectionColor = colorDlg.Color;
            child.StartTextChanged();
        }

        /// <summary>
        /// 字体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFont_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FontDialog fontDlg = new FontDialog();
            DialogResult dr = fontDlg.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.SelectionFont = fontDlg.Font;
        }

        #region 缩进
        private void tsbIncreaseIndent_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.SelectionIndent += 30;
        }

        private void tsbReduceIndent_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.SelectionIndent -= 30;
        }
        #endregion

        /// <summary>
        /// 注释
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbAnnotation_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.StopTextChanged();

            int index = child.ContentText.SelectionStart;
            int line = child.ContentText.GetLineFromCharIndex(
                child.ContentText.SelectionStart);

            child.ContentText.Text = child.ContentText.Text.Insert(
                child.ContentText.SelectionStart, "//");
            string strline = child.ContentText.Lines[line];
            child.ContentText.Select(index, index + strline.Length);
            child.ContentText.SelectionColor = Color.Green;

            child.ContentText.Select(index, 0);
            child.StartTextChanged();
            return;
        }

        #region 窗口菜单
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion

        #region 编辑菜单
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.Redo();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                return;
            }

            FrmChild child = (FrmChild)this.ActiveMdiChild;
            child.ContentText.SelectAll();
        }
        #endregion
    }
}
