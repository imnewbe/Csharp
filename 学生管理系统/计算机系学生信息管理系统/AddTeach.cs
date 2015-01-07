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
    public partial class AddTeach : Form
    {
        public AddTeach()
        {
            InitializeComponent();
        }
        public string TeacherName
        {
            get { return this.txtAddTName.Text.Trim(); }
        }
        public string LoginPwd
        {
            get
            {
                return this.txtAddTLoginPwd.Text.Trim();
            }
        }
        public string TPhone
        {
            get
            {
                return this.txtAddTPhone.Text.Trim();
            }
        }
        public string teacherID
        {
            get
            {
                return this.txtAddTNumber.Text.Trim();

            }
        }
        public string IDNumber
        {
            get
            {
                return this.txtAddTID.Text.Trim();
            }
        }
    
        public AddTeach(
            string TeacherName,
            string teacherID,
            string TPhone,
            string IDNumber,
            string LoginPwd)
        {
            InitializeComponent();
            this.txtAddTID.Text= IDNumber;
            this.txtAddTLoginPwd.Text = LoginPwd;
            this.txtAddTName.Text = TeacherName;
            this.txtAddTPhone.Text = TPhone;
            this.txtAddTNumber.Text = teacherID;

        }
        int index;
        DataSet dataSet;
        SqlDataAdapter adapter;
        private void btnok_Click(object sender, EventArgs e)
        {
            //DataRow row = dataSet.Tables[0].NewRow();
            //row["teachName"] = this.txtAddTName.Text;
            //row["LoginPwd"] = this.txtAddTLoginPwd.Text;
            //row["Tlphone"] = this.txtAddTPhone.Text;
            //row["IDNumber"] = this.txtAddTID.Text;
            //row["LoginUsr"] = this.txtAddTNumber.Text;
            //dataSet.Tables[0].Rows.Add(row);
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }

        private void AddTeach_Load(object sender, EventArgs e)
        {
            //string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            //SqlConnection connection = new SqlConnection(connectionStr);

            //adapter = new SqlDataAdapter(
            //    "select * from Teacher", connection);
            //dataSet = new DataSet();
            //adapter.Fill(dataSet, "Tec");

            //if (dataSet.Tables[0].Rows.Count == 0)
            //{
            //    return;
            //}
        }

        private void btnesc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTeachsummit_Click(object sender, EventArgs e)
        {
            //SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            //adapter.Update(dataSet.Tables[0]);
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void btnTeachMod_Click(object sender, EventArgs e)
        {
            //这里怎么让你在listview中选择的行数传过来呢?
            //DataRow row = dataSet.Tables[0].Rows[index];
            //row["teachName"] = this.txtAddTName.Text;
            //row["LoginPwd"] = this.txtAddTLoginPwd.Text;
            //row["Tlphone"] = this.txtAddTPhone.Text;
            //row["IDNumber"] = this.txtAddTID.Text;
            //row["LoginUsr"] = this.txtAddTNumber.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
