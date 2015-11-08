using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.PeerToPeer;
using System.Net.Sockets;

namespace p2pSearcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tbxResourceName.Text == "")
            {
                MessageBox.Show("请输入发布的资源名！", "提示");
                return;
            }

        }
 

    }
}
