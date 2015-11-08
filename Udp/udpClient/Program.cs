using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace udpClient
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
            Login lo=new Login();
            DialogResult dr = lo.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            Application.Run(new client());
        }
    }
}
