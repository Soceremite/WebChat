using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 连接ID
        /// </summary>
        public string ConnectionId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password { get; set; }
        ///  /// <summary>
        /// 是否在线
        /// </summary>
        public int IsOnline { get; set; }
        ///  /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public string LoginTime { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public string NickName { get; set; }
        

        public UserInfo()
        {

        }
        public UserInfo(string id,string username)
        {
            Id = id;
            UserName = username;
        }
        public UserInfo(string id, string username,string password,int isonline,string phone,string imgurl,string logintime)
        {
            Id = id;
            UserName = username;
            Password = password;
            IsOnline = isonline;
            Phone = phone;
            ImgUrl = imgurl;
            LoginTime = logintime;
        }
    }
}
