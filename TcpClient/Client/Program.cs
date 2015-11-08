using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices.ComTypes;


namespace Client
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int Rport = 0;
            string RHost = null;
            Console.WriteLine("输入主机号和端口:");
            RHost=Console.ReadLine().ToString();
            Rport = Int32.Parse(Console.ReadLine());
            TcpClient tcp = new TcpClient();
            try
            {
                tcp.Connect(RHost, Rport);
                //成功连接之后发送数据
               Console.WriteLine("输入数据");
               string str = Console.ReadLine();
               NetworkStream netWorkStream = tcp.GetStream();
                if (netWorkStream.CanWrite)
                {
                        byte[] buffBytes = Encoding.ASCII.GetBytes(str);
                        netWorkStream.Write(buffBytes, 0, buffBytes.Length);  
                }
                else
                {
                    Console.WriteLine("you can't write");
                    tcp.Close();
                }
                if (netWorkStream.CanRead)
                {
                    byte[] bytes = new byte[tcp.ReceiveBufferSize];
                    netWorkStream.Read(bytes, 0, (int) tcp.ReceiveBufferSize);
                    string rev = Encoding.UTF8.GetString(bytes);
                    Console.WriteLine("rev:" + rev);
                }
                else
                {
                    Console.WriteLine("no data receive");
                    tcp.Close();
                    netWorkStream.Close();
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Some thing wrong");
                Console.ReadLine();
            }
            
        }
    }
}
