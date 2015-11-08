using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainFrm : Form
    {
        string userName;
        public MainFrm()
        {
            InitializeComponent();
        }
        public MainFrm(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            UDP.myUDP.UserListACK += myUDP_UserListACK;
            UDP.myUDP.UserStatusChg += myUDP_UserStatusChg;
            UDP.myUDP.UserMessage += myUDP_UserMessage;
            UDP.myUDP.GroupMsgText += myUdp_GroupMsg;
            UDP.myUDP.Send(UDP.DataType.UserList, "");
            UDP.myUDP.StartHeartBeatDriver(this.userName);   
        }

        private void myUdp_GroupMsg(object sender, UDP.UserEventArgs eventArgs)
        {
            ListViewItem lviItem=new ListViewItem();
            lviItem.Text = DateTime.Now.ToString();
            lviItem.SubItems.Add(string.Format("（正）匿名消息（版）：{0}", eventArgs.UserName));
            lviItem.ForeColor=Color.DarkRed;
            AddListViewItem(lvLog,lviItem);


        }
        private void myUDP_UserMessage(object sender, UDP.UserEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("用户[{0}]对你说 > {1}", e.UserName, e.Message));
            lvi.ForeColor = Color.Blue;
            AddListViewItem(lvLog, lvi);
        }
        private void myUDP_UserStatusChg(object sender, UDP.UserEventArgs e)
        {
            ModifyListViewItem(e.UserName, e.OnLine);
        }


        delegate void ModifyListViewItemCallback(string userName, bool online);
        private void ModifyListViewItem(string userName, bool online)
        {
            if (this.lvUser.InvokeRequired)
            {
                ModifyListViewItemCallback d = new ModifyListViewItemCallback(ModifyListViewItem);
                this.Invoke(d, new object[] { userName, online });
                return;
            }

            ListViewItem lvi = lvUser.FindItemWithText(userName);
            if (lvi == null)
                return;

            lvi.ImageIndex = online ? 1 : 0;

            lvi = new ListViewItem();
            lvi.Text = DateTime.Now.ToString();
            lvi.SubItems.Add(String.Format("[{0}] {1}", userName,
                online ? "上线" : "下线"));
            lvi.ForeColor = online ? Color.Green : Color.DarkRed;
            AddListViewItem(lvLog, lvi);
        }
        private void myUDP_UserListACK(object sender, UDP.UserEventArgs e)
        {
            foreach (string user in e.UserList)
            {
                string[] userInfo = user.Split('#');
                if (userInfo.Length != 2)
                {
                    continue;
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Text = userInfo[0];
                lvi.ImageIndex = int.Parse(userInfo[1]);

                AddListViewItem(lvUser, lvi);
            }
        }
        delegate void AddListViewItemCallback(ListView lv, ListViewItem lvi);
        private void AddListViewItem(ListView lv, ListViewItem lvi)
        {
            if (lv.InvokeRequired)
            {
                AddListViewItemCallback d = new AddListViewItemCallback(AddListViewItem);
                this.Invoke(d, new object[] { lv, lvi });
                return;
            }

            lv.Items.Add(lvi);
        }


        private void btnSend_Click(object sender, EventArgs e)
            
        {
           
           
            if (chbGroupSd.Checked)
            {
                UDP.myUDP.Send(UDP.DataType.GroupMsg,
                    new string[] { txtMessage.Text});

                ListViewItem lvi = new ListViewItem();
                lvi.Text = DateTime.Now.ToString();
                lvi.SubItems.Add(String.Format("'你对所有人说' > {0}",
                    this.txtMessage.Text));
                lvi.ForeColor = Color.BlueViolet;
                AddListViewItem(lvLog, lvi);
            }

            //UDP.myUDP.Send(String.Format("MESSAGE:{0}:{1}",
            //    lvUser.FocusedItem.Text, txtMessage.Text));
            else
            {
                if (this.lvUser.FocusedItem == null)
                    return;


                UDP.myUDP.Send(UDP.DataType.Message,
                    new string[] {lvUser.FocusedItem.Text, txtMessage.Text});

                ListViewItem lvi = new ListViewItem();
                lvi.Text = DateTime.Now.ToString();
                lvi.SubItems.Add(String.Format("[{0}] > {1}",
                    this.lvUser.FocusedItem.Text, this.txtMessage.Text));
                lvi.ForeColor = Color.BlueViolet;
                AddListViewItem(lvLog, lvi);
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UDP.myUDP.Send(UDP.DataType.LogOff, userName);
        }

        //private void chbGroupSd_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chbGroupSd.Checked)
        //    {
                
        //        //发个消息过去让服务器给在线的人全部发。
        //    }
        //            }
    }
}
