using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SelectStudent
{
    public partial class SelectStudentForm : Form
    {
        public SelectStudentForm()
        {
            InitializeComponent();
        }

        private void Searchbutton_Click(object sender, EventArgs e)
        {
            string connectionStr = "Data Source=.;Initial Catalog=MySchool;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionStr);

            conn.Open();

            SqlCommand command = conn.CreateCommand();
            command.CommandText = "select * from Student";

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = reader["LoginId"].ToString();
                lvi.SubItems.Add(reader["StudentName"].ToString());
                lvi.SubItems.Add(reader["StudentNO"].ToString());

                this.lvStudent.Items.Add(lvi);
            }

            reader.Close();
            conn.Close();
        }
    }
}
