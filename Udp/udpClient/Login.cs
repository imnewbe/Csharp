using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace udpClient
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Thread uThread =new Thread(startListing){IsBackground = true};
            uThread.Start();


        }

        private void startListing()
        {
            IPEndPoint remotPoint = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(0);
            string requset = "login"+this.txt_UserName.Text + ":" + this.txt_Pwd.Text;
            byte[] bufferBytes = Encoding.Unicode.GetBytes(requset);
            udpClient.Send(bufferBytes, bufferBytes.Length,
                new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIp), Properties.Settings.Default.sport));
            byte[] revBytes;
            while (true)
            {
                //发来的是成功，就登录成功。
                revBytes = udpClient.Receive(ref remotPoint);
                requset = Encoding.Unicode.GetString(revBytes);
                if (requset.StartsWith("ok")) 
                {

                    //收到消息做出处理。
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    return;
                }

            }
            
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(
                IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(0);

            string request = "reg"+this.txt_UserName.Text + ":" + this.txt_Pwd.Text;
            byte[] buffer = Encoding.Unicode.GetBytes(request);

            udpClient.Send(buffer, buffer.Length,
                new IPEndPoint(
                    IPAddress.Parse(Properties.Settings.Default.ServerIp),
                    Properties.Settings.Default.sport));
            byte[] recvBuffer;
            while (true)
            {
                recvBuffer = udpClient.Receive(ref remoteEndPoint);

                request = Encoding.Unicode.GetString(recvBuffer);
                if (request.StartsWith("regdown)"))
                {
                    MessageBox.Show("reg in");
                }
            }
        }
    }
}
