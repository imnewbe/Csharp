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
    public partial class Lgoin : Form
    {
        public Lgoin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public string userName
        {
            get { return txtUserName.Text; }
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            string request = string.Format("login:{0}:{1}", this.txtUserName.Text, this.txtPwd.Text);
            UDP.myUDP.Send(request);
        }

        private void Lgoin_Load(object sender, EventArgs e)
        {
            UDP.myUDP.LoginACK += u_LoginACK;
            UDP.myUDP.RegisterAck += u_RegisterAck;
        }
        void u_RegisterAck(object sender, UDP.UserEventArgs e)
        {
            if (e.Result)
            {
                MessageBox.Show("注册成功！");
            }
            else
            {
                MessageBox.Show("注册失败！");
            }
        }
        private void u_LoginACK(object sender, UDP.UserEventArgs e)
        {
            if (e.Result)
            {
                //MessageBox.Show("登录成功！");
                //此处要处理好窗口关闭问题
                
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
                
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }

        private void btn_Reg_Click(object sender, EventArgs e)
        {
            string request = string.Format("Reg:{0}:{1}", this.txtUserName.Text, this.txtPwd.Text);
            UDP.myUDP.Send(request);
        }

    }
}
