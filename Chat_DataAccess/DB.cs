using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Chat_DataAccess
{
    public class DB
    {
        public DB()
        {
        }

        private static string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DataBase"].ToString();
        }
        //打开数据库连接
        public static OracleConnection Open()
        {
            try
            {
                OracleConnection cnt = new OracleConnection(getConnectionString());
                cnt.Open();
                return cnt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        //关闭数据库
        public static void Close(OracleConnection cnt)
        {
            if (cnt != null)
            {
                try
                {
                    cnt.Close();
                    cnt.Dispose();
                }
                catch (Exception ee)
                {
                    throw new Exception(ee.Message);
                }
            }
        }
        // 搜索数据库
        public static OracleDataReader Search(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                OracleDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
        }
        //检查数据
        public static bool IsExist(string tablename, string key,string keyvalue,string limit=null)
        {
            OracleConnection cnt = Open();
            string sql = "select * from [dbo].["+tablename+"] where "+key+"='" + keyvalue + " ' ";
            if(limit!=null)
            {
                sql = sql + limit;
            }
            OracleCommand cmd = new OracleCommand(sql, cnt);
            OracleDataReader reader = cmd.ExecuteReader();
            bool res = reader.Read();
            reader.Close();
            if (res)
                return true;
            else
                return false;
        }
        //插入数据
        public static bool Insert(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() == 0)
                    return false;
                else
                    return true;

            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                Close(cnt);
            }
        }
        //获得数据
        public static DataTable getData(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ee)
            {
                throw new Exception(ee.Message);
            }
            finally
            {
                Close(cnt);
            }
        }

        public static void SetDropDownList(DropDownList ddl, 
            string tablename, 
            string value, 
            string text, 
            int index = -1, 
            string indexText = null, 
            string prompt = null, 
            string limit = null)
        {
            if (ddl.Items.Count > 0)
                ddl.Items.Clear();
            string sql = "select * from [dbo].[" + tablename + "] ";
            if (limit != null)
            {
                sql = sql + limit;
            }
            DataTable itemlist = DB.getData(sql);
            int len = itemlist.Rows.Count;
            if (len > 0)
            {
                ddl.DataSource = itemlist;//绑定数据源
                ddl.DataValueField = itemlist.Columns[value].ToString();//绑定数据项Value
                ddl.DataTextField = itemlist.Columns[text].ToString();//绑定数据项Text
                ddl.DataBind();//绑定
            }
            ddl.Items.Add(new ListItem("--请选择"+prompt+"--", ""));//填充请【选择项】
            if (index == -1)
                ddl.SelectedIndex = ddl.Items.Count - 1;//选中【请选择】项
            else
                ddl.SelectedValue = index.ToString();
            for(int i=0;i<ddl.Items.Count;i++)
            {
                if(ddl.Items[i].Text.Equals(indexText))
                {
                    ddl.SelectedIndex = i;
                }
            }
        }

        //删除
        public static bool Delete(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }

        }
        //更新
        public static bool Update(string sql)
        {
            OracleConnection cnt = Open();
            try
            {
                OracleCommand cmd = new OracleCommand(sql, cnt);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                Close(cnt);
            }

        }
        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}