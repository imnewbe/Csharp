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
    public partial class StudentFrm : Form
    {
        public StudentFrm()
        {
            InitializeComponent();
        }
        public StudentFrm(string uid)
        {
            InitializeComponent();
            string Uid = uid;
        }
        private void StudentFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchClass_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select StuNo from Students where ID = '{0}'");
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            
        }
    }
}
