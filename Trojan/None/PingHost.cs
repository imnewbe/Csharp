using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace 基于Ping的主机扫描小工具
{
    public class PingEventArgs : EventArgs
    {
        public string ip;
        public PingReply reply;
        public PingEventArgs(string ip, PingReply reply)
        {
            this.ip = ip;
            this.reply = reply;
        }
    }
    public delegate void PingEventHandler(object sender, PingEventArgs e);

    class PingHost
    {
        
        public PingEventHandler PingFinished;
        protected virtual void OnPingFinished(PingEventArgs e)
        {
            if (PingFinished != null)
            {
                PingFinished(this, e);
            }
        }

        private string ip;

        public PingHost(string ip)
        {
            this.ip = ip;
        }

        public void Start()
        {
            Thread t = new Thread(PingWorker);
            t.IsBackground = true;
            t.Start();
        }

        private void PingWorker()
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            string data = "test";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            int timeout = 120;
            PingReply reply = pingSender.Send(ip, timeout, buffer, options);

            OnPingFinished(new PingEventArgs(ip, reply));
        }
    }
}
