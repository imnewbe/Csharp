using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Lin : Form
    {
        public Lin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //登录把框框里面的封装发到远端。
            IPEndPoint remotPoint = new IPEndPoint(IPAddress.Any,0);
            UdpClient udpClient = new UdpClient(0);
            string requset = this.txt_UserName.Text+":"+this.txt_Pwd.Text;
            byte[] bufferBytes = Encoding.Unicode.GetBytes(requset);
            udpClient.Send(bufferBytes, bufferBytes.Length,
                new IPEndPoint(IPAddress.Parse(Properties.Settings.Default /*服务器地址*/),Properties.Settings.Default/*端口地址*/));
            byte[] revBytes;
            while (true)
            {
                //接收服务器发来的信息，什么列表啊什么退出登录啊什么的
                
            }

        }
    }
}
