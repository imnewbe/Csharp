using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 实验_数据库开发_一_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLogin(object sender, EventArgs e)
        {
            string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            //字符串组合的方式，有SQL注入的风险
            command.CommandText = String.Format(
                "select count(*) from Student where LoginId='{0}' and LoginPwd='{1}'",
                this.UserNameTextBox.Text, this.PasswordTextBox.Text);

            //SQL参数化查询，能有效防止SQL注入
            command.CommandText = "select count(*) from Student where LoginId=@LoginId and LoginPwd=@PWD";
            command.Parameters.Add(new SqlParameter("LoginId", this.UserNameTextBox.Text));
            command.Parameters.Add(new SqlParameter("PWD", this.PasswordTextBox.Text));

            int count = (int)command.ExecuteScalar();
            if (count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码错误", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRegister(object sender, EventArgs e)
        {
            string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = String.Format("insert into Student (LoginId, LoginPwd) values ('{0}','{1}')",
                this.UserNameTextBox.Text, this.PasswordTextBox.Text);
            try
            {
                int count = command.ExecuteNonQuery();
                if (count == 1)
                {
                    MessageBox.Show("用户注册成功");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch
            {
            	MessageBox.Show("用户名已存在，请重新输入！", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
