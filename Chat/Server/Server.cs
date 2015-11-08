using System;
using System.Collections;
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

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }
        private Hashtable UserList;

        public struct ServiceObject
        {
            public DateTime LastRecv;       //上次接收数据时间
            public bool IsOnLine;           //终端是否在线
            public IPEndPoint ipEndPoint;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserList = Hashtable.Synchronized(new Hashtable());
            LoadStudent();


            Thread UdpThread = new Thread(StartUdpListener);
            UdpThread.IsBackground = true;
            UdpThread.Start();
        }
        private void StartUdpListener()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(
                IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(
                Properties.Settings.Default.Port);

            byte[] recvBuffer;
            RecvDataInfo recvData;
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
        public enum DataType : byte
        {
            Login = 0,        //登录
            LoginAck = 1,        //登录应答
            LogOff = 2,        //注销
            Register = 3,        //注册
            RegisterAck = 4,        //注册应答
            ChangePwd = 5,        //修改密码
            ChangePwdAck = 6,        //修改密码应答
            UserList = 7,        //获取用户列表
            UserListAck = 8,        //获取用户列表应答
            Message = 9,        //消息
            HeartBeat = 10,        //心跳
            UserStatusChg = 11,       //用户状态改变      
            GroupMsg    = 13,
        }
        private void ProcessUdpClient(Object recvObj)
        {
            RecvDataInfo recvData;

            try
            {
                recvData = (RecvDataInfo)recvObj;
                Server.DataType dataType = (DataType)recvData.Data[0];

                byte[] data = new byte[recvData.Data.Length - 1];
                Array.Copy(recvData.Data, 1, data, 0, data.Length);

                switch (dataType)
                {
                    case DataType.Login:
                        OnLogin(data, recvData.ipEndPoint);
                        break;

                    case DataType.LogOff:
                        OnLogoff(data, recvData.ipEndPoint);
                        break;

                    case DataType.Register:
                        OnRegister(data, recvData.ipEndPoint);
                        break;

                    //case DataType.ChangePwd:
                    //    OnChangePwd(data, recvData.ipEndPoint);
                    //    break;
                    case DataType.GroupMsg:
                        GroupMsg(data,recvData.ipEndPoint);
                        break;                  
                    case DataType.UserList:
                        OnUserList(recvData.ipEndPoint);
                        break;

                    case DataType.Message:
                        OnMessage(data, recvData.ipEndPoint);
                        break;

                    case DataType.HeartBeat:
                        OnHeartBeat(data, recvData.ipEndPoint);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            { }
        }
        private void LoadStudent()
        {
            string sql = "select * from UserS";
            SqlDataReader reader = SQLHelper.ExecuteReader(sql);
            while (reader.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = reader["LoginId"].ToString().Trim();
                lvi.ImageIndex = 0;
                this.lvUser.Items.Add(lvi);

                Server.ServiceObject sobj = new ServiceObject();
                sobj.IsOnLine = false;
                sobj.ipEndPoint = null;
                sobj.LastRecv = DateTime.MinValue;
                this.UserList.Add(lvi.Text, sobj);
            }
            reader.Close();
        }
        delegate void OnUserListCallback(IPEndPoint ipEndPoint);
        private void OnUserList(IPEndPoint ipEndPoint)
        {
            if (this.lvUser.InvokeRequired)
            {
                OnUserListCallback d = new OnUserListCallback(OnUserList);
                this.Invoke(d, new object[] { ipEndPoint });
                return;
            }

            string response = "";
            UdpClient client = new UdpClient(0);
            foreach (ListViewItem lvItem in this.lvUser.Items)
            {
                response += String.Format("{0}#{1}:", lvItem.Text, lvItem.ImageIndex);
            }

            Send(Server.DataType.UserListAck, response, ipEndPoint);
        }

        private void GroupMsg(byte[] dataBytes,IPEndPoint sendPoint)
        {
            int index = 0;
            int length = BitConverter.ToInt32(dataBytes, index);
            index += 4;
            string message = Encoding.Unicode.GetString(dataBytes, index, length);
            string sendUser = "";
            foreach (DictionaryEntry item in UserList)
            {
                Server.ServiceObject s = (ServiceObject)item.Value;
                if (sendPoint.Equals(s.ipEndPoint))
                {
                    sendUser = item.Key.ToString();
                    break;
                }
                
            }
            foreach (DictionaryEntry item in UserList)
            {
                Server.ServiceObject s = (ServiceObject)item.Value;
                if (sendPoint.Equals(s.ipEndPoint)||s.ipEndPoint.Equals(null))
                {
                    continue;
                }
                else
                {
                    Send(DataType.GroupMsg, message,s.ipEndPoint);
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = DateTime.Now.ToString();
                    lvi.SubItems.Add(String.Format("用户[{0}] 对 大家 说：{1}",
                        sendUser, message));
                    AddListViewItem(lvLog, lvi);
                }
            }
            //ListViewItem lvi = new ListViewItem();
            //lvi.Text = DateTime.Now.ToString();
            //lvi.SubItems.Add(String.Format("用户[{0}] 对 大家 说：{1}",
            //    sendUser, message));
            //AddListViewItem(lvLog, lvi);
            //先通知其他在线用户
        }
        private void OnMessage(byte[] data, IPEndPoint sendIPEndPoint)
        {
            int index = 0;
            int length = BitConverter.ToInt32(data, index);

            index += 4;
            string recvUser = Encoding.Unicode.GetString(data, index, length);

            index += length;
            length = BitConverter.ToInt32(data, index);

            index += 4;
            string message = Encoding.Unicode.GetString(data, index, length);

            string sendUser = "";
            foreach (DictionaryEntry de in UserList)
            {
                Server.ServiceObject s = (ServiceObject)de.Value;
                if (sendIPEndPoint.Equals(s.ipEndPoint))
                {
                    sendUser = de.Key.ToString();
                    break;
                }
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}] 对 [{1}] 说：{2}",
                sendUser, recvUser, message));
            AddListViewItem(lvLog, lvi);

            ServiceObject sobj = (ServiceObject)UserList[recvUser];
            if (!sobj.IsOnLine)//只有在线用户能够收到消息
                return;

            Send(DataType.Message, new string[] { sendUser, message }, sobj.ipEndPoint);
        }
        private void OnHeartBeat(byte[] data, IPEndPoint ipEndPoint)
        {
            string userName = Encoding.Unicode.GetString(data);
            if (!UserList.Contains(userName))
                return;

            Server.ServiceObject sobj = (ServiceObject)UserList[userName];
            sobj.LastRecv = DateTime.Now;
            sobj.ipEndPoint = ipEndPoint;
            if (!sobj.IsOnLine)
            {
                ModifyListViewItem(userName, ipEndPoint, true);
            }
            UserList[userName] = sobj;

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add("Heartbeat:" + userName);
        }

        private void OnLogoff(byte[] data, IPEndPoint ipEndPoint)
        {
            string userName = Encoding.Unicode.GetString(data);
            ModifyListViewItem(userName, null, false);

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]注销", userName));
            AddListViewItem(lvLog, lvi);
        }
        delegate void ModifyListViewItemCallback(string userName, object ipEndPoint, bool online);
        private void ModifyListViewItem(string userName, object ipEndPoint, bool online)
        {
            if (this.lvUser.InvokeRequired)
            {
                ModifyListViewItemCallback d = new ModifyListViewItemCallback(ModifyListViewItem);
                this.Invoke(d, new object[] { userName, ipEndPoint, online });
                return;
            }

            ListViewItem lvi = lvUser.FindItemWithText(userName);
            if (lvi == null)
                return;

            lvi.ImageIndex = online ? 1 : 0;

            //先通知其他在线用户
            UdpClient client = new UdpClient(0);
            string[] response = new string[] { lvi.Text, lvi.ImageIndex.ToString() };

            foreach (DictionaryEntry de in UserList)
            {
                Server.ServiceObject s = (ServiceObject)de.Value;
                if (s.IsOnLine)
                {
                    Send(DataType.UserStatusChg, response, s.ipEndPoint);
                }
            }

            ServiceObject sobj = (ServiceObject)UserList[userName];
            sobj.ipEndPoint = (IPEndPoint)ipEndPoint;
            sobj.IsOnLine = online;
            if (online)
            {
                sobj.LastRecv = DateTime.Now;
            }
            UserList[userName] = sobj;
        }
        public void Send(Server.DataType dataType, string msg, IPEndPoint endPoint)
        {
            if (msg == null)
                return;

            byte[] data = Encoding.Unicode.GetBytes(msg);
            byte[] buffer = new byte[1 + data.Length];
            buffer[0] = (byte)dataType;
            Array.Copy(data, 0, buffer, 1, data.Length);

            UdpClient udpClient = new UdpClient(0);
            udpClient.Send(buffer, buffer.Length, endPoint);
        }
        public void Send(DataType dataType, string[] msgList, IPEndPoint endPoint)
        {
            if (msgList == null)
                return;

            byte[] buffer = new byte[1];
            buffer[0] = (byte)dataType;
            foreach (string msg in msgList)
            {
                byte[] data = Encoding.Unicode.GetBytes(msg);
                byte[] tempBuffer = new byte[buffer.Length + 4 + data.Length];
                Array.Copy(buffer, 0, tempBuffer, 0, buffer.Length);
                Array.Copy(BitConverter.GetBytes(data.Length), 0, tempBuffer, buffer.Length, 4);
                Array.Copy(data, 0, tempBuffer, buffer.Length + 4, data.Length);

                buffer = tempBuffer;
            }

            UdpClient udpClient = new UdpClient(0);
            udpClient.Send(buffer, buffer.Length, endPoint);
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
        private void OnRegister(byte[] data, IPEndPoint ipEndPoint)
        {
            int index = 0;
            int length = BitConverter.ToInt32(data, index);

            index += 4;
            string userName = Encoding.Unicode.GetString(data, index, length);

            index += length;
            length = BitConverter.ToInt32(data, index);

            index += 4;
            string password = Encoding.Unicode.GetString(data, index, length);

            string sql = String.Format("select count(*) from UserS where LoginId='{0}'", userName);
            int count = (int)SQLHelper.ExcuteScalar(sql);
            if (count == 0)
            {
                sql = String.Format("insert into UserS (LoginId, LoginPwd) values ('{0}','{1}')",
                   userName, password);
                SQLHelper.ExcuteNonQuery(sql);
            }

            Send(DataType.RegisterAck, count.ToString(), ipEndPoint);


            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]注册：{1}",
                userName, count == 0 ? "成功" : "失败"));
            AddListViewItem(lvLog, lvi);

            if (count != 0)
                return;

            lvi = new ListViewItem();
            lvi.Text = userName;
            lvi.ImageIndex = 2;
            AddListViewItem(lvUser, lvi);
        }
        private void OnLogin(byte[] data, IPEndPoint ipEndPoint)
        {
            int index = 0;
            int length = BitConverter.ToInt32(data, index);

            index += 4;
            string userName = Encoding.Unicode.GetString(data, index, length);

            index += length;
            length = BitConverter.ToInt32(data, index);

            index += 4;
            string password = Encoding.Unicode.GetString(data, index, length);

            string sql = String.Format("select count(*) from UserS where LoginId='{0}' and LoginPwd='{1}'",
                userName, password);

            int count = (int)SQLHelper.ExcuteScalar(sql);
            if (count == 0)
                return;

            Send(DataType.LoginAck, count.ToString(), ipEndPoint);

            ModifyListViewItem(userName, ipEndPoint, true);

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]登录：{1}",
                userName, count == 1 ? "成功" : "失败"));
            AddListViewItem(lvLog, lvi);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ArrayList exceptionUsers = new ArrayList();
            foreach (DictionaryEntry de in UserList)
            {
                ServiceObject s = (ServiceObject)de.Value;
                if (s.IsOnLine &&
                    s.LastRecv.AddSeconds(6) < DateTime.Now)
                {
                    exceptionUsers.Add(de.Key);
                }
            }

            foreach (string userName in exceptionUsers)
            {
                ModifyListViewItem(userName, null, false);

                ListViewItem lvi = new ListViewItem();
                lvi.Text = DateTime.Now.ToString();
                lvi.SubItems.Add(userName + "异常下线");
                AddListViewItem(lvLog, lvi);
            }
        }

    }
}
