using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Office.Interop.Excel;

namespace 计算机系学生信息管理系统
{
    public partial class adminFrm : Form
    {
        public adminFrm()
        {
            InitializeComponent();
        }
        public adminFrm(string uid)
        {
            InitializeComponent();
            this.txtadminUser.Text = uid;

        }
        int index;
        DataSet dataSet;
        SqlDataAdapter adapter;
        private void btnSearch_Click(object sender, EventArgs e)//查询教师
        {
            string sql = string.Format("select * from Teacher where teachName like '%{0}%'", this.txtTeacher.Text);
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviTeacher.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["teachName"].ToString();
                lvi.SubItems.Add(read["LoginUsr"].ToString());
                lvi.SubItems.Add(read["Tlphone"].ToString());
                lvi.SubItems.Add(read["IDNumber"].ToString());
                lvi.SubItems.Add(read["LoginPwd"].ToString());
                this.lviTeacher.Items.Add(lvi);
            }
            read.Close();
        }

        private void btnAddTeach_Click(object sender, EventArgs e)//添加教师
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Teacher", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Tec");

            //if (dataSet.Tables[0].Rows.Count == 0)
            //{
            //    return;
            //}
            AddTeach add = new AddTeach();
            DialogResult dr = add.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
           
            DataRow row = dataSet.Tables[0].NewRow();
            row["teachName"] = add.TeacherName;
            row["LoginPwd"] = add.LoginPwd;
            row["Tlphone"] = add.TPhone;
            row["IDNumber"] = add.IDNumber;
            row["LoginUsr"] = add.teacherID;
            dataSet.Tables[0].Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);

            
        }

        private void btnModiTeach_Click(object sender, EventArgs e)//教师修改
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Teacher", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Tec");

            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }
            if (this.lviTeacher.FocusedItem == null)
            {
                return;
            }
            ListViewItem lvi = this.lviTeacher.FocusedItem;
            string old = lvi.SubItems[1].Text;
            AddTeach add = new AddTeach(
                lvi.Text,
                lvi.SubItems[1].Text,
                lvi.SubItems[2].Text,
                lvi.SubItems[3].Text,
                lvi.SubItems[4].Text
                );
            DialogResult dr = add.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            
            //index = ;
            index = this.lviTeacher.SelectedItems[0].Index;
            DataRow row = dataSet.Tables[0].Rows[index];
            row["teachName"] = add.TeacherName;
            row["LoginPwd"] = add.LoginPwd;
            row["Tlphone"] = add.TPhone;
            row["IDNumber"] = add.IDNumber;
            row["LoginUsr"] = add.teacherID;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
            lvi.Text = add.TeacherName;
            lvi.SubItems[1].Text = add.teacherID;
            lvi.SubItems[2].Text = add.TPhone;
            lvi.SubItems[3].Text = add.IDNumber;
            lvi.SubItems[4].Text = add.LoginPwd;

        }

        private void tbnDelTeach_Click(object sender, EventArgs e)//教师删除
        {
            if (this.lviTeacher.SelectedIndices.Count == 0)
            {
                return;
            }

            foreach (ListViewItem lvi in this.lviTeacher.SelectedItems)
            {
                string sql = String.Format("delete from Teacher where teachName='{0}'",
                    lvi.Text);
                SqlHelper.ExecuteSql(sql);
                lvi.Remove();
            }
        }

        

        private void btnSearchStu_Click_1(object sender, EventArgs e)//查询
        {
            string sql = string.Format("select * from Students where StuNo like '%{0}%'", this.txtStuSearch.Text);
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviStu.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["StuName"].ToString();
                lvi.SubItems.Add(read["Class"].ToString());
                lvi.SubItems.Add(read["StuNo"].ToString());
                lvi.SubItems.Add(read["Major"].ToString());
                lvi.SubItems.Add(read["ID"].ToString());
                lvi.SubItems.Add(read["Sex"].ToString());
                this.lviStu.Items.Add(lvi);
            }

            read.Close();
        }

        private void btnAddStu_Click(object sender, EventArgs e)//学生添加
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Students", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Stu");
            StuAdd add = new StuAdd();
            
            DialogResult dr = add.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            DataRow row = dataSet.Tables[0].NewRow();
            row["StuNo"] = add.StuNo;
            row["StuName"] = add.StuName;
            row["ID"] = add.StuID;
            row["Major"] = add.getMajor;
            row["Class"] = add.getClass ;
            if (add.getSex=="男")
            {
                row["Sex"] = "男";
            }
            else
            {
                row["Sex"] = "女";
            }
            dataSet.Tables[0].Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);

        }

        private void btnStuMod_Click(object sender, EventArgs e)//学生修改
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Students", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Stu");
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }
            if (this.lviStu.FocusedItem == null)
            {
                return;
            }
            ListViewItem lvi = this.lviStu.FocusedItem;
            string old = lvi.SubItems[1].Text;
            StuAdd add = new StuAdd(
                lvi.Text,
                lvi.SubItems[1].Text,
                lvi.SubItems[2].Text,
                lvi.SubItems[3].Text,
                lvi.SubItems[4].Text,
                lvi.SubItems[5].Text
                );
            DialogResult dr = add.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            index = this.lviStu.SelectedItems[0].Index;

            DataRow row = dataSet.Tables[0].Rows[index];
            row["StuNo"] = add.StuNo;
            row["StuName"] = add.StuName;
            row["ID"] = add.StuID;
            row["Major"] = add.getMajor;
            row["Class"] = add.getClass;
            if (add.getSex=="男")
            {
                row["Sex"] = "男";
            }
            else
            {
                row["Sex"] = "女";
            }
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
            lvi.Text = add.StuName;
            lvi.SubItems[1].Text = add.getClass;
            lvi.SubItems[2].Text = add.StuNo;
            lvi.SubItems[3].Text = add.getMajor;
            lvi.SubItems[4].Text = add.StuID;
            lvi.SubItems[5].Text = add.getSex;


            
        }

        private void btnStuDel_Click(object sender, EventArgs e)//学生删除
        {
            if (this.lviStu.SelectedIndices.Count == 0)
            {
                return;
            }

            foreach (ListViewItem lvi in this.lviStu.SelectedItems)
            {
                string sql = String.Format("delete from Students where StuName='{0}'",
                    lvi.Text);
                SqlHelper.ExecuteSql(sql);
                lvi.Remove();
            }
        }

        private void btnMajorSear_Click(object sender, EventArgs e)//按专业查询学生
        {
            string sql = string.Format("select * from Students where Major like '%{0}%'", this.txtMajor.Text);
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviMajor.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["StuName"].ToString();
                lvi.SubItems.Add(read["Class"].ToString());
                lvi.SubItems.Add(read["StuNo"].ToString());
                lvi.SubItems.Add(read["Major"].ToString());
                lvi.SubItems.Add(read["ID"].ToString());
                lvi.SubItems.Add(read["Sex"].ToString());
                this.lviMajor.Items.Add(lvi);
            }

            read.Close();
        }

        private void btnMajorAdd_Click(object sender, EventArgs e)//添加学生(专业）
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Students", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Stu");
            StuAdd add = new StuAdd();

            DialogResult dr = add.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            DataRow row = dataSet.Tables[0].NewRow();
            row["StuNo"] = add.StuNo;
            row["StuName"] = add.StuName;
            row["ID"] = add.StuID;
            row["Major"] = add.getMajor;
            row["Class"] = add.getClass;
            if (add.getSex == "男")
            {
                row["Sex"] = "男";
            }
            else
            {
                row["Sex"] = "女";
            }
            dataSet.Tables[0].Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
        }

        private void btnModifyMa_Click(object sender, EventArgs e)//修改学生（专业）
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Students", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Stu");
            //if (dataSet.Tables[0].Rows.Count == 0)
            //{
            //    return;
            //}
            if (this.lviMajor.FocusedItem == null)
            {
                return;
            }
            ListViewItem lvi = this.lviMajor.FocusedItem;
            string old = lvi.SubItems[1].Text;
            StuAdd add = new StuAdd(
                lvi.Text,
                lvi.SubItems[1].Text,
                lvi.SubItems[2].Text,
                lvi.SubItems[3].Text,
                lvi.SubItems[4].Text,
                lvi.SubItems[5].Text
                );
            DialogResult dr = add.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            index = this.lviMajor.SelectedItems[0].Index;

            DataRow row = dataSet.Tables[0].Rows[index];
            row["StuNo"] = add.StuNo;
            row["StuName"] = add.StuName;
            row["ID"] = add.StuID;
            row["Major"] = add.getMajor;
            row["Class"] = add.getClass;
            if (add.getSex == "男")
            {
                row["Sex"] = "男";
            }
            else
            {
                row["Sex"] = "女";
            }
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
            lvi.Text = add.StuName;
            lvi.SubItems[1].Text = add.getClass;
            lvi.SubItems[2].Text = add.StuNo;
            lvi.SubItems[3].Text = add.getMajor;
            lvi.SubItems[4].Text = add.StuID;
            lvi.SubItems[5].Text = add.getSex;
        }

        private void btnDelMajor_Click(object sender, EventArgs e)//删除
        {
            if (this.lviMajor.SelectedIndices.Count == 0)
            {
                return;
            }

            foreach (ListViewItem lvi in this.lviMajor.SelectedItems)
            {
                string sql = String.Format("delete from Students where StuName='{0}'",
                    lvi.Text);
                SqlHelper.ExecuteSql(sql);
                lvi.Remove();
            }
        }

        private void adminFrm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSreachGrd_Click(object sender, EventArgs e)//年级管理-查询
        {
            string sql = string.Format("select * from Grade where GradeNo like '%{0}%'", this.txtGrd.Text.Trim());
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviGrd.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["ClassName"].ToString();
                lvi.SubItems.Add(read["Monday"].ToString());
                lvi.SubItems.Add(read["Tuesday"].ToString());
                lvi.SubItems.Add(read["Wednesday"].ToString());
                lvi.SubItems.Add(read["Thursday"].ToString());
                lvi.SubItems.Add(read["Friday"].ToString());
                lvi.SubItems.Add(read["GradeNo"].ToString());
                this.lviGrd.Items.Add(lvi);
            }

            read.Close();
        }

        private void btnAddGrd_Click(object sender, EventArgs e)//年级管理-添加
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Grade", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Grd");
            GrdManager grd = new GrdManager();
            DialogResult dr = grd.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            DataRow row = dataSet.Tables[0].NewRow();
            row["ClassName"] = grd.getClassName;
            row["Monday"] = grd.getMon;
            row["Tuesday"] = grd.getTue;
            row["Wednesday"] = grd.getWed;
            row["Thursday"] = grd.getThur;
            row["Friday"] = grd.getFri;
            row["GradeNo"] = grd.getGrade;
            dataSet.Tables[0].Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);

        }

        private void btnModGrd_Click(object sender, EventArgs e)//年级管理-修改
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from Grade", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Grd");
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }
            if (this.lviGrd.FocusedItem == null)
            {
                return;
            }
            ListViewItem lvi = this.lviGrd.FocusedItem;
            string old = lvi.SubItems[1].Text;
            GrdManager grd = new GrdManager(
                lvi.Text,
                lvi.SubItems[1].Text,
                lvi.SubItems[2].Text,
                lvi.SubItems[3].Text,
                lvi.SubItems[4].Text,
                lvi.SubItems[5].Text,
                lvi.SubItems[6].Text
                );
            DialogResult dr = grd.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            index = this.lviGrd.SelectedItems[0].Index;
            DataRow row = dataSet.Tables[0].Rows[index];
            row["ClassName"] = grd.getClassName;
            row["Monday"] = grd.getMon;
            row["Tuesday"] = grd.getTue;
            row["Wednesday"] = grd.getWed;
            row["Thursday"] = grd.getThur;
            row["Friday"] = grd.getFri;
            row["GradeNo"] = grd.getGrade;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
        }

        private void btnDelGrd_Click(object sender, EventArgs e)//年级管理-删除
        {
            if (this.lviGrd.SelectedIndices.Count == 0)
            {
                return;
            }

            foreach (ListViewItem lvi in this.lviGrd.SelectedItems)
            {
                string sql = String.Format("delete from Grade where ClassName='{0}'",
                    lvi.Text);
                SqlHelper.ExecuteSql(sql);
                lvi.Remove();
            }
        }

        private void btnSeachClass_Click(object sender, EventArgs e)//班级管理-搜索
        {
            string sql = string.Format("select * from ClassManage where ClassNumber like '%{0}%'", this.txtClassMana.Text);
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviClassManage.Items.Clear();
            while (read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["ClassNumber"].ToString();
                lvi.SubItems.Add(read["MajorName"].ToString());
                lvi.SubItems.Add(read["PersonCount"].ToString());
                lvi.SubItems.Add(read["Grade"].ToString());
                lvi.SubItems.Add(read["Belong"].ToString());
                
                this.lviClassManage.Items.Add(lvi);
            }

            read.Close();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from ClassManage", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Cla");
            ClassAdd cla = new ClassAdd();
            DialogResult dr = cla.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            DataRow row = dataSet.Tables[0].NewRow();
            row["ClassNumber"] = cla.getClassNo; 
            row["MajorName"] = cla.getMajorName;
            row["PersonCount"] = cla.getPNumber;
            row["Grade"] = cla.getGradeClass;
            row["Belong"] = cla.getBelong ;
            dataSet.Tables[0].Rows.Add(row);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
        }

        private void btnModClass_Click(object sender, EventArgs e)
        {
            string connectionStr = "Server=.; Database=MySchool; Integrated Security=SSPI";
            SqlConnection connection = new SqlConnection(connectionStr);

            adapter = new SqlDataAdapter(
                "select * from ClassManage", connection);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Cla");
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return;
            }
            if (this.lviClassManage.FocusedItem == null)
            {
                return;
            }
            ListViewItem lvi = this.lviClassManage.FocusedItem;
            string old = lvi.SubItems[1].Text;
            ClassAdd cla = new ClassAdd(
                lvi.Text,
                lvi.SubItems[1].Text,
                lvi.SubItems[2].Text,
                lvi.SubItems[3].Text,
                lvi.SubItems[4].Text
                
                );
            DialogResult dr = cla.ShowDialog();
            if (DialogResult.OK != dr)
            {
                return;
            }
            index = this.lviClassManage.SelectedItems[0].Index;
            DataRow row = dataSet.Tables[0].Rows[index];
            row["ClassNumber"] = cla.getClassNo;
            row["MajorName"] = cla.getMajorName;
            row["PersonCount"] = cla.getPNumber;
            row["Grade"] = cla.getGradeClass;
            row["Belong"] = cla.getBelong;
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet.Tables[0]);
        }

        private void btnDelClass_Click(object sender, EventArgs e)
        {
            if (this.lviClassManage.SelectedIndices.Count == 0)
            {
                return;
            }

            foreach (ListViewItem lvi in this.lviClassManage.SelectedItems)
            {
                string sql = String.Format("delete from ClassManage where ClassNumber='{0}'",
                    lvi.Text);
                SqlHelper.ExecuteSql(sql);
                lvi.Remove();
            }
        }

        private void btnOkChanPwd_Click(object sender, EventArgs e)//密码修改
        {
           
            string sql = string.Format("select adminPsw from admin where adminUsr = '{0}'", this.txtadminUser.Text.Trim());
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            if (read.Read())
            {
                string oldPass = read.GetString(0).Trim();
                if (oldPass == this.txtOldPwd.Text.Trim())
                {
                    if (this.txtNewPwd.Text.Trim() == "" || this.txtSurePwd.Text.Trim() == "")
                    {
                        MessageBox.Show("新密码不能为空，确认新密码不能为空");
                        return;
                    }
                    else if (this.txtNewPwd.Text.Trim() != this.txtSurePwd.Text.Trim())
                    {
                        MessageBox.Show("两次密码不一致");
                        this.txtSurePwd.Text = "";
                        this.txtNewPwd.Text = "";
                        return;
                    }
                    else
                    {
                        
                      
                        string SQL = string.Format("update admin set adminPsw= '{0}' where adminUsr= '{1}'",  this.txtSureNewAdminPwd.Text,this.txtadminUser.Text.Trim());
                        SqlHelper.ExecuteSql(SQL);
                        MessageBox.Show("成功");
                    }
                }
                else
                {
                    MessageBox.Show("原密码错误");

                }
            }
            else
            {
                MessageBox.Show("用户名不存在");
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewAdminOk_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(this.txtNewAdminPwd.Text.ToString());
            string md5pwd = "";
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
            byte[] md5buffer = MD5.ComputeHash(buffer);
            foreach (byte item in md5buffer)
            {
                md5pwd += item.ToString("X2");
            }
            
            
            

            string SQLNewAdmin = string.Format("insert into admin (adminPsw, adminUsr) values ('{0}','{1}')", md5pwd, this.txtNewAdmin.Text.Trim());
            if (this.txtNewAdmin.Text.Trim() == "")
            {
                MessageBox.Show("用户名没输入");
                return;
            }
            else if (this.txtNewAdminPwd.Text.Trim() != this.txtSureNewAdminPwd.Text.Trim())
            {
                MessageBox.Show("两次密码不一致");
            }
            else
            {
                SqlHelper.ExecuteSql(SQLNewAdmin);
                MessageBox.Show("添加成功");
                this.txtNewAdmin.Text = "";
                this.txtNewAdminPwd.Text = "";
                this.txtSureNewAdminPwd.Text = "";

            }


        }

        private void btnEscNewAdmin_Click(object sender, EventArgs e)
        {
            this.txtNewAdmin.Text = "";
            this.txtNewAdminPwd.Text = "";
            this.txtSureNewAdminPwd.Text="";
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select * from admin");
            SqlDataReader read = SqlHelper.ExecuteReader(sql);
            this.lviAdminDel.Items.Clear();
            
           while(read.Read())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = read["adminUsr"].ToString();
                lvi.SubItems.Add(read["adminPsw"].ToString());
                this.lviAdminDel.Items.Add(lvi);}
            

            read.Close();
            
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
                if (this.lviAdminDel.SelectedIndices.Count == 0)
            {
                return;
            }

            foreach (ListViewItem lvi in this.lviAdminDel.SelectedItems)
            {
                string SQlDeleAdmin =string.Format("delete from admin where adminUsr='{0}'",
                    lvi.Text);
                SqlHelper.ExecuteSql(SQlDeleAdmin);
                lvi.Remove();
            }
        }
        public void ExportToExecl()
        {
            System.Windows.Forms.SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "xls";
            sfd.Filter = "Excel文件(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DoExport(this.lviTeacher, sfd.FileName);
            }
        }
        private void DoExport(ListView listView, string strFileName)
        {
            int rowNum = listView.Items.Count;
            int columnNum = listView.Items[0].SubItems.Count;
            int rowIndex = 1;
            int columnIndex = 0;
            if (rowNum == 0 || string.IsNullOrEmpty(strFileName))
            {
                return;
            }
            if (rowNum > 0)
            {

                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建excel对象，可能您的系统没有安装excel");
                    return;
                }
                xlApp.DefaultFilePath = "";
                xlApp.DisplayAlerts = true;
                xlApp.SheetsInNewWorkbook = 1;
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //将ListView的列名导入Excel表第一行
                foreach (ColumnHeader dc in listView.Columns)
                {
                    columnIndex++;
                    xlApp.Cells[rowIndex, columnIndex] = dc.Text;
                }
                //将ListView中的数据导入Excel中
                for (int i = 0; i < rowNum; i++)
                {
                    rowIndex++;
                    columnIndex = 0;
                    for (int j = 0; j < columnNum; j++)
                    {
                        columnIndex++;
                        //注意这个在导出的时候加了“\t” 的目的就是避免导出的数据显示为科学计数法。可以放在每行的首尾。
                        xlApp.Cells[rowIndex, columnIndex] = Convert.ToString(listView.Items[i].SubItems[j].Text) + "\t";
                    }
                }
                //例外需要说明的是用strFileName,Excel.XlFileFormat.xlExcel9795保存方式时 当你的Excel版本不是95、97 而是2003、2007 时导出的时候会报一个错误：异常来自 HRESULT:0x800A03EC。 解决办法就是换成strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal。
                xlBook.SaveAs(strFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                xlApp = null;
                xlBook = null;
                MessageBox.Show("OK");
            }
        }
        private void 导出信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExecl();
        }

    }
}
