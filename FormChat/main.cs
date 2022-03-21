using Chat_DataAccess;
using Chat_Model;
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
    public partial class main : Form
    {
        public main(string id)
        {
            InitializeComponent();
            userid = id;
        }
        private string userid = null;
        /// 定义菜单Item默认和选中背景色
        /// </summary>
        private readonly Color menuColor = Color.FromArgb(250, 250, 205);
        private readonly Color menuBackColor = Color.FromArgb(90, 215, 209);
        private readonly Color menuMouserOverColor = Color.FromArgb(230, 206, 172);
        private Dictionary<string, Form> menuDic = new Dictionary<string, Form>();

        private void MenuList()
        {
            List<UserInfo> friendlist = FriendDB.GetFriendsToUser(userid);
            friendlist.Add(new UserInfo("0", "好友申请"));
            int count = friendlist.Count;
            for (int i = -1; i < count; i++)
            {
                Button btn = new Button();
                if(i==-1)
                {
                    btn.Text = "好友";
                    btn.BackColor = menuColor;
                }
                else if(i!=count-1)
                {
                    btn.Text = friendlist[i].UserName;
                    menuDic.Add(friendlist[i].UserName, new winchat(userid, friendlist[i].Id));
                    btn.FlatAppearance.MouseOverBackColor = menuMouserOverColor;
                }
                    
                else
                {
                    btn.Text = friendlist[i].UserName;
                    menuDic.Add(friendlist[i].UserName, new applychat(userid));
                    btn.FlatAppearance.MouseOverBackColor = menuMouserOverColor;
                    btn.BackColor = menuColor;
                }
                    
                //btn样式
                btn.FlatStyle = FlatStyle.Flat;
                
                btn.FlatAppearance.BorderSize = 0;
                //btn宽、高
                btn.Width = flowLayoutPanel1.Width;
                btn.Height = 40;
                //设置button间的margin为0
                Padding pd = new Padding();
                pd.All = 0;
                btn.Margin = pd;
                //引用鼠标点击事件
                btn.MouseClick += new MouseEventHandler(btn_OnClick);
                //填充到flowLayoutPanel
                flowLayoutPanel1.Controls.Add(btn);
                flowLayoutPanel1.BackColor = menuBackColor;
            }

        }

        private void btn_OnClick(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            Form menuForm = new Form();
            foreach (var fm in menuDic)
            {
                if (bt.Text.Equals(fm.Key))
                {
                    menuForm = fm.Value;
                }
            }
            //打开控件前，要清空Panel2 
            splitContainer1.Panel2.Controls.Clear();
            ShowPannel(menuForm);
        }
        /// <summary>
        /// 窗体显示
        /// </summary>
        /// <param name="fr"></param>
        void ShowPannel(Form fr)
        {
            fr.TopLevel = false;
            fr.FormBorderStyle = FormBorderStyle.None;
            fr.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(fr);
            fr.Show();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            MenuList();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
