using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private IPAddress _serverIp;
        public TcpClient _tcpClient;
       

        private void btnGetList_Click(object sender, EventArgs e)
        {
            if (_tcpClient == null)
            {
                _tcpClient=new TcpClient();
            }
            if (_tcpClient.Connected)
            {
                _tcpClient.Close();
            }
            else
            {
                _tcpClient.Connect("192.168.128.1", 10010);
            }
           
                NetworkStream clientStream = _tcpClient.GetStream();
                Byte[] sendBytes = Encoding.UTF8.GetBytes("list");
                clientStream.Write(sendBytes, 0, sendBytes.Length);
           
                if (clientStream.CanRead)
                {
                    byte[] bytes = new byte[_tcpClient.ReceiveBufferSize];
                    clientStream.Read(bytes, 0, (int) _tcpClient.ReceiveBufferSize);
                    string returndata = Encoding.UTF8.GetString(bytes);
                    this.lst_print.Items.Add(returndata);

                }
                
              
            
        }

        private void btnDownFile_Click(object sender, EventArgs e)
        {
            string send = this.lst_print.SelectedItem.ToString();  
            TcpClient clientDown = new TcpClient();
            clientDown.Connect("192.168.128.1",10010);
            NetworkStream clientStream = clientDown.GetStream();
            BinaryWriter bw = new BinaryWriter(clientStream);
            BinaryReader br = new BinaryReader(clientStream);
            bw.Write(send);
            //接收文件操作;


        }
      
    }
}
