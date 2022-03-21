using Chat_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebChat
{
    public partial class signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btSignup_Click(object sender, EventArgs e)
        {
            if (!tbpassword1.Text.ToString().Equals(tbpassword2.Text.ToString()))
            {
                Response.Write(@"<script>alert('两次密码不一致！');</script>");
                return;
            }
            string username = tbusername1.Text;
            string password = tbpassword1.Text;
            string phone = tbphone.Text;
            //定义sql检索语句
            string sql = "Insert into [dbo].[User] (username,passwd,phone,imgurl,logintime) values ( '" + username + "','" + password + "','" + phone + "','" + "/Resource/web/user.png','"+DateTime.Now.ToString()+"')";
            //数据库连接指令
            if (!DB.IsExist("User","username",username))
            {
                if (DB.Insert(sql))
                {
                    Response.Write(@"<script>alert('注册已提交！等待审核...');</script><script>window.location ='/signup.aspx'</script>");

                }
                else
                {
                    Response.Write(@"<script>alert('注册失败！');</script>");

                }
            }
            else
            {
                Response.Write(@"<script>alert('用户名已存在！');</script>");
            }
        }
        protected void bt1_Click(object sender, EventArgs e)
        {
            Response.Redirect("./login.aspx");
        }
    }
}