using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 计算机系学生信息管理系统
{
    public partial class loginFrm : Form
    {
        public loginFrm()
        {
            InitializeComponent();
        }
        public string uid;
        public bool getStatus()
        {
            if (rbnAdmin.Checked)
            {
                return true;
            }
            else
                return false;
        }
        public bool getStudentsStatus()
        {
            if (rbnStudent.Checked)
            {
                return true;
            }
            else { return false; }
        }

        private void tbnLogin_Click(object sender, EventArgs e)
        {
            //这里添加了注册后密码加密成md5，但是有加salt。
            //这样要验证登陆的的时候需要取出数据库里的数据来比对，不能解密出来；
            if (rbnTeach.Checked)
            {
                string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select count(*) from Teacher where LoginUsr=@LoginUsr and LoginPwd=@LoginPwd";
                command.Parameters.Add(new SqlParameter("LoginUsr", this.txtUserNm.Text));
                command.Parameters.Add(new SqlParameter("LoginPwd", this.txtPasswd.Text));
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    uid = this.txtUserNm.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (rbnAdmin.Checked)
            {
                string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select count(*) from admin where adminPsw=@adminPsw and adminUsr=@adminUsr";
                command.Parameters.Add(new SqlParameter("adminUsr", this.txtUserNm.Text));
                command.Parameters.Add(new SqlParameter("adminPsw", this.txtPasswd.Text));
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    uid = this.txtUserNm.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();

            }
            if (rbnStudent.Checked)
            {
                string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "select count(*) from Students where StuNo=@StuNo and ID=@ID";
                command.Parameters.Add(new SqlParameter("StuNo", this.txtUserNm.Text));
                command.Parameters.Add(new SqlParameter("ID", this.txtPasswd.Text));
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    uid = this.txtUserNm.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();

            }
        }
        

        private void loginFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
