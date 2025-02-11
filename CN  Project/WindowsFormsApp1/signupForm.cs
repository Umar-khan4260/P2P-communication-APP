using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class signupForm : Form
    {
        string randomCode="123";
        public static string to;
        public signupForm()
        {
            InitializeComponent();
        }

        // Email validation method
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void signupForm_Load(object sender, EventArgs e)
        {

        }

        private void genOTP_CheckedChanged(object sender, EventArgs e)
        {
            string from, pass, messageBody, to;
            Random rand = new Random();

            // Ensure the random OTP is always a 6-digit number
            string randomCode = rand.Next(100000, 999999).ToString();

            // Email setup
            from = "imranalinaeem3397@gmail.com";  // Only email address here
            pass = "smvh dtyk rnpz bjjg";  // Your email password or app-specific password
            messageBody = "Your reset code is " + randomCode;

            // Set recipient email
            to = email.Text.Trim();  // Ensure no extra spaces in the email address

            // Create the MailMessage object
            MailMessage message = new MailMessage();
            message.To.Add(to);  // Add recipient
            message.From = new MailAddress(from, "p2p-Application");  // Correctly add display name separately
            message.Body = messageBody;  // Email body
            message.Subject = "Password Reset Code";  // Email subject

            // SMTP client setup
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            // Try to send the email
            try
            {
                smtp.Send(message);  // Send the email
                MessageBox.Show("Code sent successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SmtpException smtpEx)
            {
                // Specific exception handling for SMTP-related errors
                MessageBox.Show($"SMTP Error: {smtpEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // General exception handling for other errors
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(email.Text) || !IsValidEmail(email.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(password.Text) ||
                string.IsNullOrEmpty(conpassword.Text) ||
                string.IsNullOrEmpty(otp.Text) ||
                !genOTP.Checked)
            {
                MessageBox.Show("Please fill all fields.", "Failure", MessageBoxButtons.OK);
                return;
            }

            if (password.Text == conpassword.Text && otp.Text == randomCode)
            {
                try
                {
                    // Define a secure file path
                    string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "E:\\CN  Project\\WindowsFormsApp1\\user_data1.txt");

                    // Debug: Show values being saved
                    MessageBox.Show($"Saving: Email={email.Text}, Password={password.Text}", "Debug Info");

                    // Prepare the data to save
                    string userData = $"Email: {email.Text}, Password: {password.Text}";

                    // Append data to the file
                    System.IO.File.AppendAllText(filePath, userData + Environment.NewLine);

                    // Show success message
                    MessageBox.Show("Signup successful! Your data has been saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear fields after saving
                    email.Clear();
                    password.Clear();
                    conpassword.Clear();
                    otp.Clear();
                    genOTP.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match or OTP is incorrect!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Clear();
                conpassword.Clear();
                password.Focus();
            }
        }

        private void goToLogin_Click(object sender, EventArgs e)
        {
            LoginForm login=new LoginForm();
            login.ShowDialog();
            this.Close();
        }
    }
}
