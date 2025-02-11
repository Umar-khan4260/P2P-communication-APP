using System;
using System.Drawing;

namespace WindowsFormsApp1
{
    partial class GroupChat
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
            this.headerPanel = new System.Windows.Forms.Panel();
            this.labelGroupName = new System.Windows.Forms.Label();
            this.messagesPanel = new System.Windows.Forms.Panel();
            this.userName = new System.Windows.Forms.TextBox();
            this.history = new System.Windows.Forms.ListBox();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.cendmsg = new System.Windows.Forms.Button();
            this.messageInput = new System.Windows.Forms.TextBox();
            this.headerPanel.SuspendLayout();
            this.messagesPanel.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.LightGreen; // Medium green

            this.headerPanel.Controls.Add(this.labelGroupName);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(308, 43);
            this.headerPanel.TabIndex = 3;
            // 
            // labelGroupName
            // 
            this.labelGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelGroupName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelGroupName.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelGroupName.Location = new System.Drawing.Point(0, 0);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(308, 43);
            this.labelGroupName.TabIndex = 0;
            this.labelGroupName.Text = "Group Chat";
            this.labelGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // messagesPanel
            // 
            this.messagesPanel.AutoScroll = true;
            this.messagesPanel.BackColor = System.Drawing.Color.LightGreen;
            this.messagesPanel.Controls.Add(this.history);
            this.messagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagesPanel.Location = new System.Drawing.Point(0, 0);
            this.messagesPanel.Name = "messagesPanel";
            this.messagesPanel.Size = new System.Drawing.Size(308, 330);
            this.messagesPanel.TabIndex = 4;
            // 
            // userName
            // 
            this.userName.BackColor = System.Drawing.Color.LightGray;
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(0, 1);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(76, 35);
            this.userName.TabIndex = 4;
            this.userName.TextChanged += new System.EventHandler(this.userName_TextChanged);
            // 
            // history
            // 
            this.history.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(210)))), ((int)(((byte)(190)))));
            this.history.FormattingEnabled = true;
            this.history.Location = new System.Drawing.Point(0, 40);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(308, 290);
            this.history.TabIndex = 0;
            // 
            // inputPanel
            // 
            this.inputPanel.BackColor = System.Drawing.Color.LightGray;
            this.inputPanel.Controls.Add(this.userName);
            this.inputPanel.Controls.Add(this.cendmsg);
            this.inputPanel.Controls.Add(this.messageInput);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputPanel.Location = new System.Drawing.Point(0, 330);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(308, 37);
            this.inputPanel.TabIndex = 5;
            // 
            // cendmsg
            // 
            this.cendmsg.BackColor = System.Drawing.Color.LightGray;
            this.cendmsg.Location = new System.Drawing.Point(255, 0);
            this.cendmsg.Name = "cendmsg";
            this.cendmsg.Size = new System.Drawing.Size(53, 36);
            this.cendmsg.TabIndex = 0;
            this.cendmsg.Font = new Font("Arial", 10F, FontStyle.Bold);
            this.cendmsg.Text = "Send";
            this.cendmsg.UseVisualStyleBackColor = true;
            this.cendmsg.Click += new System.EventHandler(this.cendmsg_Click);
            this.cendmsg.BackColor = System.Drawing.Color.LightGreen;

            this.cendmsg.MouseEnter += new EventHandler(this.cendmsg_MouseEnter);
            this.cendmsg.MouseLeave += new EventHandler(this.cendmsg_MouseLeave);
            // 
            // messageInput
            // 
            this.messageInput.BackColor = System.Drawing.Color.LightGray;
            this.messageInput.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageInput.Location = new System.Drawing.Point(76, 1);
            this.messageInput.Name = "messageInput";
            this.messageInput.Size = new System.Drawing.Size(181, 35);
            this.messageInput.TabIndex = 0;
            // 
            // GroupChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 367);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.messagesPanel);
            this.Controls.Add(this.inputPanel);
            this.Name = "GroupChat";
            this.Text = "GroupChat";
            this.headerPanel.ResumeLayout(false);
            this.messagesPanel.ResumeLayout(false);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);

        }
        private void cendmsg_MouseEnter(object sender, EventArgs e)
        {
            this.cendmsg.BackColor = System.Drawing.Color.DarkGreen; // Change to dark green on hover
        }

        private void cendmsg_MouseLeave(object sender, EventArgs e)
        {
            this.cendmsg.BackColor = System.Drawing.Color.LightGreen; // Revert to light green after hover
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.Panel messagesPanel;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.TextBox messageInput;
        private System.Windows.Forms.Button cendmsg;
        private System.Windows.Forms.ListBox history;
        private System.Windows.Forms.TextBox userName;
    }
}