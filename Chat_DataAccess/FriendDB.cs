using Chat_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DataAccess
{
    public class FriendDB
    {
        public static FriendInfo GetFriend(string fromid,string toid)
        {
            FriendInfo friend = new FriendInfo();
            string sql = "select * from [dbo].[Friend] where  masterid='" + fromid + "' and  friendid='" + toid + "'";
            DataTable dt = DB.getData(sql);
            friend.MasterId = fromid;
            friend.FriendId = toid;
            if(dt.Rows.Count>0)
            {
                friend.Status = int.Parse(dt.Rows[0][3].ToString());
                friend.NickName = dt.Rows[0][5].ToString();
            }
            
            return friend;
        }
        public static List<FriendInfo> GetFriends(string id, string TableName = "Friend", string limit = null)
        {
            List<FriendInfo> userlist = new List<FriendInfo>();
            string sql = "select * from [dbo].[" + TableName + "] ";
            if (limit != null)
            {
                sql += "limit";
            }
            DataTable dt = DB.getData(sql);
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string friendid = dt.Rows[i][2].ToString();
                int status = int.Parse(dt.Rows[i][3].ToString());
                userlist.Add(new FriendInfo(friendid, status));
            }
            return userlist;
        }
        public static List<UserInfo> GetFriendsToUser(string masterid,string limit=null)
        {
            List<UserInfo> userlist = new List<UserInfo>();
            string sql = "select  * from " +
                "(select friendid,nickname from [dbo].[Friend] where masterid='"+masterid+"' and status=1 ) as A " +
                "join" +
                "(select * from[dbo].[user]) as B " +
                "on A.friendid = B.Id; ";
            if(limit!=null)
            {
                sql = sql + limit;
            }
            DataTable dt = DB.getData(sql);
            int count = dt.Rows.Count;
            for(int i=0;i<count;i++)
            {
                userlist.Add(new UserInfo(dt.Rows[i][2].ToString(), dt.Rows[i][1].ToString(), dt.Rows[i][4].ToString(), int.Parse(dt.Rows[i][5].ToString()),dt.Rows[i][6].ToString(), dt.Rows[i][8].ToString(),dt.Rows[i][9].ToString()));
            }
            return userlist;
        }
        public static bool AddFriend(string fromid,string toid,string name,string tablename="Friend")
        {
            if (!DB.IsExist("Friend", "masterid", fromid, " and friendid='" + toid + "'"))
            {
                string sql = "insert into [dbo].[" + tablename + "] (masterid,friendid,nickname) values ('" + fromid + "','" + toid + "','" + name + "')";
                return DB.Insert(sql);
            }
            return false;
        }
        public static List<UserInfo> GetApplyToUser(string id,string tablename="Friend",string limit=null)
        {
            List<UserInfo> userlist = new List<UserInfo>();
            string sql = "select  * from " +
                "(select masterid from [dbo].[Friend] where friendid='" + id + "' and status=0 ) as A " +
                "join" +
                "(select * from[dbo].[user]) as B " +
                "on A.masterid = B.Id; ";
            if (limit != null)
            {
                sql = sql + limit;
            }
            DataTable dt = DB.getData(sql);
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                userlist.Add(new UserInfo(dt.Rows[i][1].ToString(), dt.Rows[i][2].ToString(), dt.Rows[i][3].ToString(), int.Parse(dt.Rows[i][4].ToString()), dt.Rows[i][5].ToString(), dt.Rows[i][7].ToString(), dt.Rows[i][8].ToString()));
            }
            return userlist;
        }

        public static void AcceptApply(string fromid, string toid,string name)
        {
            string sql = "update [dbo].[Friend] set status=1 where masterid='" + toid + "' and friendid='" + fromid + "'";
            DB.Update(sql);
            sql= "Insert into [dbo].[Friend] (masterid,friendid,status,nickname) values ('" + fromid + "','" + toid + "',1,'" + name + "')";
            DB.Insert(sql);
        }

        public static void RefuseApply(string fromid, string toid)
        {
            string sql = "delete from [dbo].[Friend] where masterid='" + toid + "' and friendid='" + fromid + "'";
            DB.Delete(sql);
        }
         
        public static bool DeleteFriend(string fromid,string toid)
        {
            RefuseApply(fromid, toid);
            RefuseApply(toid, fromid);
            return true;
        }
    }
}
