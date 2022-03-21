using Chat_DataAccess;
using Chat_Model;
using LightTalkChatBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormChat
{
    public partial class winchat : Form
    {
        string fromid = null;
        string toid = null;
        public winchat(string fid,string tid)
        {
            InitializeComponent();
            fromid = fid;
            toid = tid;
        }

        private void winchat_Load(object sender, EventArgs e)
        {
            chatBox1_Load();


        }

        private void chatBox1_Load()
        {
            List<MessageInfo> msglist = MessageDB.GetList(fromid, toid);

            UserDB fromuser = new UserDB(fromid);
            UserDB touser = new UserDB(toid);

            for (int i=0;i<msglist.Count;i++)
            {
                if (msglist[i].FromId == fromid)
                    chatBox1.addChatBubble(ChatBox.BubbleSide.RIGHT, msglist[i].Content, " ",fromid, "D:/materials/现代软件开发技术/WebChat/FormChat/" + fromuser.ImgUrl);
                else
                    chatBox1.addChatBubble(ChatBox.BubbleSide.LEFT, msglist[i].Content, " ", toid, "D:/materials/现代软件开发技术/WebChat/FormChat/" + touser.ImgUrl);
            }

        }

        private void sendmsg_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                MessageInfo msg = new MessageInfo(fromid, toid, textBox1.Text.ToString().Trim(), DateTime.Now.ToString());
                MessageDB.Insert(msg);
                chatBox1.addChatBubble(ChatBox.BubbleSide.RIGHT, textBox1.Text.ToString().Trim(), "右", fromid, "/Resource/");
            }
            else
            {
                MessageBox.Show("输入为空");
            }
        }
    }
}
