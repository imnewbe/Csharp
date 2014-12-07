using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _04_DataSet
{
    public partial class FrmStudent : Form
    {
        public String StuNO
        {
            get
            {
                return this.textBox1.Text;
            }
        }

        public String StuName
        {
            get
            {
                return this.textBox2.Text;
            }
        }

        public FrmStudent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
