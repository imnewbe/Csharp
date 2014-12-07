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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSearch(object sender, EventArgs e)
        {
            string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = String.Format("select * from Student where StudentName like '%{0}%'",
                this.tbUserName.Text);

            SqlDataReader reader = command.ExecuteReader();

            this.lvStudent.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = reader["StudentNO"].ToString();
                lvi.SubItems.Add(reader["StudentName"].ToString());
                lvi.SubItems.Add(reader["Sex"].ToString());
                lvi.SubItems.Add(reader["Major"].ToString());
                lvi.SubItems.Add(reader["Phone"].ToString());
                this.lvStudent.Items.Add(lvi);
            }

            reader.Close();
            connection.Close();
        }

        /// <summary>
        /// 显示全部
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnShowAll(object sender, EventArgs e)
        {
            string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "select * from Student";

            SqlDataReader reader = command.ExecuteReader();

            this.lvStudent.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = reader["StudentNO"].ToString();
                lvi.SubItems.Add(reader["StudentName"].ToString());
                lvi.SubItems.Add(reader["Sex"].ToString());
                lvi.SubItems.Add(reader["Major"].ToString());
                lvi.SubItems.Add(reader["Phone"].ToString());
                this.lvStudent.Items.Add(lvi);
            }

            reader.Close();
            connection.Close();
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnExit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
