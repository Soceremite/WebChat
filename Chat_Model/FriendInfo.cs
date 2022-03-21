using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Model
{
    public class FriendInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// masterID
        /// </summary>
        public string MasterId { get; set; }
        /// <summary>
        /// 好友ID
        /// </summary>
        public string FriendId { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        ///  /// <summary>
        /// 分组
        /// </summary>
        public string GroupId { get; set; }

        public string NickName { get; set; }

        public FriendInfo()
        {
        }

        public FriendInfo(string friendid,int status)
        {
            FriendId = friendid;
            Status = status;
        }
    }
}
