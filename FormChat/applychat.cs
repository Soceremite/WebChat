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
    public partial class applychat : Form
    {
        string userid = null;
        public applychat(string id)
        {
            InitializeComponent();
            userid = id;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            List<UserInfo> applyuser = FriendDB.GetApplyToUser(userid);
            int count = applyuser.Count;
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.Name = "btnaccept";
            btn1.HeaderText = "同意";
            btn1.DefaultCellStyle.NullValue = "同意";
            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Name = "btnrefuse";
            btn2.HeaderText = "拒绝";
            btn2.DefaultCellStyle.NullValue = "拒绝";
            for (int i = 0; i < count; i++)
            {
                
                dataGridView2.Rows.Add(applyuser[i].Id, applyuser[i].UserName);
            }
            dataGridView2.Columns.Add(btn1);
            dataGridView2.Columns.Add(btn2);
        }

        private void btn_OnClick(object sender, MouseEventArgs e)
        {
           
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                List<UserInfo> searchuser = UserDB.SearchList(userid, textBox1.Text.Trim());
                int count = searchuser.Count;
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "btnapply";
                btn.HeaderText = "添加";
                btn.DefaultCellStyle.NullValue = "添加";
                
                for (int i=0;i<count;i++)
                {
                    dataGridView1.Rows.Add(searchuser[i].Id,searchuser[i].UserName);
                }
                dataGridView1.Columns.Add(btn);
            }
            else
            {
                MessageBox.Show("输入为空");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //点击button按钮事件
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnapply" && e.RowIndex >= 0)
            {
                //说明点击的列是DataGridViewButtonColumn列
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                string toid = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                littletip lt = new littletip();
                lt.ShowDialog();
                string name = lt.Text;
                FriendDB.AddFriend(userid, toid, name);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn column = dataGridView2.Columns[e.ColumnIndex];
            string toid = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            if (dataGridView2.Columns[e.ColumnIndex].Name == "btnaccept" && e.RowIndex >= 0)
            {
                
                littletip lt = new littletip();
                lt.ShowDialog();
                string name = lt.Text;
                FriendDB.AcceptApply(userid, toid, name);
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "btrefuse" && e.RowIndex >= 0)
            {
                FriendDB.RefuseApply(userid, toid);
                dataGridView2.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
