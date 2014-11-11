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
    public partial class FrmChild : Form
    {
        public RichTextBox ContentText
        {
            get
            {
                return this.richTextBox1;
            }
        }

        public ArrayList Keywords;

        public FrmChild()
        {
            InitializeComponent();
        }

        public void StopTextChanged()
        {
            this.richTextBox1.TextChanged -= new System.EventHandler(
                this.richTextBox1_TextChanged);
        }

        public void StartTextChanged()
        {
            this.richTextBox1.TextChanged += new System.EventHandler(
                this.richTextBox1_TextChanged);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.richTextBox1.SelectedText))
            {
                return;
            }

            this.richTextBox1.SelectionColor = Color.Black;//默认颜色-黑色
            int index = this.richTextBox1.SelectionStart;   //当前选中文本位置

            string strline = this.richTextBox1.Lines[       //当前行
                this.richTextBox1.GetLineFromCharIndex(
                this.richTextBox1.SelectionStart)];
            Console.WriteLine(strline);
            string[] wordList = strline.Trim().Split(' ', ';', '.', '{', '}', '(', ')');
            if (wordList.Length == 0)
            {
                return;
            }

            foreach (string word in wordList)
            {
                if (this.Keywords.Contains(word))   //处理关键字变色
                {
                    this.richTextBox1.Select(index - word.Length, word.Length);
                    this.richTextBox1.SelectionColor = Color.Blue;

                    this.richTextBox1.Select(index, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
                //
                else if (word.StartsWith("//"))      //处理行尾注释
                {
                    this.richTextBox1.Select(index-2, strline.Length - index+2);
                    this.richTextBox1.SelectionColor = Color.Green;

                    this.richTextBox1.Select(index, 0);
                    break;
                }
                else   //非关键字
                {
                    this.richTextBox1.Select(index - word.Length, word.Length);
                    this.richTextBox1.SelectionColor = Color.Black;

                    this.richTextBox1.Select(index, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
        }
    }
}
