using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class UDP
    {
        public static UDP myUDP = new UDP();

        public enum DataType : byte
        {
            Login           = 0,        //登录
            LoginAck        = 1,        //登录应答
            LogOff          = 2,        //注销
            Register        = 3,        //注册
            RegisterAck     = 4,        //注册应答
            ChangePwd       = 5,        //修改密码
            ChangePwdAck    = 6,        //修改密码应答
            UserList        = 7,        //获取用户列表
            UserListAck     = 8,        //获取用户列表应答
            Message         = 9,        //消息
            HeartBeat       = 10,        //心跳
            UserStatusChg   = 11,       //用户状态改变
            TimeServer      = 12,
            GroupMsg        = 13,//群发
        }

        Thread UdpThread;
        UdpClient udpClient;
        IPEndPoint serverEndPoint;

        private System.Timers.Timer HeartBeatDriver;

        public class UserEventArgs : EventArgs
        {
            public bool Result;
            public bool OnLine;
            public string UserName;
            public string Message;
            public string[] UserList;
            public UserEventArgs(bool result)
            {
                this.Result = result;
            }

            public UserEventArgs(string userName)
            {
                this.UserName = userName;
            }

            public UserEventArgs(string[] userList)
            {
                this.UserList = userList;
            }
            public UserEventArgs(string userName, string message)
            {
                this.UserName = userName;
                this.Message = message;
            }

            public UserEventArgs(string userName, bool onLine)
            {
                this.UserName = userName;
                this.OnLine = onLine;
            }
        }

        public delegate void UserEventHander(
            object sender, UserEventArgs e);
        public event UserEventHander LoginACK, RegisterAck,
            ChgPwdACK, UserListACK, UserMessage, UserStatusChg,GroupMsgText;
        protected virtual void OnLoginACK(UserEventArgs e)
        {
            if (LoginACK != null)
            {
                LoginACK(this, e);
            }
        }

        protected virtual void OnRegisterAck(UserEventArgs e)
        {
            if (RegisterAck != null)
            {
                RegisterAck(this, e);
            }
        }

        protected virtual void OnUserListACK(UserEventArgs e)
        {
            if (UserListACK != null)
            {
                UserListACK(this, e);
            }
        }

        protected virtual void OnUserMessage(UserEventArgs e)
        {
            if (UserMessage != null)
            {
                UserMessage(this, e);
            }
        }

        protected virtual void GroupMsg(UserEventArgs e)
        {
            if (GroupMsgText != null)
            {
                GroupMsgText(this, e);
            }
        }
        protected virtual void OnChgPwdACK(UserEventArgs e)
        {
            if (ChgPwdACK != null)
            {
                ChgPwdACK(this, e);
            }
        }

        protected virtual void OnUserStatusChg(UserEventArgs e)
        {
            if (UserStatusChg != null)
            {
                UserStatusChg(this, e);
            }
        }

        private void InitHeartBeat()
        {
            HeartBeatDriver = new System.Timers.Timer();
            HeartBeatDriver.AutoReset = true;
            HeartBeatDriver.Interval = 2000;           //默认心跳间隔为2s
            HeartBeatDriver.Elapsed += new System.Timers.ElapsedEventHandler(OnHeartBeatDriver);
        }

        private string UserName;
        public void StartHeartBeatDriver(string userName)
        {
            this.UserName = userName;
            this.HeartBeatDriver.Start();
        }

        public void StoptHeartBeatDriver()
        {
            this.HeartBeatDriver.Stop();
        }

        private void OnHeartBeatDriver(object sender, EventArgs e)
        {
            Send(DataType.HeartBeat, UserName);
        }

        public UDP()
        {
            serverEndPoint = new IPEndPoint(
                IPAddress.Parse(Properties.Settings.Default.ServerIP),
                Properties.Settings.Default.ServerPort);

            UdpThread = new Thread(StartUdpListener);
            UdpThread.IsBackground = true;
            UdpThread.Start();
        }

        private void StartUdpListener()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(
                IPAddress.Any, 0);
            udpClient = new UdpClient(0);
            InitHeartBeat();

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

        private void ProcessUdpClient(Object recvObj)
        {
            int index;
            int length;
            string msg;
            string userName;
            RecvDataInfo recvData;

            try
            {
                recvData = (RecvDataInfo)recvObj;
                DataType dataType = (DataType)recvData.Data[0];

                byte[] data = new byte[recvData.Data.Length - 1];
                Array.Copy(recvData.Data, 1, data, 0, data.Length);
                switch (dataType)
                {
                    case DataType.LoginAck:
                        OnLoginACK(new UserEventArgs(data[1] == 0));
                        break;

                    case DataType.RegisterAck:
                        OnRegisterAck(new UserEventArgs(data[1] == 0));
                        break;

                    //case DataType.ChangePwdAck:
                    //    OnChgPwdACK(new UserEventArgs(data[1] == 1));
                    //    break;

                    case DataType.UserListAck:
                        string requestMsg = Encoding.Unicode.GetString(data);
                        OnUserListACK(new UserEventArgs(requestMsg.Split(':')));
                        break;

                    case DataType.Message:
                        index = 0;
                        length = BitConverter.ToInt32(data, index);
                        index += 4;
                        userName = Encoding.Unicode.GetString(data, index, length);
                        index += length;
                        length = BitConverter.ToInt32(data, index);
                        index += 4;
                        msg = Encoding.Unicode.GetString(data, index, length);
                        OnUserMessage(new UserEventArgs(userName, msg));
                        break;
                     case DataType.GroupMsg:
                        msg = Encoding.Unicode.GetString(data);
                        GroupMsg(new UserEventArgs(msg));
                        break;

                    case DataType.UserStatusChg:
                        index = 0;
                        length = BitConverter.ToInt32(data, index);
                        index += 4;
                        userName = Encoding.Unicode.GetString(data, index, length);
                        index += length;
                        length = BitConverter.ToInt32(data, index);
                        index += 4;
                        msg = Encoding.Unicode.GetString(data, index, length);
                        OnUserStatusChg(new UserEventArgs(
                            userName, String.Equals(msg, "1")));
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            { }
        }

        public void Send(DataType dataType, string msg)
        {
            if (msg == null)
                return;

            Send(dataType, msg, serverEndPoint);
        }

        public void Send(DataType dataType, string msg, IPEndPoint endPoint)
        {
            if (msg == null)
                return;

            byte[] data = Encoding.Unicode.GetBytes(msg);
            byte[] buffer = new byte[1+data.Length];
            buffer[0] = (byte)dataType;
            Array.Copy(data, 0, buffer, 1, data.Length);

            udpClient.Send(buffer, buffer.Length, endPoint);
        }

        public void Send(DataType dataType, string[] msgList)
        {
            Send(dataType, msgList, serverEndPoint);
        }

        public void Send(DataType dataType, string[] msgList, IPEndPoint endPoint)
        {
            if (msgList == null)
                return;

            byte[] buffer = new byte[1];
            buffer[0] = (byte)dataType;
            foreach(string msg in msgList)
            {
                byte[] data = Encoding.Unicode.GetBytes(msg);
                byte[] tempBuffer = new byte[buffer.Length + 4 + data.Length];
                Array.Copy(buffer, 0, tempBuffer, 0, buffer.Length);
                Array.Copy(BitConverter.GetBytes(data.Length), 0, tempBuffer, buffer.Length, 4);
                Array.Copy(data, 0, tempBuffer, buffer.Length + 4, data.Length);

                buffer = tempBuffer;
            }

            udpClient.Send(buffer, buffer.Length, endPoint);
        }

        public static byte[] PackCommand(byte head, byte additionData)
        {
            return PackCommand(new byte[] { head }, new byte[] { additionData });
        }

        public static byte[] PackCommand(byte head, byte[] additionData)
        {
            return PackCommand(new byte[] { head }, additionData);
        }

        public static byte[] PackCommand(byte[] head, byte[] additionData)
        {
            byte[] buffer = new byte[head.Length + additionData.Length];

            Array.Copy(head, buffer, head.Length);
            Array.Copy(additionData, 0, buffer, head.Length, additionData.Length);

            return buffer;
        }

        public static byte[] UnPackCommand(byte[] commandData, int index, int length)
        {
            byte[] buffer = new byte[length];

            Array.Copy(commandData, index, buffer, 0, length);

            return buffer;
        }
    }
}
