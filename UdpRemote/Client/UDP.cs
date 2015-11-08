using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    class UDP
    {
        public static UDP myUDP = new UDP();

        Thread UdpThread;
        UdpClient udpClient;
        IPEndPoint serverEndPoint;

        public class UserEventArgs : EventArgs
        {
            public bool Result;
            public UserEventArgs(bool result)
            {
                this.Result = result;
            }

        }
       /// <summary>
       /// 用来传递表单和消息
       /// </summary>
        public class dateRevEvents:EventArgs
        {
            public string[] MsgStrings;

            public dateRevEvents(string[] msg )
            {
                MsgStrings = msg;
            }
        }

        
        public delegate void UserEventHander(
            object sender, UserEventArgs e);
        public event UserEventHander LoginACK, RegisterAck,CgPwd,logoff;

        public delegate void dateEventsHandle(object sender, dateRevEvents dateRev);

        public event dateEventsHandle sendList,RevMsg;
        /// <summary>
        /// 发送用户表
        /// </summary>
        /// <param name="erEvents"></param>
        protected virtual void OnsendList(dateRevEvents erEvents)
        {
            if (sendList!=null)
            {
                sendList(this,erEvents);
            }
            
        }

        protected virtual void LoginOff(UserEventArgs e)
        {
            if (logoff!=null)
            {
                logoff(this, e);
            }
        }
        /// <summary>
        /// 消息
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnRevMsg(dateRevEvents e)
        {
            if (RevMsg!=null)
            {
                RevMsg(this, e);
            }
        }
        protected virtual void OnLoginACK(UserEventArgs e)
        {
            if (LoginACK !=null)
            {
                LoginACK(this, e);
            }
        }

        protected virtual void CPassWd(UserEventArgs e)
        {
            if (CgPwd!=null)
            {
                CgPwd(this, e);
            }
        }

        protected virtual void OnRegisterAck(UserEventArgs e)
        {
            if (RegisterAck != null)
            {
                RegisterAck(this, e);
            }
        }

        public UDP()
        {
            serverEndPoint = new IPEndPoint(
                IPAddress.Parse(Properties.Settings.Default.ServerIP),
                Properties.Settings.Default.ServerPort);

            Thread UdpThread = new Thread(StartUdpListener);
            UdpThread.IsBackground = true;
            UdpThread.Start();
        }

        private void StartUdpListener()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(
                IPAddress.Any, 0);
            udpClient = new UdpClient(0);

            byte[] recvBuffer;
            RecvDataInfo recvData;
            while (true)
            {
                recvBuffer = udpClient.Receive(ref remoteEndPoint);

                recvData = new RecvDataInfo();
                recvData.Data = recvBuffer;
                recvData.ipEndPoint = remoteEndPoint;
                ThreadPool.QueueUserWorkItem(ProcessUdpClient,
                        recvData);
            }
        }

        private void ProcessUdpClient(Object recvObj)
        {
            RecvDataInfo recvData;

            try
            {
                recvData = (RecvDataInfo)recvObj;
                string request = Encoding.Unicode.GetString(recvData.Data);

                string[] requestMsg = request.Split(':');
                switch (requestMsg[0])
                {
                    case "LOGINACK"://登录结果
                        OnLoginACK(new UserEventArgs(String.Equals(requestMsg[1], "1")));
                        break;

                    case "REGISTERACK"://注册结果
                        OnRegisterAck(new UserEventArgs(String.Equals(requestMsg[1], "0")));
                        break;

                    case "CHANGEPWDACK"://修改密码结果
                        CPassWd(new UserEventArgs(String.Equals(requestMsg[1],"0")));
                        break;

                    case "USERLISTACK"://服务器发来的用户列表
                        OnsendList(new dateRevEvents(requestMsg));
                        break;

                    case "MESSAGE"://其他用户通过服务器发来的聊天消息
                        OnRevMsg(new dateRevEvents(requestMsg));
                        break;

                    case "USERSTASTUSCHG"://其他用户在线状态发生改变
                        LoginOff(new UserEventArgs(string.Equals(requestMsg[1],"1")));//1 表示离线
                        break;

                    default:
                        break;
                }
            }
            catch
            { }
        }

        

        public bool InvokeRequired { get; set; }

        public void Send(string msg)
        {
            Send(msg, serverEndPoint);
        }

        public void Send(string msg, IPEndPoint endPoint)
        {
            if (String.IsNullOrEmpty(msg))
            {
                return;
            }

            byte[] buffer = Encoding.Unicode.GetBytes(msg);
            Send(buffer, buffer.Length, endPoint);
        }

        public void Send(byte[] buffer, int length, IPEndPoint endPoint)
        {
            udpClient.Send(buffer, length, endPoint);
        }
    }
}
