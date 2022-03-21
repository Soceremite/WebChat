using Chat_DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormChat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("用户名和密码不能为空，请重新输入");
            }
            else
            {

                
                string sql = "select * from [dbo].[User] where username='" + username + "' and passwd='" + password + "'" + " and status >=0";
                //数据库连接指令
                SqlDataReader reader = DB.Search(sql);
                
                if (reader.Read())
                {
                    string id = reader.GetInt32(0).ToString();
                    main f = new main(id);
                    f.Show();
                    this.Visible = false;
                    UserDB.UpdateLoginTIme(reader.GetInt32(0).ToString());
                    UserDB.UpdateOnline(reader.GetInt32(0).ToString(), 1);
                }
                else
                {
                    MessageBox.Show("登录失败！账号密码错误或不存在或待审核或已冻结！");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //尚未更新
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //还没更新
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = new Char();//当勾选框的时候，为显示密码
            }
            else
            {
                textBox2.PasswordChar = '*';//当不勾选的时候，为密文状态
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
