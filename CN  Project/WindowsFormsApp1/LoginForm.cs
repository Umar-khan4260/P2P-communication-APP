using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            

        }

        private void showpass_CheckedChanged(object sender, EventArgs e)
        {
            bool check = showpass.Checked;
            switch (check)
            {
                case true:
                    passtxt.UseSystemPasswordChar = false;
                    break;
                default:
                    passtxt.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (usertxt.Text == "" || passtxt.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //if (usertxt.Text == "abc@gmail.com" && passtxt.Text == "123")
                //{
                //    //string adminEmail = usertxt.Text;
                //    // MessageBox.Show("Logged in Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    client1 c1 = new client1();
                //    c1.Show();
                //    //this.Hide();
                //}
                //else if (usertxt.Text == "def@gmail.com" && passtxt.Text == "456")
                //{
                //    client2 c2 = new client2();
                //    c2.Show();
                //    this.Hide();
                //}
                //else if (usertxt.Text == "ghi@gmail.com" && passtxt.Text == "789")
                //{
                //    client3 c3 = new client3();
                //    c3.Show();
                //    this.Hide();
                //}
                //else if (usertxt.Text == "jkl@gmail.com" && passtxt.Text == "101")
                //{
                //    client4 c4 = new client4();
                //    c4.Show();
                //    this.Hide();
                //}

                //else
                //{
                //    MessageBox.Show("Incorrect UserName/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

                if (string.IsNullOrEmpty(usertxt.Text) || string.IsNullOrEmpty(passtxt.Text))
                {
                    MessageBox.Show("Please fill all the fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Define the file path
                    string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "C:\\Users\\muste\\Downloads\\Final CN_Project\\WindowsFormsApp1\\user_data1.txt");

                    // Check if the file exists
                    if (!System.IO.File.Exists(filePath))
                    {
                        MessageBox.Show("User data file not found. Please sign up first.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Read all lines from the file
                    string[] lines = System.IO.File.ReadAllLines(filePath);
                    bool isUserValid = false;

                    // Iterate through the lines to check for matching credentials
                    foreach (string line in lines)
                    {
                        // Each line is formatted as: "Email: {email}, Password: {password}"
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            string email = parts[0].Replace("Email: ", "").Trim();
                            string password = parts[1].Replace("Password: ", "").Trim();

                            if (email == usertxt.Text && password == passtxt.Text)
                            {
                                isUserValid = true;
                                break;
                            }
                        }
                    }

                    if (isUserValid)
                    {
                        MessageBox.Show("Login successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Navigate to client1 form
                        client1 c1 = new client1();
                        c1.Show();
                       // this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password. Please Signup first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            signupForm signup=new signupForm();
            signup.Show();
            this.Hide();
        }
    }
}
