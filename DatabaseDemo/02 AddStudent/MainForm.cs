using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoadGrade
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string connectionStr =
                "Data Source=.;Initial Catalog=MySchool;Integrated Security=True";

            SqlConnection connection = new SqlConnection(
                connectionStr);
            connection.Open();

            string sql = String.Format("insert into Student (LoginId, LoginPwd, StudentNO, StudentName, Address, Phone, Email, Sex, Major, ClassId) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                this.tbStudentNO.Text, 
                this.tbStudentNO.Text,
                this.tbStudentNO.Text,
                this.tbStudentName.Text,
                this.tbAddress.Text,
                this.tbPhone.Text,
                this.tbEmail.Text,
                this.rdbBoy.Checked ? "男" : "女",
                this.cboClass.Text,
                this.cboGrade.Text);
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();


        }
    }
}
