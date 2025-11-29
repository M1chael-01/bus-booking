using System;
using System.Windows.Forms;

namespace BusBooking
{
    public partial class Form1 : Form
    {
        private string email, password;
        FormControl formControl = new FormControl();
        public Form1()
        {
            InitializeComponent();
            ShowForm();
        }

        private void ShowForm()
        {
            string password = "1234";
            string hashed = BCrypt.Net.BCrypt.HashPassword(password);
            Clipboard.SetText(hashed);
            
            
        }

        private void Login(object sender, EventArgs e)
        {
            email = emailBox.Text;
            password = passwordBox.Text;
            UserSetting userSetting = new UserSetting();
            LoginStatus loginStatus = userSetting.Login(email, password);
            string msg = String.Empty;

            switch (loginStatus)
            {
                case LoginStatus.Success:
                    this.Hide();
                    formControl.TripFormular(email);
                    this.Dispose();

                    break;
                case LoginStatus.IncorrectPassword:
                    msg = "Incorrect passsword,try again";
                    ShowMessage(msg);

                    break;
                case LoginStatus.UserNotFound:
                    msg = "User not found, please check your email...";
                    ShowMessage(msg);

                    break;
                case LoginStatus.Error:
                    msg = "An error occurred during login. Please try again later.";
                    ShowMessage(msg);

                    break;
                default:
                    break;
            }
    }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
