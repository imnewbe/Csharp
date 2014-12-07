using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TestConnect
{
    public partial class StatStudentForm : Form
    {
        public StatStudentForm()
        {
            InitializeComponent();
        }

        SqlConnection connection;
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionStr =
                "Data Source=.;Initial Catalog=MySchool;Integrated Security=True";

            connection = new SqlConnection(
                connectionStr);
            try
            {
                connection.Open();
                MessageBox.Show("打开数据库成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from Student";

            SqlCommand command = new SqlCommand(sql, connection);
            int count = (int)command.ExecuteScalar();

            MessageBox.Show(string.Format("共有{0}个学生", count));
        }
    }
}
