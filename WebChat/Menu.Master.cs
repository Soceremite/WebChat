using Chat_DataAccess;
using System;

namespace WebChat
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["currentuser"] != null)
            {
                UserDB user = new UserDB(Session["currentuser"].ToString());
                lbusername.Text = user.UserName;
                lbusername2.Text = user.UserName;
                lbtype.Text = user.getIdentity();
                imguser.ImageUrl = user.ImgUrl;
                imguser2.ImageUrl = user.ImgUrl;
            }
            else
            {
                Response.Write(@"<script>alert('请先登录！');</script><script>window.location='/login.aspx'</script>");
            }
        }

        protected void tbcenter_Click(object sender, EventArgs e)
        {

        }

        protected void btsignout_Click(object sender, EventArgs e)
        {
            if (Session["currentuser"] != null)
            {
                UserDB.UpdateOnline(Session["CurrentUser"].ToString(), 0);
                Session["CurrentUser"] = null;
                Session["CurrentImg"] = null;
                Response.Redirect("/login.aspx");
            }
        }
    }
}