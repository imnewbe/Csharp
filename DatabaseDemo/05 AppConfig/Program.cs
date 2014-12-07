using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace _05_AppConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            //连接字符串存储在配置文件中
            SqlConnection connection = new SqlConnection(
                Properties.Settings.Default.ConnectionStr);
            try
            {
                connection.Open();
                connection.Close();
                Console.WriteLine("连接数据库成功");
            }
            catch
            {
                Console.WriteLine("连接数据库失败");
            }
            Console.ReadKey();
        }
    }
}
