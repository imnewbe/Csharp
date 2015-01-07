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
    public partial class techFrm : Form
    {
        public techFrm()
        {
            InitializeComponent();
        }
        public techFrm(string uid)
        {
            InitializeComponent();
            this.txtLoginUsrTeach.Text = uid;
        }

        private void btnStuNumber_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Students where StuNo like '%{0}%'", this.txtStuNo.Text);
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviStuInfo.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["StuName"].ToString();
                lvi.SubItems.Add(read["Class"].ToString());
                lvi.SubItems.Add(read["StuNo"].ToString());
                lvi.SubItems.Add(read["Major"].ToString());
                lvi.SubItems.Add(read["ID"].ToString());
                lvi.SubItems.Add(read["Sex"].ToString());
                this.lviStuInfo.Items.Add(lvi);
            }

            read.Close();
        }

        private void btnStuName_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Students where StuName like '%{0}%'", this.txtStuName.Text);
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviStuInfo.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["StuName"].ToString();
                lvi.SubItems.Add(read["Class"].ToString());
                lvi.SubItems.Add(read["StuNo"].ToString());
                lvi.SubItems.Add(read["Major"].ToString());
                lvi.SubItems.Add(read["ID"].ToString());
                lvi.SubItems.Add(read["Sex"].ToString());
                this.lviStuInfo.Items.Add(lvi);
            }

            read.Close();

        }

        private void btnStuClass_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from Students where Class like '%{0}%'", this.txtStuClass.Text);
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviStuInfo.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["StuName"].ToString();
                lvi.SubItems.Add(read["Class"].ToString());
                lvi.SubItems.Add(read["StuNo"].ToString());
                lvi.SubItems.Add(read["Major"].ToString());
                lvi.SubItems.Add(read["ID"].ToString());
                lvi.SubItems.Add(read["Sex"].ToString());
                this.lviStuInfo.Items.Add(lvi);
            }

            read.Close();

        }

        private void btnOkChange_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select LoginPwd from Teacher where LoginUsr = '{0}'", this.txtLoginUsrTeach.Text.Trim());
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            if (read.Read())
            {
                string oldPass = read.GetString(0).Trim();
                if (oldPass == this.txtOldPwd.Text)
                {
                    if (this.txtNewPwd.Text.Trim() == "" || this.txtSureNewPwd.Text.Trim() == "")
                    {
                        MessageBox.Show("密码和确认密码都不能为空");
                        return;
                    }
                    else if (this.txtSureNewPwd.Text.Trim() != this.txtNewPwd.Text.Trim())
                    {
                        MessageBox.Show("两次密码不一致");
                        this.txtNewPwd.Text = "";
                        this.txtSureNewPwd.Text = "";
                        return;

                    }
                    else
                    {
                        
                        string SQLUpdata = string.Format("update Teacher set LoginPwd= '{0}' where LoginUsr='{1}'", this.txtSureNewPwd.Text.Trim(), this.txtLoginUsrTeach.Text.Trim());
                        SqlHelper.ExecuteSql(SQLUpdata);
                        MessageBox.Show("修改成功");
                    }

                }
                else
                {
                    MessageBox.Show("旧密码错误，或者为空");
                    return;
                }



            }
            else
            {
                MessageBox.Show("用户名不存在");
            }

           
        }

        private void txtStuNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void techFrm_Load(object sender, EventArgs e)
        {

        }


       

       

        
    }
}
