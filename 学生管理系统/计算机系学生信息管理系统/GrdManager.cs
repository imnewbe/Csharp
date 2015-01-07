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
    public partial class GrdManager : Form
    {
        public GrdManager()
        {
            InitializeComponent();
        }
        public string getClassName
        {
            get
            {
                return this.cmbClassName.Text.Trim();
            }
        }
        public string getMon
        {
            get
            {
                return this.cmbMon.Text.Trim();
            }
        }
        public string getTue
        {
            get
            {
                return this.cmbTue.Text.Trim();
            }
        }
        public string getWed
        {
            get
            {
                return this.cmbwed.Text.Trim();
            }
        }
        public string getThur
        {
            get
            {
                return this.cmbThur.Text.Trim();

            }
        }
        public string getFri
        {
            get
            {
                return this.cmbFrid.Text.Trim();

            }
        }
        public string getGrade
        {
            get
            {
                return this.cmbGrede.Text.Trim();
            }
        }
        public GrdManager(
            string getClassName,
            string getMon,
            string getTue,
            string getWed,
            string getThur,
            string getFri,
            string getGrade)
        {
            InitializeComponent();

        }
        private void GrdManager_Load(object sender, EventArgs e)
        {
            this.cmbClassName.Items.Add("c#");
            this.cmbClassName.Items.Add("操作系统");
            this.cmbMon.Items.Add("有");
            this.cmbMon.Items.Add("无");
            this.cmbTue.Items.Add("有");
            this.cmbTue.Items.Add("无");
            this.cmbwed.Items.Add("有");
            this.cmbwed.Items.Add("无");
            this.cmbThur.Items.Add("有");
            this.cmbThur.Items.Add("无");
            this.cmbFrid.Items.Add("有");
            this.cmbFrid.Items.Add("无");
            this.cmbGrede.Items.Add("12");
            this.cmbGrede.Items.Add("11");
        }

        private void btnOkGrd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
