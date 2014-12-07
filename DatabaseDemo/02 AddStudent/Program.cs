using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoadGrade
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            string connectionStr = "Data Source='.'; Initial Catalog='MySchool'; Integrated Security='true'";
            try
            {
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();
                connection.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
