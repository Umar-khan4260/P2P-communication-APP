using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class signupForm
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
            this.conpassword = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.genOTP = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.otp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.goToLogin = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // conpassword
            // 
            this.conpassword.BackColor = System.Drawing.Color.White;
            this.conpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.conpassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.conpassword.ForeColor = System.Drawing.Color.Black;
            this.conpassword.Location = new System.Drawing.Point(172, 210);
            this.conpassword.Name = "conpassword";
            this.conpassword.Size = new System.Drawing.Size(162, 25);
            this.conpassword.TabIndex = 3;
            this.conpassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.conpassword.UseSystemPasswordChar = true;
            this.conpassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.conpassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.White;
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.email.ForeColor = System.Drawing.Color.Black;
            this.email.Location = new System.Drawing.Point(172, 108);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(162, 25);
            this.email.TabIndex = 1;
            this.email.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.email.Enter += new System.EventHandler(this.TextBox_Enter);
            this.email.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.White;
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.password.ForeColor = System.Drawing.Color.Black;
            this.password.Location = new System.Drawing.Point(172, 160);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(162, 25);
            this.password.TabIndex = 2;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.password.UseSystemPasswordChar = true;
            this.password.Enter += new System.EventHandler(this.TextBox_Enter);
            this.password.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // genOTP
            // 
            this.genOTP.AutoSize = true;
            this.genOTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genOTP.Location = new System.Drawing.Point(350, 269);
            this.genOTP.Name = "genOTP";
            this.genOTP.Size = new System.Drawing.Size(95, 17);
            this.genOTP.TabIndex = 3;
            this.genOTP.Text = "Generate OTP";
            this.genOTP.UseVisualStyleBackColor = true;
            this.genOTP.CheckedChanged += new System.EventHandler(this.genOTP_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(43, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Username/Email";
            // 
            // otp
            // 
            this.otp.BackColor = System.Drawing.Color.White;
            this.otp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.otp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.otp.ForeColor = System.Drawing.Color.Black;
            this.otp.Location = new System.Drawing.Point(172, 266);
            this.otp.Name = "otp";
            this.otp.Size = new System.Drawing.Size(162, 25);
            this.otp.TabIndex = 4;
            this.otp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.otp.Enter += new System.EventHandler(this.TextBox_Enter);
            this.otp.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(43, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "OTP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(43, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(43, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "Password";
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackColor = System.Drawing.Color.LightGreen;
            this.btnsubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsubmit.FlatAppearance.BorderSize = 0;
            this.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnsubmit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsubmit.Location = new System.Drawing.Point(299, 345);
            this.btnsubmit.Margin = new System.Windows.Forms.Padding(0);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(112, 35);
            this.btnsubmit.TabIndex = 5;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            this.btnsubmit.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.btnsubmit.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // goToLogin
            // 
            this.goToLogin.BackColor = System.Drawing.Color.LightGreen;
            this.goToLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goToLogin.FlatAppearance.BorderSize = 0;
            this.goToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goToLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.goToLogin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.goToLogin.Location = new System.Drawing.Point(46, 345);
            this.goToLogin.Margin = new System.Windows.Forms.Padding(0);
            this.goToLogin.Name = "goToLogin";
            this.goToLogin.Size = new System.Drawing.Size(112, 35);
            this.goToLogin.TabIndex = 10;
            this.goToLogin.Text = "Go to Login";
            this.goToLogin.UseVisualStyleBackColor = false;
            this.goToLogin.Click += new System.EventHandler(this.goToLogin_Click);
            this.goToLogin.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.goToLogin.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 378);
            this.panel1.TabIndex = 11;
            // 
            // signupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(442, 383);
            this.Controls.Add(this.goToLogin);
            this.Controls.Add(this.btnsubmit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.otp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genOTP);
            this.Controls.Add(this.password);
            this.Controls.Add(this.email);
            this.Controls.Add(this.conpassword);
            this.Controls.Add(this.panel1);
            this.Name = "signupForm";
            this.Text = "Sign Up";
            this.Load += new System.EventHandler(this.signupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            // When a text box gains focus, change the border color (e.g., to blue)
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BorderStyle = BorderStyle.Fixed3D;
                textBox.BackColor = System.Drawing.Color.LightYellow; // Optional background color
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            // When the text box loses focus, reset the border style to its default
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.BorderStyle = BorderStyle.FixedSingle;
                textBox.BackColor = System.Drawing.Color.White; // Reset background color
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

        private System.Windows.Forms.TextBox conpassword;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.CheckBox genOTP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox otp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Button goToLogin;
        private Panel panel1;
    }
}
