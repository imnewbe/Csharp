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
    public partial class StuAdd : Form
    {
        public StuAdd()
        {
            InitializeComponent();
        }
        public string StuName
        {
            get { return this.txtStuName.Text.Trim(); }
        }
        public string StuNo
        {
            get
            {
                return this.txtStuNo.Text.Trim();
            }
        }
        public string StuID
        {
            get { return this.txtStuID.Text.Trim(); }
        }
        public string getClass
        {
            get { return this.cmbClass.Text.Trim(); }
        }
        public string getMajor
        {
            get { return this.cmbMajor.Text.Trim(); }
        }
        public string getSex
        {
            get
            {
                if (this.rbnMale.Checked)
                {
                    return "男";
                }
                else
                {
                    return "女";
                }
            }
        }
        public StuAdd(
            string StuName,
            string getClass,
            string StuNo,
            string getMajor,
            string StuID,
            string getSex)
        {
            InitializeComponent();

            this.cmbMajor.Items.Add("网络工程");
            this.cmbMajor.Items.Add("软件工程");
            this.cmbClass.Items.Add("12522");
            this.cmbClass.Items.Add("12521");

            this.txtStuName.Text = StuName;
            this.txtStuNo.Text = StuNo;
            this.txtStuID.Text = StuID;
            this.cmbClass.SelectedItem = getClass.Trim();
            this.cmbMajor.SelectedItem = getMajor.Trim();
            if (getSex == "男")
            {
                this.rbnMale.Checked = true;
            }
            else
            {
                this.rbnFemale.Checked = true;
            }
        }
        int index;
        DataSet dataSet;
        SqlDataAdapter adapter;
        private void StuAdd_Load(object sender, EventArgs e)
        {
            //string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            //SqlConnection connection = new SqlConnection(connectionStr);

            //adapter = new SqlDataAdapter(
            //    "select * from Students", connection);
            //dataSet = new DataSet();
            //adapter.Fill(dataSet, "Stu");

            //if (dataSet.Tables[0].Rows.Count == 0)
            //{
            //    return;
            //}


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //DataRow row = dataSet.Tables[0].NewRow();
            //row["StuNo"] = this.txtStuNo.Text;
            //row["StuName"] = this.txtStuName.Text;
            //row["ID"] = this.txtStuID.Text;
            //row["Major"] = this.cmbMajor.Text;
            //row["Class"] = this.cmbClass.Text;
            //if (rbnMale.Checked)
            //{
            //    row["Sex"] = "男";
            //}
            //else
            //{
            //    row["Sex"] = "女";
            //}
            //dataSet.Tables[0].Rows.Add(row);
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btnSummit_Click(object sender, EventArgs e)
        {
            //SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            //adapter.Update(dataSet.Tables[0]);
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void btnModiStu_Click(object sender, EventArgs e)
        {
           
            
            //DataRow row = dataSet.Tables[0].Rows[index];
            //row["StuNo"] = this.txtStuNo.Text;
            //row["StuName"] = this.txtStuName.Text;
            //row["ID"] = this.txtStuID.Text;
            //row["Major"] = this.cmbMajor.Text;
            //row["Class"] = this.cmbClass.Text;
            //if (rbnMale.Checked)
            //{
            //    row["Sex"] = "男";
            //}
            //else
            //{
            //    row["Sex"] = "女";
            //}
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
