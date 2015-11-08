using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CPwd : Form
    {
        public CPwd()
        {
            InitializeComponent();

        }

        public CPwd(string s)
        {
            InitializeComponent();
            username = s;

        }

        public string UUName
        {
            get { return username; }
            //操作改密码
            //发送密码到服务端
            
        }

        private void CPwd_Load(object sender, EventArgs e)
        {
            UDP.myUDP.CgPwd += CgPwdACK;
        }

        private string username;
        private void btnDown_Click(object sender, EventArgs e)
        {
            if (this.txtNewPwd.Text != this.txtSurePwd.Text)
            {
                return;
            }
            //这里应当再发送一个用户名,只是当前登录的用户
            string request = string.Format("change:{0}:{1}:{2}", txtOldPwd.Text, txtSurePwd.Text,username);
            UDP.myUDP.Send(request);
        }

        private void CgPwdACK(object sender, UDP.UserEventArgs e)
        {
            if (e.Result)
            {
                MessageBox.Show("改密码成功");
            }
            else
            {
                MessageBox.Show("fail");

            }
        }
    }
}
