using Chat_DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebChat.Models;

namespace WebChat.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Chat主页
        /// </summary>
        /// <param name="nick">名称</param>
        /// <param name="pwd">密码</param>
        /// <param name="userid">用户id</param>
        /// <returns></returns>
        // GET: Chat
        public ActionResult Index(string userid)
        {
            UserViewModel model = new UserViewModel();
            UserDB user = new UserDB(userid);
            model.Nick = user.UserName;
            model.UserId = user.Id;
            model.Password = user.Password;
            model.ImgUrl = user.ImgUrl;
            model.LoginTime = user.LoginTime;
            return View(model);
            
        }
    }
}
