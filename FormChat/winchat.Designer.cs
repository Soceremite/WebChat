
namespace FormChat
{
    partial class winchat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendmsg = new System.Windows.Forms.Button();
            this.chatBox1 = new LightTalkChatBox.ChatBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chatBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.sendmsg);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1111, 566);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(470, 25);
            this.textBox1.TabIndex = 0;
            // 
            // sendmsg
            // 
            this.sendmsg.Location = new System.Drawing.Point(637, 26);
            this.sendmsg.Name = "sendmsg";
            this.sendmsg.Size = new System.Drawing.Size(75, 23);
            this.sendmsg.TabIndex = 1;
            this.sendmsg.Text = "发送";
            this.sendmsg.UseVisualStyleBackColor = true;
            this.sendmsg.Click += new System.EventHandler(this.sendmsg_Click);
            // 
            // chatBox1
            // 
            this.chatBox1.BackColor = System.Drawing.Color.Transparent;
            this.chatBox1.Location = new System.Drawing.Point(-8, 0);
            this.chatBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatBox1.Name = "chatBox1";
            this.chatBox1.Size = new System.Drawing.Size(1055, 495);
            this.chatBox1.TabIndex = 0;
            this.chatBox1.Load += new System.EventHandler(this.winchat_Load);
            // 
            // winchat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 581);
            this.Controls.Add(this.splitContainer1);
            this.Name = "winchat";
            this.Text = "winchat";
            this.Load += new System.EventHandler(this.winchat_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private LightTalkChatBox.ChatBox chatBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button sendmsg;
    }
}