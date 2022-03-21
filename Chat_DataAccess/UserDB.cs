using Chat_Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Chat_DataAccess
{
    public class UserDB:UserInfo
    {
        public UserDB(string idvalue)
        {
            string sql = "select * from [dbo].[User] where id='" + idvalue + "'";
            DataTable dt = DB.getData(sql);
            if (dt.Rows.Count > 0)
            {
                Id = idvalue;
                //ConnectionId = dt.Rows[0][1].ToString();
                UserName = dt.Rows[0][1].ToString();
                Password = dt.Rows[0][2].ToString();
                Phone = dt.Rows[0][4].ToString();
                Status = int.Parse(dt.Rows[0][5].ToString());
                ImgUrl = dt.Rows[0][6].ToString();
                LoginTime = dt.Rows[0][7].ToString();
            }
        }
        public UserDB(UserInfo value)
        {
            Id = value.Id;
            ConnectionId = value.ConnectionId;
            UserName = value.UserName;
            Password = value.Password;
            Phone = value.Phone;
            Status = value.Status;
            ImgUrl = value.ImgUrl;
            LoginTime = value.LoginTime;
        }
        public string getIdentity()
        {
            string identity;
            switch (Status)
            {
                case 0:
                    identity = "管理员";
                    break;
                case 1:
                    identity = "普通用户";
                    break;
                default:
                    identity = "新用户";
                    break;
            }
            return identity;
        }
        public static DataTable GetDataTable(string TableName = "User", string limit = null)
        {
            string sql = "select * from [dbo].[" + TableName + "] ";
            if (limit != null)
                sql = sql + limit;
            return DB.getData(sql);
        }
        public static List<UserInfo> SearchList(string id, string content,string TableName="User")
        {
            List<UserInfo> userlist = new List<UserInfo>();
            string limit =" where id!='"+id+"' and ( id like '%"+content+"%' or username like '%"+content+"%')"+
                " except "+
                "( select  id,username,passwd,isonline,phone,status,imgurl,logintime from " +
                "(select friendid,nickname from [dbo].[Friend] where masterid='" +id + "') as A " +
                "join" +
                "(select * from[dbo].[user]) as B " +
                "on A.friendid = B.Id)"; 
            DataTable dt = GetDataTable(TableName, limit);
            int count = dt.Rows.Count;
            for(int i=0;i<count;i++)
            {
                userlist.Add(new UserInfo(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), int.Parse(dt.Rows[i][3].ToString()), dt.Rows[i][4].ToString(), dt.Rows[i][6].ToString(), dt.Rows[i][7].ToString()));
            }
            return userlist;
        }
        public static bool UpdateOnline(string id, int value, string TableName = "User")
        {
            string sql = "update [dbo].[" + TableName + "]  set IsOnline = '" + value + "' where id = '" + id + "'";
            return DB.Update(sql);
        }
        public static bool UpdateStatus(string id, int status, string TableName = "User")
        {
            string sql = "update [dbo].[" + TableName + "]  set status = '" + status + "' where id = '" + id + "'";
            return DB.Update(sql);
        }
        public static bool UpdateLoginTIme(string id, string TableName = "User")
        {
            string sql = "update [dbo].[" + TableName + "]  set LoginTime = '" + DateTime.Now.ToString() + "' where id = '" + id + "'";
            return DB.Update(sql);
        }
    }
}
