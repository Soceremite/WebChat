using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_Model
{
    public class ChatRoom
    {
        /// <summary>
        /// 房间id
        /// </summary>
        public string RoomId { get; set; }
        /// <summary>
        /// 房间名称
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// 用户集合
        /// </summary>
        public List<UserGroup> Users { get; set; }

        public ChatRoom()
        {
            Users = new List<UserGroup>();
        }
    }
}
