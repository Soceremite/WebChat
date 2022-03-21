using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Models
{
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string ImgUrl { get; set; }
        public string LoginTime { get; set; }
    }
}