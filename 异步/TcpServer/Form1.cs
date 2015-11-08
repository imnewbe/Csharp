using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpServer
{
    public partial class server : Form
    {
        public server()
        {

            InitializeComponent();
            //_revMsgdelegate = AsyncRevMsg;
            _localAddress = GetLocalHostIP();
        }

        private AutoResetEvent autoReset;
        private readonly IPAddress _localAddress;
        private const int port = 12121;
        private TcpListener _tcpListener;
        private TcpClient _tcpClient;
        private BinaryReader _br;
        private BinaryWriter _bw;
        private NetworkStream _networkStream;
        private delegate void revMsgdelegate(out string revMsg);
        private readonly revMsgdelegate _revMsgdelegate;

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
        ////接收消息后处理
        //private void AsyncRevMsg(out string revMsg)
        //{
        //    revMsg = null;
        //    try
        //    {
        //        revMsg = _br.ReadString();
        //    }
        //    catch (Exception)
        //    {
        //        if (_br != null)
        //        {
        //            _br.Close();
        //        }
        //        if (_bw != null)
        //        {
        //            _bw.Close();
        //        }
        //        if (_tcpClient != null)
        //        {
        //            _tcpClient.Close();
        //        }
        //        //处理消息方法
        //    }
        //}
        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                
                Thread threads = new Thread(acceptConnect){IsBackground = true};
                threads.Start();
                MessageBox.Show("Running");
            }
            catch (Exception)
            {

                MessageBox.Show("wrong");
            }
            
        }

        private void acceptConnect()
        {
            _tcpListener = new TcpListener(_localAddress, port);
            _tcpListener.Start();
            autoReset = new AutoResetEvent(false);
            while (true)
            {

                AsyncCallback acceptCallback = acceptClientCallback;
                IAsyncResult result = _tcpListener.BeginAcceptTcpClient(acceptCallback, _tcpListener);
                autoReset.WaitOne();
            }
           
        }

        private void acceptClientCallback(IAsyncResult iar)
        {
            try
            {
                autoReset.Set();
                TcpListener listener = (TcpListener)iar.AsyncState;
                TcpClient client = listener.EndAcceptTcpClient(iar);
                //处理client
              //  if (_tcpClient != null)
               // {
                    int bufferSize = 4096;
                    NetworkStream clientStream = client.GetStream();
                    byte[] bufferBytes = new byte[bufferSize];
                    int readBytes = 0;
                    readBytes = clientStream.Read(bufferBytes, 0, bufferSize);
                    string requset = Encoding.ASCII.GetString(bufferBytes).Substring(0, readBytes);
                    if (requset.StartsWith("list"))
                    {
                        byte[] responseBytes = PictureHelper.GetFileListBytes();
                        clientStream.Write(responseBytes, 0, responseBytes.Length);
                    }
                    else if (requset.StartsWith("file"))
                    {
                        string[] requstStrings = requset.Split(':');
                        string filename = requstStrings[1];
                        byte[] dataBytes = PictureHelper.GetFileBytes(System.IO.Path.Combine(Properties.Settings.Default.Dir, filename));
                        clientStream.Write(dataBytes, 0, dataBytes.Length);

                    }
               // }
            }
           catch (Exception)
            {
                
                //do someting
            }
            
            

        }

        private void ControlClient(object clientII)
        {
            int bufferSize = 4096;
            TcpClient client = (TcpClient) clientII;
            NetworkStream clientStream = client.GetStream();
            byte[] bufferBytes=new byte[bufferSize];
            int readBytes = 0;
            readBytes = clientStream.Read(bufferBytes, 0, bufferSize);
            string requset = Encoding.ASCII.GetString(bufferBytes).Substring(0, readBytes);
            if (requset.StartsWith("list"))
            {
                byte[] responseBytes = PictureHelper.GetFileListBytes();
                clientStream.Write(responseBytes,0,responseBytes.Length);
            }
            else if (requset.StartsWith("file"))
            {
                string[] requstStrings = requset.Split(':');
                string filename = requstStrings[1];
                byte[] dataBytes = PictureHelper.GetFileBytes(System.IO.Path.Combine(Properties.Settings.Default.Dir,filename));
                clientStream.Write(dataBytes,0,dataBytes.Length);

            }
           
        }
    }
}
