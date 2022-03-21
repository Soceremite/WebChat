﻿using Chat_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebChat.Controllers;

namespace WebChat.Admin
{
    public partial class UserUnfreeze : System.Web.UI.Page
    {
        protected void bind()
        {
            DataTable dt1 = UserDB.GetDataTable(limit: "where status='-2'");
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
        protected void UnBan_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
            string id = ((Label)gv1.Rows[row].FindControl("lbid")).Text;
            if (UserDB.UpdateStatus(id, 1))
                Response.Write(@"<script>alert('解封成功');</script><script>window.location ='/Admin/UserFreeze.aspx'</script>");
            else
            {
                Response.Write(@"<script>alert('解封失败');</script>");
                return;
            }
        }
    }
}