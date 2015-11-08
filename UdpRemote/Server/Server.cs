using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Server.Properties;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private void Server_Load(object sender, EventArgs e)
        {
            //前面还有个加载所有人
            loadUser();
            Thread UdpThread = new Thread(StartUdpListener);
            UdpThread.IsBackground = true;
            UdpThread.Start();
        }

        private void loadUser()
        {
            string sql = "select * from UserS";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            while (reader.Read())
            {
                ListViewItem lviView =new ListViewItem();
                lviView.Text = reader["LoginId"].ToString().Trim();
                lviView.ImageIndex = 0;
                lvUser.Items.Add(lviView);
            }
            reader.Close();
        }
        private void StartUdpListener()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(
                IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(
                Settings.Default.Port);

            while (true)
            {
                var recvBuffer = udpClient.Receive(ref remoteEndPoint);

                var recvData = new RecvDataInfo {Data = recvBuffer, ipEndPoint = remoteEndPoint};
                ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessUdpClient),
                        recvData);
            }
        }
        private void ProcessUdpClient(Object recvObj)
        {
            try
            {
                var recvData = (RecvDataInfo)recvObj;
                string request = Encoding.Unicode.GetString(recvData.Data);

                string[] requestMsg = request.Split(':');
                switch (requestMsg[0])
                {
                    case "login":
                        OnLogin(requestMsg[1], requestMsg[2], recvData.ipEndPoint);
                        break;

                    case "LOGOFF":
                        OnLogoff(requestMsg[1], recvData.ipEndPoint);
                        break;

                    case "Reg":
                        OnRegister(requestMsg[1], requestMsg[2], recvData.ipEndPoint);
                        break;
                    case  "change":
                        CgPassWord(requestMsg[1], requestMsg[2], requestMsg[3], recvData.ipEndPoint);
                        break;
                    case "MESSAGE":
                        SendMsg(requestMsg[1],requestMsg[2],requestMsg[3],recvData.ipEndPoint);
                        break;
                    case "list":
                        sendUserList(requestMsg[1],recvData.ipEndPoint);
                        break;

                    default:
                      break;
                }
            }
            catch (Exception ex)
            { }
        }

        private delegate void userLogOff(string name,IPEndPoint endPoint);
        private void OnLogoff(string name,IPEndPoint endPoint)
        {
            if (InvokeRequired)
            {
                userLogOff u = OnLogoff;
                this.Invoke(u, name);
                return;

            }
             byte[] buffer;
            UdpClient client = new UdpClient(0);
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                if (lvItem.Text == name)
                {
                    lvItem.Remove();
                    continue;
                }

                buffer = Encoding.Unicode.GetBytes(
                    String.Format("USERSTASTUSCHG:{0}:{1}", name,'1'));
                client.Send(
                    buffer, buffer.Length, (IPEndPoint)lvItem.Tag);
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(string.Format("[{0}]   离开聊天室",
                name));
            this.lvLog.Items.Add(lvi);
            lvi.ForeColor = Color.Red;
        }

        /// <summary>
        /// 发送用户表
        /// </summary>
        /// <param name="name"></param>
        /// <param name="endPoint"></param>
        private delegate void sendUserListCallback(string name, IPEndPoint endPoint);
        private void sendUserList(string name, IPEndPoint endPoint)
        {
            if (this.InvokeRequired)
            {
                sendUserListCallback d = sendUserList;
                Invoke(d, name, endPoint);
                return;
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = name;
            lvi.Tag = endPoint;
            lvi.ImageIndex = 0;
            this.lvUser.Items.Add(lvi);
            byte[] bufferBytes;
            string response = "USERLISTACK";
            UdpClient client=new UdpClient(0);
            foreach (ListViewItem lviItem in lvUser.Items)
            {
                response += String.Format(":{0}", lviItem.Text);
                //if (lviItem.Text != name)//告诉所有人有人登录了，是否还要这个?
                //{
                //    bufferBytes = Encoding.Unicode.GetBytes(
                //        String.Format("LOGIN:{0}", name));
                //    client.Send(
                //        bufferBytes, bufferBytes.Length, (IPEndPoint)lviItem.Tag);
                //}
            }
            bufferBytes = Encoding.Unicode.GetBytes(response);
            client.Send(bufferBytes, bufferBytes.Length, endPoint);
            //lvi = new ListViewItem();
            //lvi.Text = DateTime.Now.ToString();
            //lvi.SubItems.Add(string.Format("[{0}]   登录聊天室",
            //    name));
            //this.lvLog.Items.Add(lvi);
            //lvi.ForeColor = Color.Green;

        }
        /// <summary>
        ///  改密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="OldPwd"></param>
        /// <param name="NewPwd"></param>
        /// <param name="ipEnd"></param>
        private void CgPassWord(string userName, string NewPwd, string OldPwd, IPEndPoint ipEnd)
        {
            string sql = string.Format("select LoginId,LoginPwd from UserS where LoginId='{0}' and LoginPwd='{1}'", userName,
                OldPwd);
            int count = (int) SQLHelper.ExcuteScalar(sql);
            if (count > 0)
            {
                sql = string.Format("insert into UserS LoginPwd values '{0}'", NewPwd);
                SQLHelper.ExcuteNonQuery(sql);
            }
            UdpClient client=new UdpClient(0);
            byte[] bufferBytes = Encoding.Unicode.GetBytes(String.Format("CHANGEPWDACK:{0}", count));
            client.Send(bufferBytes, bufferBytes.Length, ipEnd);
        }
        private void OnRegister(string userName, string password, IPEndPoint ipEndPoint)
        {
            string sql = String.Format("select count(*) from UserS where LoginId='{0}'", userName);
            int count = (int)SQLHelper.ExcuteScalar(sql);
            if (count == 0)
            {
                sql = String.Format("insert into UserS (LoginId, LoginPwd) values ('{0}','{1}')",
                   userName, password);
                SQLHelper.ExcuteNonQuery(sql);
            }

            UdpClient client = new UdpClient(0);
            byte[] buffer = Encoding.Unicode.GetBytes(
                        String.Format("REGISTERACK:{0}", count));
            client.Send(
                buffer, buffer.Length, ipEndPoint);

            if (count != 0)
                return;

            ListViewItem lvi = new ListViewItem {Text = userName, ImageIndex = 2};
            AddListViewItem(lvUser, lvi);

            lvi = new ListViewItem {Text = DateTime.Now.ToString()};
            lvi.SubItems.Add(String.Format("用户[{0}]注册：{1}",
                userName, count == 0 ? "成功" : "失败"));
            AddListViewItem(lvLog, lvi);
        }
        private void OnLogin(string userName, string password, IPEndPoint ipEndPoint)
        {
            string sql = String.Format("select count(*) from UserS where LoginId='{0}' and LoginPwd='{1}'",
                userName, password);

            int count = (int)SQLHelper.ExcuteScalar(sql);

            UdpClient client = new UdpClient(0);
            byte[] buffer = Encoding.Unicode.GetBytes(
                        String.Format("LOGINACK:{0}", count));
            client.Send(
                buffer, buffer.Length, ipEndPoint);

            if (count > 0)
            {
                ModifyListViewItem(userName, true);
            }

            ListViewItem lvi = new ListViewItem {Text = DateTime.Now.ToString()};
            lvi.SubItems.Add(String.Format("用户[{0}]登录：{1}",
                userName, count == 1 ? "成功" : "失败"));
            AddListViewItem(lvLog, lvi);
        }
        delegate void ModifyListViewItemCallback(string userName, bool online);
        private void ModifyListViewItem(string userName, bool online)
        {
            if (this.lvUser.InvokeRequired)
            {
                ModifyListViewItemCallback d = ModifyListViewItem;
                Invoke(d, userName, online);
                return;
            }

            ListViewItem lvi = lvUser.FindItemWithText(userName);
            if (lvi == null)
                return;

            lvi.ImageIndex = online ? 1 : 0;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="lvi"></param>
        private delegate void SendMsgCallback(string name, string RmoteIp, string Msg, IPEndPoint neEndPoint/*IP地址传过来*/);
        private void SendMsg(string name, string RmoteIp, string Msg, IPEndPoint endPoint)
        {
            if (InvokeRequired)
            {
                SendMsgCallback s =SendMsg;
                Invoke(s, name, RmoteIp, Msg, endPoint);
                return;
            }
            UdpClient client =new UdpClient(0);
            string request = String.Format("MESSAGE:{0}:{1}:{2}",
                name, Msg,RmoteIp/*要发送的人的ip*/);
            byte[] buffer = Encoding.Unicode.GetBytes(request);
                client.Send(buffer, buffer.Length,endPoint);
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(string.Format("[{0}] > {1}say{2}",
                name,endPoint/*此处换成名字更好*/, Msg));
            this.lvLog.Items.Add(lvi);
            lvi.ForeColor = Color.Blue;
        }
        delegate void AddListViewItemCallback(ListView lv, ListViewItem lvi);
        private void AddListViewItem(ListView lv, ListViewItem lvi)
        {
            if (lv.InvokeRequired)
            {
                AddListViewItemCallback d = AddListViewItem;
                Invoke(d, lv, lvi);
                return;
            }

            lv.Items.Add(lvi);
        }
    }
}
