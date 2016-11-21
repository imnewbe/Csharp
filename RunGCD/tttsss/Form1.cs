using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace tttsss
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        private TcpListener tcpListener;
        Thread tcpThread;
        private void btn_start_Click(object sender, EventArgs e)
        {
            this.btn_start.Enabled = false;
            tcpThread=new Thread(new ThreadStart(StartTcpListener));
            tcpThread.IsBackground = true;
            tcpThread.Start();
            ListViewItem lvi=new ListViewItem(DateTime.Now.ToString());
            lvi.SubItems.Add(String.Format("start:({0}:{1})", GetLocalHostIP(),this.port.Value));
            this.lvi_info.Items.Add(lvi);
        }
        private void StartTcpListener()
        {
            if (tcpListener == null)
            {
                tcpListener = new TcpListener(GetLocalHostIP(), (int)this.port.Value);
            }
            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessTcpClient), client);
            }
        }

        public void ProcessTcpClient(object Clientitem)
        {
            try
            {


                TcpClient client = (TcpClient) Clientitem;
                NetworkStream clientStream = client.GetStream();
                bool exit = false;
                while (!exit)
                {
                    byte[] readBytes = new byte[4];
                    int readcount = clientStream.Read(readBytes, 0, readBytes.Length);
                    int length = BitConverter.ToInt32(readBytes, 0);
                    readBytes = new byte[length];
                    readcount = clientStream.Read(readBytes, 0, readBytes.Length);
                    string msg = Encoding.Unicode.GetString(readBytes, 0, readcount).Trim();
                    ListViewItem lvItem = new ListViewItem();
                    lvItem.Text = DateTime.Now.ToString();
                    string Msg = String.Format("{0}==>{1}:{2}", client.Client.RemoteEndPoint.ToString(),
                        client.Client.LocalEndPoint.ToString(), msg);
                    lvItem.SubItems.Add(Msg);
                    AddListViewItem(lvItem);
                    Hashtable hs = new Hashtable();
                    //这里其实不需要localip了
                    hs.Add(client.Client.RemoteEndPoint,client.Client.LocalEndPoint);
                    string[] rlMsg = msg.Split('#');
                    string strReply = "无法识别的命令";
                    switch (rlMsg[0].ToUpper())
                    {
                        case "PS":
                            ProcessStartInfo process = new ProcessStartInfo();
                            process.FileName = "powershell.exe";
                            process.Arguments = rlMsg[1];
                            process.RedirectStandardOutput = true;
                            process.UseShellExecute = false;
                            process.CreateNoWindow = true;
                            Process pr = Process.Start(process);
                            StreamReader stream = pr.StandardOutput;
                            strReply = stream.ReadToEnd();
                            break;
                        case "Proxy":
                            //代理监听应当记录对方端口和ip；放到一个list里面
                            //数据包转发怎么转发。提高效率。
                            //找到端口 转发包。 那么拆包是不是不应该全拆了。拆个头或许就好了啊。
                            break;

                    }
                    byte[] writeBytes = Encoding.Unicode.GetBytes(strReply);
                    clientStream.Write(writeBytes, 0, writeBytes.Length);
                    lvItem = new ListViewItem();
                    lvItem.Text = DateTime.Now.ToString();
                    Msg = String.Format("{0} ==> {1} : {2}",
                        client.Client.LocalEndPoint.ToString(),
                        client.Client.RemoteEndPoint.ToString(), strReply);
                    lvItem.SubItems.Add(Msg);
                    lvItem.ForeColor = Color.DarkRed;
                    AddListViewItem(lvItem);

                }
                clientStream.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        delegate void AddListViewItemCallback(ListViewItem lvi);
        private void AddListViewItem(ListViewItem lvi)
        {
            if (this.lvi_info.InvokeRequired)
            {
                AddListViewItemCallback d = new AddListViewItemCallback(AddListViewItem);
                this.Invoke(d, new object[] { lvi });
                return;
            }

            this.lvi_info.Items.Add(lvi);
        }
        private IPAddress GetLocalHostIP()
        {
            IPAddress[] addrList;
            IPAddress localHostIP;

            addrList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            if (addrList.Length == 0)
            {
                return IPAddress.Loopback;
            }

            localHostIP = addrList[0];
            foreach (IPAddress ipaddr in addrList)
            {
                if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    localHostIP = ipaddr;
                    break;
                }
            }

            return localHostIP;
        }
    }
}
