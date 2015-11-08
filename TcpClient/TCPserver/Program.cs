using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCPserver
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                int port = 12121;
                IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddress, port);
                server.Start();
                byte[] bytes = new byte[4096];
                string data = null;
                while (true)
                {
                    Console.Write("waiting");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("connected");
                    data = null;
                    NetworkStream stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("rev:{0}", data);
                        data = data.ToUpper();
                        byte[] msgBytes = System.Text.Encoding.ASCII.GetBytes(data);
                        stream.Write(msgBytes, 0, msgBytes.Length);
                        Console.WriteLine("send:{0}", data);

                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("excp{0}", e);

            }
            finally
            {
                server.Stop();
            }
        }
    }
}
