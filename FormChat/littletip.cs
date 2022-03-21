using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormChat
{
    public partial class littletip : Form
    {
        public littletip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=null)
            {
                this.Text = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("输入为空");
            }
        }
    }
}
