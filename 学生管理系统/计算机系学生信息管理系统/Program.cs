using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 计算机系学生信息管理系统
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]

        static void Main()
        {
             
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string connectionStr = "Server=.;Database=MySchool;Integrated Security=SSPI";
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
            
            loginFrm login = new loginFrm();
            DialogResult dr = login.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            if (login.getStatus())
            {

                Application.Run(new adminFrm(login.uid));
            }
            if(!login.getStatus()&&!login.getStudentsStatus()) 
            {
                Application.Run(new techFrm(login.uid));
            }
            if (login.getStudentsStatus())
            {
                Application.Run(new StudentFrm(login.uid));
            }
            
            
        }
    }
}
