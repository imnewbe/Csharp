using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridView
{
    public partial class DGVForm : Form
    {
        public DGVForm()
        {
            InitializeComponent();
        }

        private void DGVForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“mySchoolDataSet.Teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter.Fill(this.mySchoolDataSet.Teacher);

        }

        private void Savebutton_Click(object sender, EventArgs e)
        {
            this.teacherTableAdapter.Update(this.mySchoolDataSet.Teacher);
        }

        private void Refrushbutton_Click(object sender, EventArgs e)
        {
            this.teacherTableAdapter.Fill(this.mySchoolDataSet.Teacher);
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
