using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DataBaseHelper
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = String.Format(
                "select * from Student where StudentName like '%{0}%'",
                this.tbStudentName.Text);
            SqlDataReader reader = SqlHelper.ExecuteReader(sql);

            this.lvStudent.Items.Clear();
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = reader["LoginId"].ToString();
                lvi.SubItems.Add(reader["StudentName"].ToString());
                lvi.SubItems.Add(reader["StudentNO"].ToString());
                lvi.SubItems.Add(reader["UserStateId"].ToString() == "0" ? "非活动状态" : "活动状态");
                this.lvStudent.Items.Add(lvi);
            }
            reader.Close();
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.lvStudent.SelectedItems)
            {
                string sql = String.Format("delete from Student where LoginId='{0}'",
                    lvi.Text);
                SqlHelper.ExecuteSql(sql);

                lvi.Remove();
            }
        }
    }
}