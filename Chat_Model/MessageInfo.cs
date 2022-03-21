using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Model
{
    public class MessageInfo
    {
        /// <summary>
        /// ID
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 连接ID
        /// </summary>
        public string FromId { get; set; }
        /// <summary>
        /// 发送方ID
        /// </summary>
        public string ToId { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        ///  /// <summary>
        /// 发送日期时间
        /// </summary>
        public string MsgTime { get; set; }
        public MessageInfo(string fromid,string toid,string message,string msgtime)
        {
            FromId = fromid;
            ToId = toid;
            Content = message;
            MsgTime = msgtime;
        }
    }
}
