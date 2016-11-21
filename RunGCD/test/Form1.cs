using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string i = this.textBox1.Text;
            Hashtable hs= new Hashtable();
            hs.Add("1","2");
            foreach (DictionaryEntry de in hs)
            {
                MessageBox.Show((string)de.Key);
            }
        }
    }
}
