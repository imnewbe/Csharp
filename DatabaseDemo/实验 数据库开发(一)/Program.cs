using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 实验_数据库开发_一_
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                connection.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Login login = new Login();
            DialogResult dr = login.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }

            Application.Run(new MainForm());
        }
    }
}
