using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyException
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Length == 0 && txtEmail.Text.Length == 0)
            {
                MessageBox.Show("请填写姓名和Email。", "填写不完整", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }
            try
            {
                SaveInfo(txtName.Text, txtEmail.Text);
            }
            catch (EmailErrorException ex)
            {
                MessageBox.Show(ex.Message, "Email格式错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show("保存成功。", "成功", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        private bool SaveInfo(string name, string email)
        {
            string[] subStrings = email.Split('@');
            if (subStrings.Length != 2)
            {
                throw new EmailErrorException();
            }
            else
            {
                int index = subStrings[1].IndexOf(".");
                if (index <= 0)
                {
                    throw new EmailErrorException();
                }

                if (subStrings[1][subStrings[1].Length - 1] == '.')
                {
                    throw new EmailErrorException();
                }
            }

            return true;
        }
    }
}
