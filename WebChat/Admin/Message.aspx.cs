using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Controllers;
using Chat_DataAccess;
namespace WebChat.Admin
{
    public partial class Message : System.Web.UI.Page
    {
        protected void bind()
        {
            DataTable dt1 = MessageDB.GetDataTable();
            gv1.DataSource = dt1;
            gv1.DataKeyNames = new string[] { "id" };
            gv1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bind();
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string id = ((Label)gv1.Rows[row].FindControl("lbid")).Text;
            if (MessageDB.Delete(id))
                Response.Write(@"<script>alert('删除成功');</script><script>window.location ='/Admin/Message.aspx'</script>");
            else
            {
                Response.Write(@"<script>alert('删除失败');</script>");
                return;
            }
        }
    }
}