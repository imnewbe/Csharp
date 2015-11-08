using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace udpSev
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void lviDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Server_Load(object sender, EventArgs e)
        {
            Thread udpThread = new Thread(StartUdpListener) {IsBackground = true};
            udpThread.Start();

        }

        private void StartUdpListener()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(
                IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(
                Properties.Settings.Default.port);

            byte[] recvBuffer;
            Server.RecvDataInfo recvData;
            while (true)
            {
                recvBuffer = udpClient.Receive(ref remoteEndPoint);

                recvData = new RecvDataInfo();
                recvData.Data = recvBuffer;
                recvData.ipEndPoint = remoteEndPoint;
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessUdpClient),
                    recvData);
            }
        }

        public struct RecvDataInfo
        {
            public byte[] Data;
            public IPEndPoint ipEndPoint;
        }

        private void ProcessUdpClient(Object recvObj)
        {
            Server.RecvDataInfo recvData;
            byte[] data;

            try
            {
                recvData = (RecvDataInfo) recvObj;
                string request = Encoding.Unicode.GetString(recvData.Data);

                string[] requestMsg = request.Split(':');
                switch (requestMsg[0])
                {
                        //注册
                    case "reg":
                        UserReg(requestMsg[1], recvData.ipEndPoint);
                        break;
                    case "login":
                        UserLogin(requestMsg[1]);
                }
            }
            catch (Exception e)
            {

            }

        }
        delegate void UserLoginCallback(string name, IPEndPoint ipEndPoint);
        private void UserLogin(string name, IPEndPoint ipEndPoint)
        {
            if (this.InvokeRequired)
            {
                UserLoginCallback d = new UserLoginCallback(
                    UserLogin);
                this.Invoke(d, new object[] { name, ipEndPoint });
                return;
            }
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(string.Format("[{0}]   登录聊天室",
                name));
            this.lviDisplay.Items.Add(lvi);
            lvi.ForeColor = Color.Green;
            byte[] buffer;
            string response = "USERLIST";
            UdpClient client = new UdpClient(0);
            buffer = Encoding.Unicode.GetBytes(
                        String.Format("LOGIN:{0}", name));
            client.Send(
                buffer, buffer.Length, (IPEndPoint)lviDisplay.Tag);
            
        }
        private void UserReg(string name, string pwd)
        {
            string connectionStr = "Data Source='.'; Initial Catalog='CS'; Integrated Security='true'";
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            //此处处理客户端传过来的用户名和密码。写到语句中去
            command.CommandText = string.Format("insert into UserS (UserName,UserPwd) values('{0}','{1}')",/*传过来的东西
                                                                                                            用户名和密码啊*/);
            try
            {
                int count = command.ExecuteNonQuery();
                if (count == 1)
                {
                   
                      //成功是不是该发送数据给客户端
                      byte[] buffer;
            string response = "ok";
            UdpClient client = new UdpClient(0);
            buffer = Encoding.Unicode.GetBytes(
                        String.Format("LOGIN:{0}", name));
            client.Send(
                buffer, buffer.Length, (IPEndPoint)lviDisplay.Tag);
                    
                }
            }
            catch
            {
                //应当发包给客户端，或者什么都不做。
                  byte[] buffer;
            string response = "wrong";
            UdpClient client = new UdpClient(0);
                //
            buffer = Encoding.Unicode.GetBytes(response);
            client.Send(buffer, buffer.Length/*前面连接的主机的ip*/);
                
            }
        }
    }
}
