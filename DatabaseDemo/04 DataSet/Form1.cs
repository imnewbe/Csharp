using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _04_DataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlDataAdapter adapter;
        DataSet dataSet;
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionStr =
                "Server=.; Database=MySchool; Integrated Security=true";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Student",
                connection
                );
            dataSet = new DataSet();
            adapter.Fill(dataSet);

            this.lvStudent.BeginUpdate();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = row["StudentNo"].ToString();
                lvi.SubItems.Add(row["StudentName"].ToString());

                this.lvStudent.Items.Add(lvi);
            }
            this.lvStudent.EndUpdate();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lvStudent.FocusedItem == null)
            {
                return;
            }

            int index = this.lvStudent.FocusedItem.Index;
            dataSet.Tables[0].Rows[index].Delete();

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet);

            this.lvStudent.Items.RemoveAt(index);
        }

        private void 增加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStudent stu = new FrmStudent();
            if (DialogResult.OK != stu.ShowDialog())
            {
                return;
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = stu.StuNO;
            lvi.SubItems.Add(stu.StuName);
            this.lvStudent.Items.Add(lvi);

            DataRow row = dataSet.Tables[0].NewRow();

            row["LoginId"] = stu.StuNO;
            row["LoginPwd"] = "12345";
            row["StudentNO"] = stu.StuNO;
            row["StudentName"] = stu.StuName;
            dataSet.Tables[0].Rows.Add(row);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet);
        }
    }
}
