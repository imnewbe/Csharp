using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 实验_数据库开发_二_
{
    public partial class FrmMain : Form
    {
        int index;
        DataSet dataSet;
        SqlDataAdapter adapter;

        public FrmMain()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnLoad(object sender, EventArgs e)
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Student", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Stu");

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }

            //窗体加载后默认显示第一条学生的信息
            index = 0;
            DataRow row = dataSet.Tables[0].Rows[index];

            this.tbStudentNO.Text = row["StudentNO"].ToString();
            this.tbStudentName.Text = row["StudentName"].ToString();
            this.tbSex.Text = row["Sex"].ToString();
            this.tbMajor.Text = row["Major"].ToString();
            this.tbAddress.Text = row["Address"].ToString();
            this.tbPhone.Text = row["Phone"].ToString();
        }

        /// <summary>
        /// 显示第一个学生的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFirst(object sender, EventArgs e)
        {
            index = 0;
            DataRow row = dataSet.Tables[0].Rows[index];
            this.tbStudentNO.Text = row["StudentNO"].ToString();
            this.tbStudentName.Text = row["StudentName"].ToString();
            this.tbSex.Text = row["Sex"].ToString();
            this.tbMajor.Text = row["Major"].ToString();
            this.tbAddress.Text = row["Address"].ToString();
            this.tbPhone.Text = row["Phone"].ToString();
        }

        /// <summary>
        /// 显示前一个学生的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBefore(object sender, EventArgs e)
        {
            if (index > 0)
            {
                index--;
            }
            else
            {
                return;
            }

            DataRow row = dataSet.Tables[0].Rows[index];
            this.tbStudentNO.Text = row["StudentNO"].ToString();
            this.tbStudentName.Text = row["StudentName"].ToString();
            this.tbSex.Text = row["Sex"].ToString();
            this.tbMajor.Text = row["Major"].ToString();
            this.tbAddress.Text = row["Address"].ToString();
            this.tbPhone.Text = row["Phone"].ToString();
        }

        /// <summary>
        /// 显示后一个学生的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAfter(object sender, EventArgs e)
        {
            if (index < dataSet.Tables[0].Rows.Count - 1)
            {
                index++;
            }
            else
            {
                return;
            }

            DataRow row = dataSet.Tables[0].Rows[index];
            this.tbStudentNO.Text = row["StudentNO"].ToString();
            this.tbStudentName.Text = row["StudentName"].ToString();
            this.tbSex.Text = row["Sex"].ToString();
            this.tbMajor.Text = row["Major"].ToString();
            this.tbAddress.Text = row["Address"].ToString();
            this.tbPhone.Text = row["Phone"].ToString();
        }

        /// <summary>
        /// 显示最后一个学生的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLast(object sender, EventArgs e)
        {
            index = dataSet.Tables[0].Rows.Count - 1;
            DataRow row = dataSet.Tables[0].Rows[index];
            this.tbStudentNO.Text = row["StudentNO"].ToString();
            this.tbStudentName.Text = row["StudentName"].ToString();
            this.tbSex.Text = row["Sex"].ToString();
            this.tbMajor.Text = row["Major"].ToString();
            this.tbAddress.Text = row["Address"].ToString();
            this.tbPhone.Text = row["Phone"].ToString();
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow row = dataSet.Tables[0].NewRow();
            row["StudentNO"] = this.tbStudentNO.Text;
            row["StudentName"] = this.tbStudentName.Text;
            row["Sex"] = this.tbSex.Text;
            row["Major"] = this.tbMajor.Text;
            row["Address"] = this.tbAddress.Text;
            row["Phone"] = this.tbPhone.Text;
            row["LoginId"] = this.tbStudentNO.Text;
            row["LoginPwd"] = this.tbStudentNO.Text;

            dataSet.Tables[0].Rows.Add(row);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = dataSet.Tables[0].Rows[index];

            row["StudentNO"] = this.tbStudentNO.Text;
            row["StudentName"] = this.tbStudentName.Text;
            row["Sex"] = this.tbSex.Text;
            row["Major"] = this.tbMajor.Text;
            row["Address"] = this.tbAddress.Text;
            row["Phone"] = this.tbPhone.Text;
            row["LoginId"] = this.tbStudentNO.Text;
            row["LoginPwd"] = this.tbStudentNO.Text;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataSet.Tables[0].Rows.RemoveAt(index);
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
        }
    }
}
