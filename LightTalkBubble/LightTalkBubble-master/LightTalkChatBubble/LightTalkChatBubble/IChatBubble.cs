using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightTalkChatBubble
{
    public interface IChatBubble
    {
        void setText(string msg, string sender,string senderID,string profileImgPath);
    }
}
