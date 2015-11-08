using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;

namespace IPSurveyScan
{


    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

         int  Start=0;
         int end=0;
         int ipCount = 0;//要扫描的数量

        public  delegate void ScanDelegate(object state);
        public void Scan(object state)
        {
            //应当在这里处理ip的增加问题
            if (lbx_ShowInfo.InvokeRequired)
            {
                ScanDelegate s = Scan;
                lbx_ShowInfo.Invoke(s, state);
                
            }
            else
            {
                this.lbx_ShowInfo.Items.Clear();
            }
            string ip = " ";
            Ping ping =new Ping();
            PingOptions options=new PingOptions();
            options.DontFragment = true;
            string data = "hehe";
            byte[] bufferBytes = Encoding.ASCII.GetBytes(data);
            int timeout = 20;
            if (end == Start)
            {
                return;
            }
            for (int i = 0; i < ipCount; i++)
            {
                ip = this.txt_StarIP.Text.Split('.')[0].ToString()+'.' + this.txt_StarIP.Text.Split('.')[1].ToString() +'.'+ this.txt_StarIP.Text.Split('.')[2].ToString()+'.'+(int.Parse(this.txt_StarIP.Text.Split('.')[3]) + i).ToString();

                PingReply reply = ping.Send(ip, timeout, bufferBytes, options);
                if (reply.Status == IPStatus.Success)
                {
                    lbx_ShowInfo.Items.Add("答复主机的地址" + reply.Address.ToString());
                    lbx_ShowInfo.Items.Add("往返时间" + reply.RoundtripTime);
                    lbx_ShowInfo.Items.Add("生存时间" + reply.Options.Ttl);
                    lbx_ShowInfo.Items.Add("是否控制数据包的分段：" + reply.Options.DontFragment);
                    lbx_ShowInfo.Items.Add("缓冲区大小" + reply.Buffer.Length);
                }
                else
                {
                    if (lbx_ShowInfo.InvokeRequired)
                    {
                        ScanDelegate deScanDelegate = Scan;
                        lbx_ShowInfo.Invoke(deScanDelegate, state);
                    }
                    else
                    {

                    
                    lbx_ShowInfo.Items.Add(reply.Status.ToString());
                }
            }
            }

        }

        //public void Run()
        //{
        //    while (true)
        //    {
        //        ThreadPool.QueueUserWorkItem(Scan);
        //        Thread.Sleep(1000);

        //    }
        //}
        private void btn_Star_Click(object sender, EventArgs e)
        {
            
                
            //判断ip是否合法
            string Rex = "^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";
            //如果下面的终止ip比上面的起始ip大也不会有提示。
            //并且ip要是像这样192.168.1.1-192.168.2.254这样计算岂不麻烦。
            if (System.Text.RegularExpressions.Regex.IsMatch(this.txt_StarIP.Text.ToString(), Rex) && System.Text.RegularExpressions.Regex.IsMatch(this.txt_endIP.Text.ToString(),Rex))
            {
                //进行下一步,这里假设ip只有最后一个段是不一致的。并且合法。但是感觉这程序好鸡肋。
                if (txt_endIP.Text.ToString() == this.txt_StarIP.Text.ToString())
                {
                    return;
                    
                }
                
                end=Int32.Parse(this.txt_endIP.Text.Split('.')[3]);
                Start=Int32.Parse(this.txt_StarIP.Text.Split('.')[3]);
                if (end == Start)
                {
                    return;
                }
                ipCount = end - Start+1;
                ThreadPool.SetMaxThreads(3,2);
               
                for (int i = 0; i < ipCount; i++)
                {
                    
                    //线程池
                    ThreadPool.QueueUserWorkItem(Scan);

                }



            }
            else
            {
                MessageBox.Show("输入错误!");
            }
        }
    }
}
