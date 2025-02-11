using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class client1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(client1));
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConnectToServer = new System.Windows.Forms.Button();
            this.btnRequestClientList = new System.Windows.Forms.Button();
            this.btnSelectPeer = new System.Windows.Forms.Button();
            this.txtPeerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendMessageToPeer = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.MakeGroup = new System.Windows.Forms.Button();
            this.grpOpen = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBoxLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.Location = new System.Drawing.Point(2, 77);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(459, 210);
            this.listBoxLogs.TabIndex = 0;
            this.listBoxLogs.SelectedIndexChanged += new System.EventHandler(this.listBoxLogs_SelectedIndexChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMessage.Location = new System.Drawing.Point(80, 409);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(526, 29);
            this.txtMessage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(90, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Message ";
            // 
            // btnConnectToServer
            // 
            this.btnConnectToServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectToServer.BackColor = System.Drawing.Color.LightGreen;
            this.btnConnectToServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnectToServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConnectToServer.Location = new System.Drawing.Point(632, 132);
            this.btnConnectToServer.Name = "btnConnectToServer";
            this.btnConnectToServer.Size = new System.Drawing.Size(126, 30);
            this.btnConnectToServer.TabIndex = 3;
            this.btnConnectToServer.Text = "Connect to Server";
            this.btnConnectToServer.UseVisualStyleBackColor = false;
            this.btnConnectToServer.Click += new System.EventHandler(this.btnConnectToServer_Click);
            this.btnConnectToServer.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnConnectToServer.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnRequestClientList
            // 
            this.btnRequestClientList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestClientList.BackColor = System.Drawing.Color.LightGreen;
            this.btnRequestClientList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestClientList.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRequestClientList.Location = new System.Drawing.Point(632, 189);
            this.btnRequestClientList.Name = "btnRequestClientList";
            this.btnRequestClientList.Size = new System.Drawing.Size(126, 30);
            this.btnRequestClientList.TabIndex = 4;
            this.btnRequestClientList.Text = "Peer List";
            this.btnRequestClientList.UseVisualStyleBackColor = false;
            this.btnRequestClientList.Click += new System.EventHandler(this.btnRequestClientList_Click);
            this.btnRequestClientList.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnRequestClientList.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // btnSelectPeer
            // 
            this.btnSelectPeer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPeer.BackColor = System.Drawing.Color.LightGreen;
            this.btnSelectPeer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectPeer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSelectPeer.Location = new System.Drawing.Point(632, 242);
            this.btnSelectPeer.Name = "btnSelectPeer";
            this.btnSelectPeer.Size = new System.Drawing.Size(126, 30);
            this.btnSelectPeer.TabIndex = 5;
            this.btnSelectPeer.Text = "Select Peer";
            this.btnSelectPeer.UseVisualStyleBackColor = false;
            this.btnSelectPeer.Click += new System.EventHandler(this.btnSelectPeer_Click);
            this.btnSelectPeer.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnSelectPeer.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // txtPeerIP
            // 
            this.txtPeerIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPeerIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPeerIP.Location = new System.Drawing.Point(102, 38);
            this.txtPeerIP.Name = "txtPeerIP";
            this.txtPeerIP.Size = new System.Drawing.Size(161, 20);
            this.txtPeerIP.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(99, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Peer (IP:Port)";
            // 
            // btnSendMessageToPeer
            // 
            this.btnSendMessageToPeer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMessageToPeer.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSendMessageToPeer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessageToPeer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendMessageToPeer.ForeColor = System.Drawing.Color.White;
            this.btnSendMessageToPeer.Location = new System.Drawing.Point(610, 406);
            this.btnSendMessageToPeer.Name = "btnSendMessageToPeer";
            this.btnSendMessageToPeer.Size = new System.Drawing.Size(107, 30);
            this.btnSendMessageToPeer.TabIndex = 8;
            this.btnSendMessageToPeer.Text = "Send Message";
            this.btnSendMessageToPeer.UseVisualStyleBackColor = false;
            this.btnSendMessageToPeer.Click += new System.EventHandler(this.btnSendMessageToPeer_Click);
            this.btnSendMessageToPeer.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnSendMessageToPeer.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(38, 409);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(382, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Server IP";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtServerIP.Location = new System.Drawing.Point(385, 37);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(168, 20);
            this.txtServerIP.TabIndex = 11;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(122, 295);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(473, 89);
            this.listView1.TabIndex = 27;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MakeGroup
            // 
            this.MakeGroup.BackColor = System.Drawing.Color.LightGreen;
            this.MakeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MakeGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.MakeGroup.Location = new System.Drawing.Point(632, 295);
            this.MakeGroup.Name = "MakeGroup";
            this.MakeGroup.Size = new System.Drawing.Size(135, 30);
            this.MakeGroup.TabIndex = 28;
            this.MakeGroup.Text = "Make Group";
            this.MakeGroup.UseVisualStyleBackColor = false;
            this.MakeGroup.Click += new System.EventHandler(this.MakeGroup_Click);
            this.MakeGroup.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.MakeGroup.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // grpOpen
            // 
            this.grpOpen.BackColor = System.Drawing.Color.LightGreen;
            this.grpOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grpOpen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpOpen.Location = new System.Drawing.Point(504, 132);
            this.grpOpen.Name = "grpOpen";
            this.grpOpen.Size = new System.Drawing.Size(75, 30);
            this.grpOpen.TabIndex = 29;
            this.grpOpen.Text = "Open Group";
            this.grpOpen.UseVisualStyleBackColor = false;
            this.grpOpen.Click += new System.EventHandler(this.grpOpen_Click);
            this.grpOpen.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.grpOpen.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnSendMessageToPeer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(819, 450);
            this.panel1.TabIndex = 30;
            // 
            // client1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 450);
            this.Controls.Add(this.listBoxLogs);
            this.Controls.Add(this.grpOpen);
            this.Controls.Add(this.MakeGroup);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtServerIP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPeerIP);
            this.Controls.Add(this.btnSelectPeer);
            this.Controls.Add(this.btnRequestClientList);
            this.Controls.Add(this.btnConnectToServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.panel1);
            this.Name = "client1";
            this.Text = "client1";
            this.Load += new System.EventHandler(this.client1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            // Change the background color to dark green when mouse enters
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.DarkGreen;
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            // Revert back to the original color when mouse leaves
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.Color.LightGreen;
        }


        #endregion

        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConnectToServer;
        private System.Windows.Forms.Button btnRequestClientList;
        private System.Windows.Forms.Button btnSelectPeer;
        private System.Windows.Forms.TextBox txtPeerIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSendMessageToPeer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button MakeGroup;
        private System.Windows.Forms.Button grpOpen;
        private Panel panel1;
    }
}


