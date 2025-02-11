using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.usertxt = new System.Windows.Forms.TextBox();
            this.passtxt = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.showpass = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsignup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usertxt
            // 
            this.usertxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usertxt.BackColor = System.Drawing.Color.White;
            this.usertxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usertxt.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.usertxt.Location = new System.Drawing.Point(184, 73);
            this.usertxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usertxt.Name = "usertxt";
            this.usertxt.Size = new System.Drawing.Size(188, 29);
            this.usertxt.TabIndex = 0;
            this.usertxt.Enter += new System.EventHandler(this.TextBox_Enter);
            this.usertxt.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // passtxt
            // 
            this.passtxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.passtxt.BackColor = System.Drawing.Color.White;
            this.passtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passtxt.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.passtxt.Location = new System.Drawing.Point(184, 112);
            this.passtxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passtxt.Name = "passtxt";
            this.passtxt.Size = new System.Drawing.Size(188, 29);
            this.passtxt.TabIndex = 1;
            this.passtxt.UseSystemPasswordChar = true;
            this.passtxt.Enter += new System.EventHandler(this.TextBox_Enter);
            this.passtxt.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // btnlogin
            // 
            this.btnlogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlogin.BackColor = System.Drawing.Color.LightGreen;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnlogin.Location = new System.Drawing.Point(287, 171);
            this.btnlogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(84, 41);
            this.btnlogin.TabIndex = 2;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            this.btnlogin.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnlogin.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // showpass
            // 
            this.showpass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.showpass.AutoSize = true;
            this.showpass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showpass.Location = new System.Drawing.Point(247, 141);
            this.showpass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(124, 23);
            this.showpass.TabIndex = 3;
            this.showpass.Text = "Show password";
            this.showpass.UseVisualStyleBackColor = true;
            this.showpass.CheckedChanged += new System.EventHandler(this.showpass_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(90, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "User Name";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(101, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // btnsignup
            // 
            this.btnsignup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsignup.BackColor = System.Drawing.Color.LightGreen;
            this.btnsignup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsignup.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsignup.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsignup.Location = new System.Drawing.Point(166, 171);
            this.btnsignup.Margin = new System.Windows.Forms.Padding(0);
            this.btnsignup.Name = "btnsignup";
            this.btnsignup.Size = new System.Drawing.Size(84, 41);
            this.btnsignup.TabIndex = 7;
            this.btnsignup.Text = "Sign up";
            this.btnsignup.UseVisualStyleBackColor = false;
            this.btnsignup.Click += new System.EventHandler(this.btnsignup_Click);
            this.btnsignup.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnsignup.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 325);
            this.Controls.Add(this.btnsignup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.showpass);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.passtxt);
            this.Controls.Add(this.usertxt);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            // Focus effect
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = System.Drawing.Color.LightGreen; // Subtle green background on focus
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            // Reset the focus effect
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BackColor = System.Drawing.Color.White;
            }
        }

        // When mouse enters, change button color to Dark Green
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = System.Drawing.Color.DarkGreen; // Change to dark green when mouse enters
            }
        }

        // When mouse leaves, revert button color to Light Green
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = System.Drawing.Color.LightGreen; // Revert to light green when mouse leaves
            }
        }

        #endregion

        private System.Windows.Forms.TextBox usertxt;
        private System.Windows.Forms.TextBox passtxt;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.CheckBox showpass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnsignup;
    }
}
