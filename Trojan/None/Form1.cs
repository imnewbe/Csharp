using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabMSService;
using 基于Ping的主机扫描小工具;

namespace None
{
    public partial class Form1 : Form
    {
        private List<String> IPList;
        public Form1()
        {
            InitializeComponent();
        }

        public void send(string msg,IPEndPoint point)
        {
            if (String.IsNullOrEmpty(msg))
            {
                return;
            }
            byte[] bufBytes = Encoding.Unicode.GetBytes(msg);
            UdpClient udpClient = new UdpClient();
            udpClient.Send(bufBytes, bufBytes.Length,point);
        }

        public void send(string msg)
        {
            if (String.IsNullOrEmpty(msg))
            {
                return;
            }
            byte[] bufBytes = Encoding.Unicode.GetBytes(msg);
            UdpClient udpClient = new UdpClient();
            udpClient.Send(bufBytes, bufBytes.Length,ipEndPoint);
        }
        private void send(string msg,IPAddress ipAddress)
        {
            if (String.IsNullOrEmpty(msg))
            {
                return;
            }
            byte[] bufBytes = Encoding.Unicode.GetBytes(msg);
            IPEndPoint endPoint=new IPEndPoint(ipAddress,12121);
            UdpClient udpClient= new UdpClient();
            udpClient.Send(bufBytes, bufBytes.Length,/*这里是怎么转换成后面这个*/ endPoint);
        }
        private void ScanHost()
        {
            foreach (string ip in this.IPList)
            {
               //发个消息看对方有没有装这个软件
                IPAddress testAddress;
                IPAddress.TryParse(ip, out testAddress);
                send("hello there",testAddress);
                Thread.Sleep(500);
            }
        }
       
        private void LoadNetRemote()
        {
            this.lvi_Show.BeginUpdate();
            this.lvi_Show.Clear();

            IPAddress startAddress;
            IPAddress stopAddress;

            IPAddress.TryParse(this.ipABStart.Text, out startAddress);
            IPAddress.TryParse(this.ipABStop.Text, out stopAddress);

            long startValue = IPAddressToNumber(startAddress);
            long stopValue = IPAddressToNumber(stopAddress);

            int remoteID = 1;
            for (long currentValue = startValue; currentValue <= stopValue; currentValue++)
            {
                IPAddress currentIP = IPAddress.Parse(NumberToIPAddress(currentValue));

                ListViewItem lvi = new ListViewItem();
                lvi.Text = currentIP.ToString();
                lvi.ImageIndex = 0;
                this.lvi_Show.Items.Add(lvi);

                IPList.Add(currentIP.ToString());

                remoteID++;
            }
            this.lvi_Show.EndUpdate();
        }

        private long IPAddressToNumber(IPAddress ip)
        {
            byte[] buffer = ip.GetAddressBytes();

            long number = ((long)buffer[0] << 32);
            number += buffer[1] << 16;
            number += buffer[2] << 8;
            number += buffer[3];

            return number;
        }

        private string NumberToIPAddress(long number)
        {
            long tempValue = number;
            long s1 = tempValue >> 32;
            long s2 = (tempValue - (s1 << 32)) >> 16;
            long s3 = (tempValue - (s1 << 32) - (s2 << 16)) >> 8;
            long s4 = tempValue - (s1 << 32) - (s2 << 16) - (s3 << 8);

            return s1.ToString() + "." + s2.ToString() + "." + s3.ToString() + "." + s4.ToString();
        }

        private Thread t;
        private void btnScan_Click(object sender, EventArgs e)
        {
            LoadNetRemote();

            t = new Thread(ScanHost);
            t.IsBackground = true;
            t.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.IPList = new List<string>();
            Thread th = new Thread(starListener) {IsBackground = true};
            th.Start();
            Thread.Sleep(500);
        }
        readonly UdpClient udpClient = new UdpClient(12121);
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Broadcast, 12121);

        private void starListener()
        {
            try
            {
                IPEndPoint reEndPoint =new IPEndPoint(IPAddress.Any,0);
                while (true)
                {
                    var revBuffer = udpClient.Receive(ref reEndPoint);
                    var revdata = new revDataInfo {Data = revBuffer, ipEndPoint = reEndPoint};
                    ThreadPool.QueueUserWorkItem(processClient, revdata);

                }
            }
            catch (Exception)
            {
                
               
            }
        }

        private void processClient(object revObject)
        {
            try
            {
                var revdata = (revDataInfo) revObject;
                string request = Encoding.Unicode.GetString(revdata.Data);
                string[] Msg = request.Split(':');
                switch (Msg[0])
                {
                    
                    case "hello there":
                        returnMsg(revdata.ipEndPoint);
                        break;
                    case "ShutDown":
                        ShDnCmp(Msg[1]);
                        break;
                    case "reboot":
                        Reboot(Msg[1]);
                        break;
                    case "ShDnTime":
                        ShutDiwnInT(Convert.ToDouble(Msg[1]));
                        break;
                    case "got":
                        gotSendMsg(revdata.ipEndPoint);
                        break;


                }
            
        }
            catch (Exception)
            {
                
                
            }
        }

        private void gotSendMsg(IPEndPoint ip)
        {
            
            if (FindListViewItem(this.lvi_Show, ip.Address.ToString()))
            {
               //什么都不做
            }
            else
            {
                //这里应该是点亮的。
                //lvi_Show.Items.Remove();
            }
        }
        delegate bool FindListViewItemCallback(ListView lv, string text);
        private bool FindListViewItem(ListView lv, string text)
        {
            if (lv.InvokeRequired)
            {
                FindListViewItemCallback d = new FindListViewItemCallback(
                    FindListViewItem);
                return (bool)this.Invoke(d, new object[] { lv, text });
            }

            ListViewItem lvi = lv.FindItemWithText(text);
            return lvi != null;
        }
        private void ShutDiwnInT(double Msg)
        {
            MessageBox.Show("test");
            Thread.Sleep(DateTime.Now.AddMinutes(Msg).Minute);
        }
        private void Reboot(string Msg)
        {
            MessageBox.Show("重启啦");
            //OSManage.Reboot();
        }
        private void ShDnCmp(string Msg)
        {
            MessageBox.Show("关机啦");
            //OSManage.Shutdown();
        }
        delegate void AddListViewItemCallback(ListView lv, ListViewItem lvi);
        private void AddListViewItem(ListView lv, ListViewItem lvi)
        {
            if (lv.InvokeRequired)
            {
                AddListViewItemCallback d = new AddListViewItemCallback(AddListViewItem);
                this.Invoke(d, new object[] { lv, lvi });
                return;
            }

            lv.Items.Add(lvi);
        }
        private void returnMsg(IPEndPoint ipEnd)
        {
            if (FindListViewItem(this.lvi_Show, ipEnd.ToString()))
            {
               return;
            }
            ListViewItem lvi = new ListViewItem { Text = ipEnd.Address.ToString(), Tag = ipEnd, ImageIndex = 1 };
            AddListViewItem(lvi_Show, lvi);
            string[] eBytes = ipEnd.ToString().Split(':');
            IPAddress testAddress;
            IPAddress.TryParse(eBytes[0], out testAddress);
            IPEndPoint hehePoint = new IPEndPoint(testAddress, 12121);
            send("got", hehePoint);
            if (FindListViewItem(lvi_Show, ipEnd.Address.ToString()))
            {
                lvi_Show.FindItemWithText(ipEnd.Address.ToString()).Remove();
            }
            //ListViewItem lvi = new ListViewItem { Text = ipEnd.Address.ToString(), Tag = ipEnd, ImageIndex = 1 };
            //AddListViewItem(lvi_Show, lvi);
            //send("got", ipEnd);
        }

        private void btnShDown_Click(object sender, EventArgs e)
        {

            foreach (ListViewItem item in lvi_Show.Items)
            {
                byte[] bufferBytes = Encoding.Unicode.GetBytes("ShutDown:1");
                UdpClient client = new UdpClient();
                IPEndPoint ipEnd = (IPEndPoint)item.Tag;
                string[] eBytes = ipEnd.ToString().Split(':');
                IPAddress testAddress;
                IPAddress.TryParse(eBytes[0], out testAddress);
                IPEndPoint hehePoint = new IPEndPoint(testAddress, 12121);
                client.Send(bufferBytes, bufferBytes.Length, hehePoint);
            }
        }

        private void btnRebot_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvi_Show.Items)
            {
                byte[] bufferBytes = Encoding.Unicode.GetBytes("reboot:1");
                UdpClient client = new UdpClient();
                IPEndPoint ipEnd = (IPEndPoint)lvi_Show.FocusedItem.Tag;
                string [] eBytes=ipEnd.ToString().Split(':');
                IPAddress testAddress;
                IPAddress.TryParse(eBytes[0],out testAddress);
                IPEndPoint hehePoint=new IPEndPoint(testAddress,12121);
                client.Send(bufferBytes, bufferBytes.Length,hehePoint);
            }
        }

        private void btnShDownT_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvi_Show.Items)
            {
                byte[] bufferBytes = Encoding.Unicode.GetBytes("ShDnTime:" + "5");//延迟五分钟
                UdpClient client = new UdpClient();
                IPEndPoint ipEnd = (IPEndPoint)lvi_Show.FocusedItem.Tag;
                string[] eBytes = ipEnd.ToString().Split(':');
                IPAddress testAddress;
                IPAddress.TryParse(eBytes[0], out testAddress);
                IPEndPoint hehePoint = new IPEndPoint(testAddress, 12121);
                client.Send(bufferBytes, bufferBytes.Length, hehePoint);
            }
        }
    }
}
