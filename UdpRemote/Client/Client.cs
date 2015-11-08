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

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public Client(string name)
        {
            InitializeComponent();
            //数据库操作，改密码
            nn = name;
        }

        public string SendTOCP
        {
            get {return nn;}
        }
        private string nn;
        private void Client_Load(object sender, EventArgs e)
        {
            UDP.myUDP.sendList += FlashUserView;
            UDP.myUDP.RevMsg += RevMsgClient;
            string request = "list"+':'+nn;
            UDP.myUDP.Send(request);
         

        }
        /// <summary>
        /// 处理传过来的消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Msg"></param>
        private delegate void RevMsgCallback(object sender, UDP.dateRevEvents Msg);

        private void RevMsgClient(object sender, UDP.dateRevEvents msg)
        {
            if (InvokeRequired)
            {
                RevMsgCallback r = RevMsgClient;
                this.Invoke(r, new object[]{sender, msg});
                return;
                
            }
            string[] recvStrings = msg.MsgStrings.ToString().Split(':');
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(string.Format("{0} > {1}",
                recvStrings[1], recvStrings[2]));
            this.lvLog.Items.Add(lvi);
            lvi.ForeColor = Color.Blue;
        }
        /// <summary>
        /// 刷新用户界面，加载用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private delegate void FlashUserViewCallback(object sender,UDP.dateRevEvents e);
        private void FlashUserView(object sender ,UDP.dateRevEvents e)
        {
            if (InvokeRequired)
            {
                FlashUserViewCallback f = FlashUserView;
                this.Invoke(f, new object[] { sender , e});
                
            }

            string[] reStrings = e.MsgStrings;
            foreach (string user in reStrings)
            {
                //这里应当处理掉ack
                ListViewItem livItem=new ListViewItem();
                livItem.Text = user;
                livItem.ImageIndex = 0;//区分在线或者不在线
                lviUser.Items.Add(livItem);
            }
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add("登录成功！");
            this.lvLog.Items.Add(lvi);
            lvi.ForeColor = Color.Green;



        }
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPwd cl=new CPwd(nn);
            DialogResult dr = cl.ShowDialog();
            if (DialogResult.OK != dr)
            {
               // Application.Run(new CPwd(nn));
                return;
            }
           
            
            
        }

        private void btn_SendMsg_Click(object sender, EventArgs e)
        {
            UdpClient client =new UdpClient(0);
            string rq = string.Format("MESSAGE:{0}:{1}:{2}", this.nn, this.Rbx_Msg, lviUser.Tag/*对方ip*/);
            byte[] bytes = Encoding.Unicode.GetBytes(rq);
            client.Send(bytes, bytes.Length,
                new IPEndPoint(IPAddress.Parse(Properties.Settings.Default.ServerIP),
                    Properties.Settings.Default.ServerPort));


        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            UdpClient udpClient = new UdpClient(0);

            string request = "LOGOFF:" /*窗体传过来的用户名*/;
            byte[] buffer = Encoding.Unicode.GetBytes(request);

            udpClient.Send(buffer, buffer.Length,
                new IPEndPoint(
                    IPAddress.Parse(Properties.Settings.Default.ServerIP),
                    Properties.Settings.Default.ServerPort));
        }
    }
}
