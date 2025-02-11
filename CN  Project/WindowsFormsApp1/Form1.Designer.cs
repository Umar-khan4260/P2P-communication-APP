namespace WindowsFormsApp1
{
    partial class ServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.btnStartSever = new System.Windows.Forms.Button();
            this.listBoxLogs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnStartSever
            // 
            this.btnStartSever.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartSever.Location = new System.Drawing.Point(291, 125);
            this.btnStartSever.Name = "btnStartSever";
            this.btnStartSever.Size = new System.Drawing.Size(195, 33);
            this.btnStartSever.TabIndex = 0;
            this.btnStartSever.Text = "Start Server";
            this.btnStartSever.UseVisualStyleBackColor = true;
            this.btnStartSever.Click += new System.EventHandler(this.btnStartSever_Click);
            // 
            // listBoxLogs
            // 
            this.listBoxLogs.BackColor = System.Drawing.SystemColors.MenuText;
            this.listBoxLogs.ForeColor = System.Drawing.SystemColors.Window;
            this.listBoxLogs.FormattingEnabled = true;
            this.listBoxLogs.Location = new System.Drawing.Point(1, 175);
            this.listBoxLogs.Name = "listBoxLogs";
            this.listBoxLogs.Size = new System.Drawing.Size(485, 277);
            this.listBoxLogs.TabIndex = 1;
            this.listBoxLogs.SelectedIndexChanged += new System.EventHandler(this.listBoxLogs_SelectedIndexChanged);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxLogs);
            this.Controls.Add(this.btnStartSever);
            this.Name = "ServerForm";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStartSever;
        private System.Windows.Forms.ListBox listBoxLogs;
    }
}

