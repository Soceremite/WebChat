using Chat_Model;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat_DataAccess;
using System.Threading.Tasks;
using Chat_Common;

namespace WebChat.ChatHub
{
   [HubName("chatHub")]
    public class One2OneHub : Hub
    {
        public static List<UserInfo> userlist = new List<UserInfo>();
        public static List<MessageInfo> msglist = new List<MessageInfo>();
        
        #region 发送消息

        /// <summary>
        //发送消息
        /// </summary>
        /// <param name="fromusername">发送者名称</param>
        /// <param name="userId">接收方用户id</param>
        /// <param name="message">消息</param>
        public void SendMsg(string fromid,string toId,string message)
        {
            var fromuser = userlist.FirstOrDefault(x => x.Id ==fromid);//发送方消息
            var touser = userlist.FirstOrDefault(x => x.Id == toId);//接收方消息
            Clients.Caller.showMsgToPages(fromuser.Id, fromuser.ImgUrl, message);
            if (fromuser.Id != toId)//判断是否是自己给自己发消息
            {
                if(touser!=null)
                    Clients.Client(touser.ConnectionId).remindMsg(fromuser.Id, fromuser.ImgUrl, message);
                AddMsgHistory(fromid, toId, message);
            }
        }

        /// <summary>
        /// 获取历史记录
        /// </summary>
        /// <param name="fromId">发送方id</param>
        /// <param name="toId">接收者id</param>
        public void GetMsgHistory(string fromId = "", string toId = "")
        {
            var list = MessageDB.GetList(fromId, toId);
            var data = JsonHelper.ToJsonString(list);

            UserDB fromuser = new UserDB(fromId);
            UserDB touser = new UserDB(toId);
            var user = userlist.FirstOrDefault(x => x.Id == fromId);
            var connectionid = Context.ConnectionId;
            if (user != null)
            {
                connectionid = user.ConnectionId;
            }
            Clients.Client(connectionid).initChatHistoryData(data,fromuser.ImgUrl,touser.ImgUrl);
        }
        /// <summary>
        /// 添加历史记录数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void AddMsgHistory(string fromId = "", string toId = "", string message = "")
        {
            MessageInfo msg = new MessageInfo(fromId, toId, message, DateTime.Now.ToString());
            MessageDB.Insert(msg);
        }

        #endregion

        #region 方法
        /// <summary>
        /// 获得在线用户列表
        /// </summary>
        public void GetAllOnlineUser()
        {
            var uList = JsonHelper.ToJsonString(userlist);
            Clients.All.ShowUserList(uList);
        }

        /// <summary>
        /// 获得好友列表
        /// </summary>
        public void GetFriends()
        {
            var user =userlist.FirstOrDefault(x=>x.ConnectionId==Context.ConnectionId);
            List<UserInfo> friendlist = FriendDB.GetFriendsToUser(user.Id);
            var list = friendlist.Select(s => new { s.Id, s.UserName, s.ImgUrl,s.IsOnline }).ToList();
            var jsonList = JsonHelper.ToJsonString(list);
            Clients.All.showFriendList(user.Id,jsonList);
        }
        /// <summary>
        /// 添加在线人员
        /// </summary>
        public void AddOnlineUser(string nickName, string password,string userId)
        {
            var user = userlist.FirstOrDefault(x => x.Id == userId);
            UserDB u = new UserDB(userId);
            if (user == null)
            {
                //添加在线人员
                userlist.Add(new UserInfo
                {
                    ConnectionId = Context.ConnectionId,
                    Id = userId,//随机用户id
                    UserName = nickName,
                    Password = password,
                    ImgUrl = u.ImgUrl,
                    LoginTime = u.LoginTime
                }) ;
                Clients.All.showJoinMessage(nickName,Context.ConnectionId);
            }
            else
            {
                user.ConnectionId = Context.ConnectionId;
            }
        }
        public void SearchUser(string id,string content)
        {
            List<UserInfo> searchuser = UserDB.SearchList(id, content);
            var data = searchuser.ToList();
            var jsonList = JsonHelper.ToJsonString(data);
            var user = userlist.FirstOrDefault(x => x.Id == id);
            Clients.Client(user.ConnectionId).showSearch(id,jsonList);
        }

        public void AddUser(string fromid,string toid,string name)
        {
            FriendDB.AddFriend(fromid, toid,name);
        }

        public void GetApply(string id)
        {
            List<UserInfo> applyuser = FriendDB.GetApplyToUser(id);
            var data = applyuser.ToList();
            var jsonList = JsonHelper.ToJsonString(data);
            var user = userlist.FirstOrDefault(x => x.Id == id);
            Clients.Client(user.ConnectionId).showApply(id, jsonList);

        }


        public void AcceptApply(string fromid, string toid,string name)
        {
            FriendDB.AcceptApply(fromid, toid,name);
        }

        public void RefuseApply(string fromid, string toid)
        {
            FriendDB.RefuseApply(fromid, toid);
        }

        public void SetFriendCenter(string fromid,string toid)
        {
            UserDB friend = new UserDB(toid);
            friend.NickName = FriendDB.GetFriend(fromid, toid).NickName;
            var user = userlist.FirstOrDefault(x => x.Id == fromid);
            var jsonList = JsonHelper.ToJsonString(friend);
            Clients.All.showFriendCenter(jsonList);
            //Clients.Client(user.ConnectionId).showFriendCenter(jsonList);
        }

        public void DeleteFriend(string fromid,string toid)
        {
            FriendDB.DeleteFriend(fromid, toid);
        }

        #endregion
    }
}