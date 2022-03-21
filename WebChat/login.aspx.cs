using Chat_DataAccess;
using System;
using System.Data.SqlClient;
using WebChat.Controllers;

namespace WebChat
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = tbusername.Text;
            string password = tbpassword.Text;
            string sql = "select * from [dbo].[User] where username='" + username + "' and passwd='" + password + "'" + " and status >=0";
            //数据库连接指令
            SqlDataReader reader = DB.Search(sql);
            if (reader.Read())
            {
                Response.Write(@"<script>alert('登录成功！');</script>");
                Session["CurrentUser"] = reader.GetInt32(0);
                UserDB.UpdateLoginTIme(reader.GetInt32(0).ToString());
                UserDB.UpdateOnline(reader.GetInt32(0).ToString(), 1);

                if (!reader.IsDBNull(6) && reader.GetString(6) != "")
                {

                    Session["CurrentImg"] = reader.GetString(6);
                }
                if(reader.GetInt32(5)==0)
                {
                    Response.Redirect("/Admin/index.aspx");
                }
                else if(reader.GetInt32(5) == 1)
                {
                    //Response.Redirect("/Home/index");
                    Response.Redirect("/User/Index?userid=" + Session["CurrentUser"]);
                }
                
            }
            else
            {
                Response.Write(@"<script>alert('登录失败！账号密码错误或不存在或待审核或已冻结！');</script>");

            }
        }
        protected void bt2_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("./signup.aspx");
        }
    }
}