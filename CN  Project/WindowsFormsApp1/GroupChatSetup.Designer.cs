////using System;
////using System.Collections.Generic;
////using System.Drawing;
////using System.Linq;
////using System.Net;
////using System.Net.Sockets;
////using System.Text;
////using System.Threading;
////using System.Windows.Forms;


////namespace WindowsFormsApp1
////{
////    partial class GroupChatSetup
////    {
////        private TcpClient peerConnection;
////        /// <summary>
////        /// Required designer variable.
////        /// </summary>
////        private System.ComponentModel.IContainer components = null;

////        /// <summary>
////        /// Clean up any resources being used.
////        /// </summary>
////        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
////        protected override void Dispose(bool disposing)
////        {
////            if (disposing && (components != null))
////            {
////                components.Dispose();
////            }
////            base.Dispose(disposing);
////        }

////        #region Windows Form Designer generated code

////        /// <summary>
////        /// Required method for Designer support - do not modify
////        /// the contents of this method with the code editor.
////        /// </summary>
////        private void InitializeComponent()
////        {
////            this.labelGroupName = new System.Windows.Forms.Label();
////            this.listBoxPeers = new System.Windows.Forms.ListBox();
////            this.textBoxGroupName = new System.Windows.Forms.TextBox();
////            this.buttonCreateGroup = new System.Windows.Forms.Button();
////            this.labelPeers = new System.Windows.Forms.Label();
////            this.SuspendLayout();
////            // 
////            // labelGroupName
////            // 
////            this.labelGroupName.AutoSize = true;
////            this.labelGroupName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
////            this.labelGroupName.Location = new System.Drawing.Point(20, 20);
////            this.labelGroupName.Name = "labelGroupName";
////            this.labelGroupName.Size = new System.Drawing.Size(188, 22);
////            this.labelGroupName.TabIndex = 0;
////            this.labelGroupName.Text = "Enter Group Name:";
////            // 
////            // listBoxPeers
////            // 
////            this.listBoxPeers.FormattingEnabled = true;
////            this.listBoxPeers.Location = new System.Drawing.Point(20, 130);
////            this.listBoxPeers.Name = "listBoxPeers";
////            this.listBoxPeers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
////            this.listBoxPeers.Size = new System.Drawing.Size(250, 173);
////            this.listBoxPeers.TabIndex = 3;
////            this.listBoxPeers.SelectedIndexChanged += new System.EventHandler(this.listBoxPeers_SelectedIndexChanged);
////            // 
////            // textBoxGroupName
////            // 
////            this.textBoxGroupName.Location = new System.Drawing.Point(20, 60);
////            this.textBoxGroupName.Name = "textBoxGroupName";
////            this.textBoxGroupName.Size = new System.Drawing.Size(250, 20);
////            this.textBoxGroupName.TabIndex = 1;
////            // 
////            // buttonCreateGroup
////            // 
////            this.buttonCreateGroup.Location = new System.Drawing.Point(20, 320);
////            this.buttonCreateGroup.Name = "buttonCreateGroup";
////            this.buttonCreateGroup.Size = new System.Drawing.Size(150, 30);
////            this.buttonCreateGroup.TabIndex = 4;
////            this.buttonCreateGroup.Text = "Create Group";
////            this.buttonCreateGroup.UseVisualStyleBackColor = true;
////            this.buttonCreateGroup.Click += new System.EventHandler(this.buttonCreateGroup_Click);
////            // 
////            // labelPeers
////            // 
////            this.labelPeers.AutoSize = true;
////            this.labelPeers.Font = new System.Drawing.Font("Arial", 12F);
////            this.labelPeers.Location = new System.Drawing.Point(20, 100);
////            this.labelPeers.Name = "labelPeers";
////            this.labelPeers.Size = new System.Drawing.Size(102, 18);
////            this.labelPeers.TabIndex = 2;
////            this.labelPeers.Text = "Select Peers:";
////            // 
////            // GroupChatSetup
////            // 
////            this.ClientSize = new System.Drawing.Size(300, 380);
////            this.Controls.Add(this.buttonCreateGroup);
////            this.Controls.Add(this.listBoxPeers);
////            this.Controls.Add(this.labelPeers);
////            this.Controls.Add(this.textBoxGroupName);
////            this.Controls.Add(this.labelGroupName);
////            this.Name = "GroupChatSetup";
////            this.Text = "Group Chat Setup";
////            this.Load += new System.EventHandler(this.GroupChatSetup_Load);
////            this.ResumeLayout(false);
////            this.PerformLayout();

////        }


////        private void buttonCreateGroup_Click(object sender, EventArgs e)
////        {
////            // Get the selected peers from the ListBox
////            var selectedPeers = listBoxPeers.SelectedItems.Cast<string>().ToList();

////            if (selectedPeers.Count == 0)
////            {
////                MessageBox.Show("Please select at least one peer to create a group.");
////                return;
////            }

////            // Get the group name from the text box
////            string groupName = textBoxGroupName.Text.Trim();

////            if (string.IsNullOrEmpty(groupName))
////            {
////                MessageBox.Show("Please enter a group name.");
////                return;
////            }

////            // Send invites to the selected peers
////            //SendGroupInvite(groupName, selectedPeers);

////            // Show confirmation
////            MessageBox.Show($"Group '{groupName}' created with peers: {string.Join(", ", selectedPeers)}");

////            // Optionally, open the group chat window after sending invites
////            GroupChat newGroupChat = new GroupChat(selectedPeers, groupName);
////            newGroupChat.Show();
////        }


////        #endregion

////        private System.Windows.Forms.Label labelGroupName;
////        private System.Windows.Forms.TextBox textBoxGroupName;
////        private System.Windows.Forms.ListBox listBoxPeers;
////        private System.Windows.Forms.Button buttonCreateGroup;
////        private System.Windows.Forms.Label labelPeers;
////    }
////}

//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;
//using System.Threading;
//using System.Windows.Forms;

//namespace WindowsFormsApp1
//{
//    partial class GroupChatSetup : Form
//    {
//        private TcpClient peerConnection;
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        private void InitializeComponent()
//        {
//            this.labelGroupName = new System.Windows.Forms.Label();
//            this.listBoxPeers = new System.Windows.Forms.ListBox();
//            this.textBoxGroupName = new System.Windows.Forms.TextBox();
//            this.buttonCreateGroup = new System.Windows.Forms.Button();
//            this.labelPeers = new System.Windows.Forms.Label();
//            this.SuspendLayout();

//            // Group Chat Setup Form
//            this.ClientSize = new System.Drawing.Size(300, 380);
//            this.Name = "GroupChatSetup";
//            this.Text = "Group Chat Setup";
//            this.BackColor = Color.FromArgb(210, 255, 210); // Light Green Background

//            // labelGroupName
//            this.labelGroupName.AutoSize = true;
//            this.labelGroupName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
//            this.labelGroupName.Location = new System.Drawing.Point(20, 20);
//            this.labelGroupName.Name = "labelGroupName";
//            this.labelGroupName.Size = new System.Drawing.Size(188, 22);
//            this.labelGroupName.TabIndex = 0;
//            this.labelGroupName.Text = "Enter Group Name:";
//            this.labelGroupName.ForeColor = Color.Black; // Font color black for visibility

//            // listBoxPeers
//            this.listBoxPeers.FormattingEnabled = true;
//            this.listBoxPeers.Location = new System.Drawing.Point(20, 130);
//            this.listBoxPeers.Name = "listBoxPeers";
//            this.listBoxPeers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
//            this.listBoxPeers.Size = new System.Drawing.Size(250, 173);
//            this.listBoxPeers.TabIndex = 3;
//            this.listBoxPeers.Font = new Font("Arial", 10); // Enhanced font
//            this.listBoxPeers.ForeColor = Color.Black;
//            this.listBoxPeers.BackColor = Color.FromArgb(240, 255, 240); // Light background for listbox
//            this.listBoxPeers.SelectedIndexChanged += new System.EventHandler(this.listBoxPeers_SelectedIndexChanged);

//            // textBoxGroupName
//            this.textBoxGroupName.Location = new System.Drawing.Point(20, 60);
//            this.textBoxGroupName.Name = "textBoxGroupName";
//            this.textBoxGroupName.Size = new System.Drawing.Size(250, 20);
//            this.textBoxGroupName.TabIndex = 1;
//            this.textBoxGroupName.Font = new Font("Arial", 12); // Font size for text box

//            // buttonCreateGroup
//            this.buttonCreateGroup.Location = new System.Drawing.Point(20, 320);
//            this.buttonCreateGroup.Name = "buttonCreateGroup";
//            this.buttonCreateGroup.Size = new System.Drawing.Size(150, 30);
//            this.buttonCreateGroup.TabIndex = 4;
//            this.buttonCreateGroup.Text = "Create Group";
//            this.buttonCreateGroup.UseVisualStyleBackColor = true;
//            this.buttonCreateGroup.BackColor = Color.FromArgb(144, 238, 144); // Light Green
//            this.buttonCreateGroup.FlatAppearance.BorderColor = Color.Green;
//            this.buttonCreateGroup.FlatStyle = FlatStyle.Flat;

//            // Add hover effect for the button
//            this.buttonCreateGroup.MouseEnter += new EventHandler(ButtonHoverOn);
//            this.buttonCreateGroup.MouseLeave += new EventHandler(ButtonHoverOff);

//            this.buttonCreateGroup.Click += new System.EventHandler(this.buttonCreateGroup_Click);

//            // labelPeers
//            this.labelPeers.AutoSize = true;
//            this.labelPeers.Font = new System.Drawing.Font("Arial", 12F);
//            this.labelPeers.Location = new System.Drawing.Point(20, 100);
//            this.labelPeers.Name = "labelPeers";
//            this.labelPeers.Size = new System.Drawing.Size(102, 18);
//            this.labelPeers.TabIndex = 2;
//            this.labelPeers.Text = "Select Peers:";
//            this.labelPeers.ForeColor = Color.Black;

//            // Add controls to the form
//            this.Controls.Add(this.buttonCreateGroup);
//            this.Controls.Add(this.listBoxPeers);
//            this.Controls.Add(this.labelPeers);
//            this.Controls.Add(this.textBoxGroupName);
//            this.Controls.Add(this.labelGroupName);

//            this.Load += new System.EventHandler(this.GroupChatSetup_Load);
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        private void ButtonHoverOn(object sender, EventArgs e)
//        {
//            buttonCreateGroup.BackColor = Color.FromArgb(0, 128, 0); // Dark Green on hover
//        }

//        private void ButtonHoverOff(object sender, EventArgs e)
//        {
//            buttonCreateGroup.BackColor = Color.FromArgb(144, 238, 144); // Light Green
//        }

//        private void buttonCreateGroup_Click(object sender, EventArgs e)
//        {
//            // Get the selected peers from the ListBox
//            var selectedPeers = listBoxPeers.SelectedItems.Cast<string>().ToList();

//            if (selectedPeers.Count == 0)
//            {
//                MessageBox.Show("Please select at least one peer to create a group.");
//                return;
//            }

//            // Get the group name from the text box
//            string groupName = textBoxGroupName.Text.Trim();

//            if (string.IsNullOrEmpty(groupName))
//            {
//                MessageBox.Show("Please enter a group name.");
//                return;
//            }

//            // Send invites to the selected peers
//            //SendGroupInvite(groupName, selectedPeers);

//            // Show confirmation
//            MessageBox.Show($"Group '{groupName}' created with peers: {string.Join(", ", selectedPeers)}");

//            // Optionally, open the group chat window after sending invites
//            GroupChat newGroupChat = new GroupChat(selectedPeers, groupName);
//            newGroupChat.Show();
//        }

//        #endregion

//        private System.Windows.Forms.Label labelGroupName;
//        private System.Windows.Forms.TextBox textBoxGroupName;
//        private System.Windows.Forms.ListBox listBoxPeers;
//        private System.Windows.Forms.Button buttonCreateGroup;
//        private System.Windows.Forms.Label labelPeers;
//    }
//}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class GroupChatSetup : Form
    {
        private TcpClient peerConnection;
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

        private void InitializeComponent()
        {
            this.labelGroupName = new System.Windows.Forms.Label();
            this.listBoxPeers = new System.Windows.Forms.ListBox();
            this.textBoxGroupName = new System.Windows.Forms.TextBox();
            this.buttonCreateGroup = new System.Windows.Forms.Button();
            this.labelPeers = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Group Chat Setup Form
            this.ClientSize = new System.Drawing.Size(300, 380);
            this.Name = "GroupChatSetup";
            this.Text = "Group Chat Setup";
            this.BackColor = Color.FromArgb(210, 255, 210); // Light Green Background

            // labelGroupName
            this.labelGroupName.AutoSize = true;
            this.labelGroupName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelGroupName.Location = new System.Drawing.Point(20, 20);
            this.labelGroupName.Name = "labelGroupName";
            this.labelGroupName.Size = new System.Drawing.Size(188, 22);
            this.labelGroupName.TabIndex = 0;
            this.labelGroupName.Text = "Enter Group Name:";
            this.labelGroupName.ForeColor = Color.Black; // Font color black for visibility

            // listBoxPeers
            this.listBoxPeers.FormattingEnabled = true;
            this.listBoxPeers.Location = new System.Drawing.Point(20, 130);
            this.listBoxPeers.Name = "listBoxPeers";
            this.listBoxPeers.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxPeers.Size = new System.Drawing.Size(250, 173);
            this.listBoxPeers.TabIndex = 3;
            this.listBoxPeers.Font = new Font("Arial", 10); // Enhanced font
            this.listBoxPeers.ForeColor = Color.Black;
            this.listBoxPeers.BackColor = Color.FromArgb(240, 255, 240); // Light background for listbox
            this.listBoxPeers.SelectedIndexChanged += new System.EventHandler(this.listBoxPeers_SelectedIndexChanged);

            // textBoxGroupName
            this.textBoxGroupName.Location = new System.Drawing.Point(20, 60);
            this.textBoxGroupName.Name = "textBoxGroupName";
            this.textBoxGroupName.Size = new System.Drawing.Size(250, 20);
            this.textBoxGroupName.TabIndex = 1;
            this.textBoxGroupName.Font = new Font("Arial", 12); // Font size for text box

            // buttonCreateGroup
            this.buttonCreateGroup.Location = new System.Drawing.Point(20, 320);
            this.buttonCreateGroup.Name = "buttonCreateGroup";
            this.buttonCreateGroup.Size = new System.Drawing.Size(150, 30);
            this.buttonCreateGroup.TabIndex = 4;
            this.buttonCreateGroup.Text = "Create Group";
            this.buttonCreateGroup.UseVisualStyleBackColor = true;
            this.buttonCreateGroup.BackColor = Color.FromArgb(144, 238, 144); // Light Green
            this.buttonCreateGroup.FlatAppearance.BorderColor = Color.Green;
            this.buttonCreateGroup.FlatStyle = FlatStyle.Flat;

            // Add hover effect for the button
            this.buttonCreateGroup.MouseEnter += new EventHandler(ButtonHoverOn);
            this.buttonCreateGroup.MouseLeave += new EventHandler(ButtonHoverOff);

            this.buttonCreateGroup.Click += new System.EventHandler(this.buttonCreateGroup_Click);

            // labelPeers
            this.labelPeers.AutoSize = true;
            this.labelPeers.Font = new System.Drawing.Font("Arial", 12F);
            this.labelPeers.Location = new System.Drawing.Point(20, 100);
            this.labelPeers.Name = "labelPeers";
            this.labelPeers.Size = new System.Drawing.Size(102, 18);
            this.labelPeers.TabIndex = 2;
            this.labelPeers.Text = "Select Peers:";
            this.labelPeers.ForeColor = Color.Black;

            // Add controls to the form
            this.Controls.Add(this.buttonCreateGroup);
            this.Controls.Add(this.listBoxPeers);
            this.Controls.Add(this.labelPeers);
            this.Controls.Add(this.textBoxGroupName);
            this.Controls.Add(this.labelGroupName);

            this.Load += new System.EventHandler(this.GroupChatSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void ButtonHoverOn(object sender, EventArgs e)
        {
            buttonCreateGroup.BackColor = Color.FromArgb(0, 128, 0); // Dark Green on hover
        }

        private void ButtonHoverOff(object sender, EventArgs e)
        {
            buttonCreateGroup.BackColor = Color.FromArgb(144, 238, 144); // Light Green
        }

        private void buttonCreateGroup_Click(object sender, EventArgs e)
        {
            // Get the selected peers from the ListBox
            var selectedPeers = listBoxPeers.SelectedItems.Cast<string>().ToList();

            if (selectedPeers.Count == 0)
            {
                MessageBox.Show("Please select at least one peer to create a group.");
                return;
            }

            // Get the group name from the text box
            string groupName = textBoxGroupName.Text.Trim();

            if (string.IsNullOrEmpty(groupName))
            {
                MessageBox.Show("Please enter a group name.");
                return;
            }

            // Send invites to the selected peers
            //SendGroupInvite(groupName, selectedPeers);

            // Show confirmation
            MessageBox.Show($"Group '{groupName}' created with peers: {string.Join(", ", selectedPeers)}");

            // Optionally, open the group chat window after sending invites
            GroupChat newGroupChat = new GroupChat(selectedPeers, groupName);
            newGroupChat.Show();
        }

        #endregion

        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.ListBox listBoxPeers;
        private System.Windows.Forms.Button buttonCreateGroup;
        private System.Windows.Forms.Label labelPeers;
    }
}

