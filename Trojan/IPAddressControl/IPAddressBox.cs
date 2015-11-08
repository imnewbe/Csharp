using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace IPAddressControl
{
    public partial class IPAddressBox : UserControl
    {
        [Category("属性已更改")]
        [Browsable(true)]
        public event EventHandler TextChanged;
        protected virtual void OnTextChanged(EventArgs e)
        {
            if (TextChanged != null)
            {
                TextChanged(this, e);
            }
        }

        public IPAddressBox()
        {
            InitializeComponent();
        }

        private string _text;

        [Category("外观")]
        [Description("与空间关联的文本")]
        [Browsable(true)]
        public string Text
        {
            get
            {
                if (this.textBox1.Text.Length == 0
                    || this.textBox2.Text.Length == 0
                    || this.textBox3.Text.Length == 0
                    || this.textBox4.Text.Length == 0)
                {
                    _text = "";
                    return _text;
                }
                else
                {
                    _text = Convert.ToInt32(this.textBox1.Text).ToString() + "." +
                            Convert.ToInt32(this.textBox2.Text).ToString() + "." +
                            Convert.ToInt32(this.textBox3.Text).ToString() + "." +
                            Convert.ToInt32(this.textBox4.Text).ToString();
                    return _text;
                }
             }
            set
            {
                if (value != null)
                {
                    string[] strs = value.Split('.');
                    Int32[] num = new Int32[4];
                    if (strs.Length == 4)
                    {
                        bool result = true;
                        for (int i = 0; i < 4; i++)
                        {
                            result = result && Int32.TryParse(strs[i], out num[i]);
                        }
                        if (result && num[0] <= 223 && num[1] <= 255
                            && num[2] <= 255 && num[3] <= 255)
                        {
                            this.textBox1.Text = strs[0];
                            this.textBox2.Text = strs[1];
                            this.textBox3.Text = strs[2];
                            this.textBox4.Text = strs[3];
                        }
                    }
                    else
                    {
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.textBox3.Text = "";
                        this.textBox4.Text = "";
                        _text = "";
                    }
                }
                _text = value;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            TextBox textBox;

            if (e.KeyData != Keys.Left && e.KeyValue != 39)
            {
                return;
            }

            textBox = (TextBox)sender;
            if (e.KeyValue == 37)
            {
                if (textBox.Name == "textBox4")
                {
                    this.textBox3.Focus();
                }
                else if (textBox.Name == "textBox3")
                {
                    this.textBox2.Focus();
                }
                else if (textBox.Name == "textBox2")
                {
                    this.textBox1.Focus();
                }
                else if (textBox.Name == "textBox1")
                {
                    this.textBox4.Focus();
                }
            }
            else
            {
                if (textBox.Name == "textBox1")
                {
                    this.textBox2.Focus();
                }
                else if (textBox.Name == "textBox2")
                {
                    this.textBox3.Focus();
                }
                else if (textBox.Name == "textBox3")
                {
                    this.textBox4.Focus();
                }
                else if (textBox.Name == "textBox4")
                {
                    this.textBox1.Focus();
                }
            }
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            //判断输入的值是否为数字或删除键
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == '.')
            {

                if (e.KeyChar!=8 && textBox.Text.Length == 2)
                {
                    string tempStr = textBox.Text + e.KeyChar;
                    if (textBox.Name == "textBox1")
                    {
                        if (Int32.Parse(tempStr) > 223)
                        {
                            textBox.Text = "223";
                            textBox.Focus();
                            MessageBox.Show(tempStr + " 不是一个有效项目。请指定一个介于 1 和 223 之间的数值。");
                            return;
                        }
                        this.textBox2.Focus();
                        this.textBox2.SelectAll();
                    }
                    else if (textBox.Name == "textBox2")
                    {
                        if (Int32.Parse(tempStr)>255)
                        {
                            textBox.Text = "255";
                            textBox.Focus();
                            MessageBox.Show(tempStr + " 不是一个有效项目。请指定一个介于 1 和 255 之间的数值。");
                            return;
                        }
                        this.textBox3.Focus();
                        this.textBox3.SelectAll();
                    }
                    else if (textBox.Name == "textBox3")
                    {
                        if (Int32.Parse(tempStr) > 255)
                        {
                            textBox.Text = "255";
                            textBox.Focus();
                            MessageBox.Show(tempStr + " 不是一个有效项目。请指定一个介于 1 和 223 之间的数值。");
                            return;
                        }
                        this.textBox4.Focus();
                        this.textBox4.SelectAll();
                    }
                    else if (textBox.Name == "textBox4")
                    {
                        if (Int32.Parse(tempStr) > 255)
                        {
                            textBox.Text = "255";
                            textBox.Focus();
                            MessageBox.Show(tempStr + " 不是一个有效项目。请指定一个介于 1 和 223 之间的数值。");
                            return;
                        }
                    }
                }
                else if (e.KeyChar == 8)
                {
                    if (textBox.Name == "textBox4" && textBox.Text.Length == 0)
                    {
                        this.textBox3.Focus();
                    }
                    else if (textBox.Name == "textBox3" && textBox.Text.Length == 0)
                    {
                        this.textBox2.Focus();
                    }
                    else if (textBox.Name == "textBox2" && textBox.Text.Length == 0)
                    {
                        this.textBox1.Focus();
                    }
                }
                else if (e.KeyChar == '.')
                {
                    e.Handled = true;
                    if (textBox.Name == "textBox1")
                    {
                        this.textBox2.Focus();
                    }
                    else if (textBox.Name == "textBox2")
                    {
                        this.textBox3.Focus();
                    }
                    else if (textBox.Name == "textBox3")
                    {
                        this.textBox4.Focus();
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }
    }
}