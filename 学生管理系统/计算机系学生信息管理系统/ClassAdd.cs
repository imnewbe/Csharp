using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 计算机系学生信息管理系统
{
    public partial class ClassAdd : Form
    {
        public ClassAdd()
        {
            InitializeComponent();
        }
        public string getClassNo
        {
            get { return this.txtClassNumber.Text; }
        }
        public string getMajorName
        {
            get
            {
                return this.txtMajorName.Text;
            }
        }
        public string getPNumber
        {
            get
            {
                return this.txtPersonCount.Text;
            }
        }
        public string getGradeClass
        {
            get
            {
                return this.txtGrade.Text;
            }
        }
        public string getBelong
        {
            get
            {
                return this.txtWHT.Text;
            }
        }
        public ClassAdd(
            string getClassNo,
            string getMajorName,
            string getPNumber,
            string getGradeClass,
            string getBelong)
        {
            InitializeComponent();
            this.txtWHT.Text = getBelong;
            this.txtPersonCount.Text = getPNumber;
            this.txtGrade.Text = getGradeClass;
            this.txtClassNumber.Text = getClassNo;
            this.txtMajorName.Text = getMajorName;
        }
        private void btnOkClassMa_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
