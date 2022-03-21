using Chat_Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DataAccess
{
     public class MessageDB
    {
        public static  void Insert(MessageInfo msg)
        {
            string sql = "Insert into [dbo].[Message] (fromid,toid,content,MsgTime) values('" + msg.FromId + "','" + msg.ToId + "','" + msg.Content + "','" + msg.MsgTime + "')";
            DB.Insert(sql);
        }
        public static DataTable GetDataTable(string TableName = "Message", string limit = null)
        {
            string sql = "select * from  " +
                "( " +
                    "select * from[dbo].[" + TableName + "] as A" +
                    " join" +
                    "(select id bid, username fromuser from[dbo].[User]) as B " +
                    "on A.fromid = B.bid" +
                ") as C " +
                "join" +
                "(select id cid, username touser from[dbo].[User]) as D " +
                "on C.toid = D.cid; ";
            if (limit != null)
                sql = sql + limit;
            return DB.getData(sql);
        }
        public static List<MessageInfo> GetList(string fromid,string toid, string tablename = "Message")
        {
            List<MessageInfo> msglist = new List<MessageInfo>();
            string sql = "select * from [dbo].[" + tablename + "] where fromid='" + fromid + "' and toid='" + toid + "'" +
                " union " +
                "select * from [dbo].[" + tablename + "] where fromid='" + toid + "' and toid='" + fromid + "'" +
                " order by MsgTime";
            DataTable dt1 = DB.getData(sql);
            int count = dt1.Rows.Count;
            for(int i=0;i<count;i++)
            {
                msglist.Add(new MessageInfo(dt1.Rows[i][1].ToString(), dt1.Rows[i][2].ToString(), dt1.Rows[i][3].ToString(), dt1.Rows[i][4].ToString()));
            }
            return msglist;
        }
        public static bool Delete(string id, string TableName = "Message")
        {
            string sql = "delete from [dbo].[" + TableName + "] where id=" + id;
            return DB.Delete(sql);
        }
    }
}
