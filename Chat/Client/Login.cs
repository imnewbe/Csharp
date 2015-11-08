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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            UDP.myUDP.LoginACK += new UDP.UserEventHander(u_LoginACK);
            UDP.myUDP.RegisterAck += new UDP.UserEventHander(u_RegisterAck);
        }
          public string GetUserName()
        {
            return this.UserNameTextBox.Text;
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
        delegate void u_LoginACKCallback(object sender, UDP.UserEventArgs e);

        private void u_LoginACK(object sender, UDP.UserEventArgs e)
        {
            if (this.InvokeRequired)
            {
                u_LoginACKCallback d = new u_LoginACKCallback(u_LoginACK);
                this.Invoke(d, new object[] {sender, e});
                return;
            }

            if (e.Result)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("登录失败！");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UDP.myUDP.Send(UDP.DataType.Login,
            new string[] { this.UserNameTextBox.Text, this.PasswordTextBox.Text });
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            UDP.myUDP.Send(UDP.DataType.Register,
                new string[] { this.UserNameTextBox.Text, this.PasswordTextBox.Text });
        }
    }
}
