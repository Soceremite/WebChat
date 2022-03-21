using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Model
{
    public class Connection
    {
        /// <summary>
        /// 连接id
        /// </summary>
        public string ConnectionId { get; set; }

        /// <summary>
        /// 用户代理
        /// </summary>
        public string UserAgent { get; set; }
        /// <summary>
        /// 是否连接
        /// </summary>
        public bool Connected { get; set; }
    }
}
