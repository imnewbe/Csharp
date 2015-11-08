﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
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
            Login lg =  new Login();
            if (lg.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Application.Run(new MainFrm(lg.GetUserName()));
        }
    }
}
