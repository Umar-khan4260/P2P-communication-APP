//using System.Drawing;

//namespace ServerApp
//{
//    partial class ServerForm
//    {
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

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.tabControl1 = new System.Windows.Forms.TabControl();
//            this.tabPage1 = new System.Windows.Forms.TabPage();
//            this.tabPage2 = new System.Windows.Forms.TabPage();
//            this.btnStopBackupServer = new System.Windows.Forms.Button();
//            this.btnStartBackupServer = new System.Windows.Forms.Button();
//            this.listBoxLogs = new System.Windows.Forms.ListBox();
//            this.btnStopServer = new System.Windows.Forms.Button();
//            this.btnStartSever = new System.Windows.Forms.Button();
//            this.tabControl1.SuspendLayout();
//            this.tabPage1.SuspendLayout();
//            this.tabPage2.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // tabControl1
//            // 
//            this.tabControl1.Controls.Add(this.tabPage1);
//            this.tabControl1.Controls.Add(this.tabPage2);
//            this.tabControl1.Location = new System.Drawing.Point(2, 2);
//            this.tabControl1.Name = "tabControl1";
//            this.tabControl1.SelectedIndex = 0;
//            this.tabControl1.Size = new System.Drawing.Size(786, 153);
//            this.tabControl1.TabIndex = 5;
//            // 
//            // tabPage1
//            // 
//            this.tabPage1.Controls.Add(this.btnStopServer);
//            this.tabPage1.Controls.Add(this.btnStartSever);
//            this.tabPage1.Location = new System.Drawing.Point(4, 22);
//            this.tabPage1.Name = "tabPage1";
//            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPage1.Size = new System.Drawing.Size(778, 127);
//            this.tabPage1.TabIndex = 0;
//            this.tabPage1.Text = "Main Server";
//            this.tabPage1.UseVisualStyleBackColor = true;
//            // 
//            // tabPage2
//            // 
//            this.tabPage2.Controls.Add(this.btnStopBackupServer);
//            this.tabPage2.Controls.Add(this.btnStartBackupServer);
//            this.tabPage2.Location = new System.Drawing.Point(4, 22);
//            this.tabPage2.Name = "tabPage2";
//            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
//            this.tabPage2.Size = new System.Drawing.Size(778, 127);
//            this.tabPage2.TabIndex = 1;
//            this.tabPage2.Text = "Backup Server";
//            this.tabPage2.UseVisualStyleBackColor = true;
//            // 
//            // btnStopBackupServer
//            // 
//            this.btnStopBackupServer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnStopBackupServer.Location = new System.Drawing.Point(285, 91);
//            this.btnStopBackupServer.Name = "btnStopBackupServer";
//            this.btnStopBackupServer.Size = new System.Drawing.Size(195, 33);
//            this.btnStopBackupServer.TabIndex = 10;
//            this.btnStopBackupServer.Text = "Stop Server";
//            this.btnStopBackupServer.UseVisualStyleBackColor = true;
//            this.btnStopBackupServer.Click += new System.EventHandler(this.btnStopBackupServer_Click);
//            // 
//            // btnStartBackupServer
//            // 
//            this.btnStartBackupServer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnStartBackupServer.Location = new System.Drawing.Point(4, 91);
//            this.btnStartBackupServer.Name = "btnStartBackupServer";
//            this.btnStartBackupServer.Size = new System.Drawing.Size(195, 33);
//            this.btnStartBackupServer.TabIndex = 8;
//            this.btnStartBackupServer.Text = "Start Server";
//            this.btnStartBackupServer.UseVisualStyleBackColor = true;
//            this.btnStartBackupServer.Click += new System.EventHandler(this.btnStartBackupServer_Click);
//            // 
//            // listBoxLogs
//            // 
//            this.listBoxLogs.BackColor = System.Drawing.SystemColors.MenuText;
//            this.listBoxLogs.ForeColor = System.Drawing.SystemColors.Window;
//            this.listBoxLogs.FormattingEnabled = true;
//            this.listBoxLogs.Location = new System.Drawing.Point(3, 170);
//            this.listBoxLogs.Name = "listBoxLogs";
//            this.listBoxLogs.Size = new System.Drawing.Size(485, 277);
//            this.listBoxLogs.TabIndex = 7;
//            // 
//            // btnStopServer
//            // 
//            this.btnStopServer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnStopServer.Location = new System.Drawing.Point(276, 88);
//            this.btnStopServer.Name = "btnStopServer";
//            this.btnStopServer.Size = new System.Drawing.Size(195, 33);
//            this.btnStopServer.TabIndex = 9;
//            this.btnStopServer.Text = "Stop Server";
//            this.btnStopServer.UseVisualStyleBackColor = true;
//            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click_1);
//            // 
//            // btnStartSever
//            // 
//            this.btnStartSever.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnStartSever.Location = new System.Drawing.Point(6, 88);
//            this.btnStartSever.Name = "btnStartSever";
//            this.btnStartSever.Size = new System.Drawing.Size(195, 33);
//            this.btnStartSever.TabIndex = 8;
//            this.btnStartSever.Text = "Start Server";
//            this.btnStartSever.UseVisualStyleBackColor = true;
//            this.btnStartSever.Click += new System.EventHandler(this.btnStartSever_Click_1);
//            // 
//            // ServerForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(800, 450);
//            this.Controls.Add(this.listBoxLogs);
//            this.Controls.Add(this.tabControl1);
//            this.Name = "ServerForm";
//            this.Text = "Server";
//            this.Load += new System.EventHandler(this.ServerForm_Load);
//            this.tabControl1.ResumeLayout(false);
//            this.tabPage1.ResumeLayout(false);
//            this.tabPage2.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.TabControl tabControl1;
//        private System.Windows.Forms.TabPage tabPage1;
//        private System.Windows.Forms.TabPage tabPage2;
//        private System.Windows.Forms.Button btnStopBackupServer;
//        private System.Windows.Forms.Button btnStartBackupServer;
//        private System.Windows.Forms.ListBox listBoxLogs;
//        private System.Windows.Forms.Button btnStopServer;
//        private System.Windows.Forms.Button btnStartSever;
//    }
//}


using System;
using System.Drawing;
using System.Windows.Forms;

namespace ServerApp
{
    partial class ServerForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStopServer;
        private System.Windows.Forms.Button btnStartServer;
        private System.Windows.Forms.Button btnStopBackupServer;
        private System.Windows.Forms.Button btnStartBackupServer;
        private System.Windows.Forms.ListBox listBoxLogs;
        private System.Windows.Forms.Label lblLogs;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button btnClose; // Close button

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStartServer = new System.Windows.Forms.Button();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnStartBackupServer = new System.Windows.Forms.Button();
            this.btnStopBackupServer = new System.Windows.Forms.Button();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.lblLogs = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(10, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(780, 147);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tabPage1.Controls.Add(this.btnStartServer);
            this.tabPage1.Controls.Add(this.btnStopServer);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(30);
            this.tabPage1.Size = new System.Drawing.Size(772, 117);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Server";
            // 
            // btnStartServer
            // 
            this.btnStartServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.btnStartServer.FlatAppearance.BorderSize = 0;
            this.btnStartServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartServer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartServer.Location = new System.Drawing.Point(20, 50);
            this.btnStartServer.Name = "btnStartServer";
            this.btnStartServer.Size = new System.Drawing.Size(180, 40);
            this.btnStartServer.TabIndex = 0;
            this.btnStartServer.Text = "Start Server";
            this.btnStartServer.UseVisualStyleBackColor = false;
            this.btnStartServer.Click += new System.EventHandler(this.btnStartSever_Click);
            // 
            // btnStopServer
            // 
            this.btnStopServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnStopServer.FlatAppearance.BorderSize = 0;
            this.btnStopServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStopServer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStopServer.Location = new System.Drawing.Point(250, 50);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(180, 40);
            this.btnStopServer.TabIndex = 1;
            this.btnStopServer.Text = "Stop Server";
            this.btnStopServer.UseVisualStyleBackColor = false;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.tabPage2.Controls.Add(this.btnStartBackupServer);
            this.tabPage2.Controls.Add(this.btnStopBackupServer);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(772, 117);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Backup Server";
            // 
            // btnStartBackupServer
            // 
            this.btnStartBackupServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.btnStartBackupServer.FlatAppearance.BorderSize = 0;
            this.btnStartBackupServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartBackupServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartBackupServer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStartBackupServer.Location = new System.Drawing.Point(20, 50);
            this.btnStartBackupServer.Name = "btnStartBackupServer";
            this.btnStartBackupServer.Size = new System.Drawing.Size(180, 40);
            this.btnStartBackupServer.TabIndex = 0;
            this.btnStartBackupServer.Text = "Start Backup Server";
            this.btnStartBackupServer.UseVisualStyleBackColor = false;
            this.btnStartBackupServer.Click += new System.EventHandler(this.btnStartBackupServer_Click);
            // 
            // btnStopBackupServer
            // 
            this.btnStopBackupServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnStopBackupServer.FlatAppearance.BorderSize = 0;
            this.btnStopBackupServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopBackupServer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStopBackupServer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStopBackupServer.Location = new System.Drawing.Point(250, 50);
            this.btnStopBackupServer.Name = "btnStopBackupServer";
            this.btnStopBackupServer.Size = new System.Drawing.Size(180, 40);
            this.btnStopBackupServer.TabIndex = 1;
            this.btnStopBackupServer.Text = "Stop Backup Server";
            this.btnStopBackupServer.UseVisualStyleBackColor = false;
            this.btnStopBackupServer.Click += new System.EventHandler(this.btnStopBackupServer_Click);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.BackColor = System.Drawing.Color.Black;
            this.listBoxLogs.Font = new System.Drawing.Font("Consolas", 10F);
            this.listBoxLogs.ForeColor = System.Drawing.Color.Lime;
            this.listBoxLogs.ItemHeight = 15;
            this.listBoxLogs.Location = new System.Drawing.Point(10, 210);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(777, 199);
            this.listBoxLogs.TabIndex = 2;
            // 
            // lblLogs
            // 
            this.lblLogs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLogs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblLogs.Location = new System.Drawing.Point(10, 180);
            this.lblLogs.Name = "lblLogs";
            this.lblLogs.Size = new System.Drawing.Size(100, 23);
            this.lblLogs.TabIndex = 1;
            this.lblLogs.Text = "Server Logs:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.LightGray;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(10, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(767, 22);
            this.statusStrip1.TabIndex = 3;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(82)))), ((int)(((byte)(82)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Location = new System.Drawing.Point(757, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ServerForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(787, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblLogs);
            this.Controls.Add(this.listBoxLogs);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ServerForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Server Management";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Close button click event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



