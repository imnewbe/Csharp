using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TcpClient.Properties;

namespace TcpClient
{
    public partial class tcpClient : Form
    {
        private System.Net.Sockets.TcpClient _client;

        private delegate void RevFiledelegate();

        private RevFiledelegate revFiledelegate;
        public tcpClient()
        {
            InitializeComponent();
            revFiledelegate =new RevFiledelegate(DownFile);
        }

        private void btnRequste_Click(object sender, EventArgs e)
        {
          Thread connectThread=new Thread(connectToServer);
            connectThread.Start();
        }

        private void connectToServer()
        {
            AsyncCallback requestCallback=new AsyncCallback(RequestCallback);
            _client=new System.Net.Sockets.TcpClient();
            IAsyncResult result = _client.BeginConnect(Properties.Settings.Default.ServerIp, Properties.Settings.Default.ServerPort, requestCallback, _client);
        }

        private void RequestCallback(IAsyncResult iarResult)

        {
            try
            {
               _client  = (System.Net.Sockets.TcpClient) iarResult.AsyncState;
                _client.EndConnect(iarResult);
                DateTime nowTime = DateTime.Now;
                while (nowTime.AddSeconds(1)>DateTime.Now)
                {        
                }
                if (_client != null)
                {
                    //NetworkStream stream = _client.GetStream();
                    // 列表
                    const int bufferSize = 4096;
                    System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                    client.Connect(IPAddress.Parse(Settings.Default.ServerIp), Settings.Default.ServerPort);
                    NetworkStream clientNetworkStream = client.GetStream();
                    string request = "list";
                    byte[] requestBytes = Encoding.ASCII.GetBytes(request);
                    clientNetworkStream.Write(requestBytes, 0, requestBytes.Length);
                    byte[] responseBytes = new byte[bufferSize];
                    MemoryStream memory = new MemoryStream();
                    int byteread = 0;
                        byteread = clientNetworkStream.Read(responseBytes, 0, bufferSize);
                        memory.Write(responseBytes, 0, byteread);
                    clientNetworkStream.Close();
                    client.Close();

                    byte[] buffer = new byte[memory.Length];
                    memory.Position = 0;
                    memory.Read(buffer, 0, buffer.Length);
                    string response = Encoding.ASCII.GetString(buffer);
                    string[] fileStrings = response.Split(':');
                    this.lbxList.DataSource = fileStrings;
                }

            }
            catch (Exception)
            {              
              _client.Close();             
           }
        }

        private void getList()
        {
            const int bufferSize = 4096;
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            client.Connect(IPAddress.Parse(Settings.Default.ServerIp), Settings.Default.ServerPort);
            NetworkStream clientNetworkStream = client.GetStream();
            string request = "list";
            byte[] requestBytes = Encoding.ASCII.GetBytes(request);
            clientNetworkStream.Write(requestBytes, 0, requestBytes.Length);
            byte[] responseBytes = new byte[bufferSize];
            MemoryStream memory = new MemoryStream();
            int byteread = 0;
           // do
            //{
                byteread = clientNetworkStream.Read(responseBytes, 0, bufferSize);
                memory.Write(responseBytes, 0, byteread);

           // } while (byteread > 0);
            clientNetworkStream.Close();
            client.Close();
            byte[] buffer = new byte[memory.Length];
            memory.Position = 0;
            memory.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer);
            string[] fileStrings = response.Split(':');
            this.lbxList.DataSource = fileStrings;

        }

        private void btnDownFile_Click(object sender, EventArgs e)
        {
           Thread revFileThread=new Thread(revFile);
            revFileThread.Start();
        }

        private void revFile()
        {
            try
            {
                IAsyncResult result = revFiledelegate.BeginInvoke(null,null);
                revFiledelegate.EndInvoke(result);
            }
            catch (Exception)
            {
                
                 DateTime now = DateTime.Now;
                 while (now.AddSeconds(2) > DateTime.Now) { break; }
                 
            }
            
        }

        private void DownFile()
        {
            const int bufferSize = 4096;
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            client.Connect(Properties.Settings.Default.ServerIp,Properties.Settings.Default.ServerPort);
            NetworkStream clientNetworkStream = client.GetStream();
            string request = "file" + this.lbxList.SelectedItem.ToString();
            byte[] requetBytes = Encoding.ASCII.GetBytes(request);
            clientNetworkStream.Write(requetBytes, 0, requetBytes.Length);
            byte[] responseBytes = new byte[bufferSize];
            MemoryStream memStream = new MemoryStream();
            int byteRead = 0;
            do
            {
                byteRead = clientNetworkStream.Read(responseBytes, 0, bufferSize);
                memStream.Write(responseBytes, 0, byteRead);
            } while (byteRead > 0);
            clientNetworkStream.Close();
            client.Close();
            //显示照片
            this.pictureBox1.Image = Image.FromStream(memStream);
        }
    }
}
