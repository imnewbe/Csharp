using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        private TcpListener _tcpListener;
        Thread _tcpThread;
        string FilePath = Environment.CurrentDirectory;

        private void StartTcpListener()
        {
            if (_tcpListener == null)
            {
                _tcpListener = new TcpListener(GetLocalHostIP(), 10010);
            }
            _tcpListener.Start();
            byte[] bytes = new byte[1024];
            string data;
            while (true)
            {
                TcpClient client = _tcpListener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                int i = stream.Read(bytes, 0, bytes.Length);
                while (i !=0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    if (data == "list")
                    {
                        ThreadPool.QueueUserWorkItem(SendList, client);
                    }
                    else
                    {
                        break;
                        
                    }
                }
                
                ThreadPool.QueueUserWorkItem(SendFile, client);
            }
        }


        private void SendList(object list)
        {
            TcpClient client = (TcpClient) list;
            NetworkStream clienStream = client.GetStream();
            BinaryReader brBinaryReader = new BinaryReader(clienStream);
            BinaryWriter writer = new BinaryWriter(clienStream);
            try
            {
                while (true)
                {
                    string msg = brBinaryReader.ReadString();
                    
                    if (msg.Length > 0)
                    {
                        DirectoryInfo directory = new DirectoryInfo(FilePath);
                        foreach (var file in directory.GetFiles("*.jpg")) 
                        {
                            writer.Write(file.Name.ToString());
                            
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                brBinaryReader.Close();
                writer.Close();
            }

            catch (Exception)
            {

            }
        }
        private void SendFile(object hehe)
        {
            TcpListener rcvListener = new TcpListener(GetLocalHostIP(),12121);
            rcvListener.Start();




            
        }

        /// <summary>
        /// 应当要处理请求的图片，且只传送请求的图片
        /// </summary>
        /// <returns></returns>
        private IPAddress GetLocalHostIP()
        {
            var addrList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            if (addrList.Length == 0)
            {
                return IPAddress.Loopback;
            }

            var localHostIp = addrList[0];
            foreach (IPAddress ipaddr in addrList)
            {
                if (ipaddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    localHostIp = ipaddr;
                    break;
                }
            }

            return localHostIp;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            _tcpThread = new Thread(StartTcpListener) {IsBackground = true};
            _tcpThread.Start();

        }
    }
}
