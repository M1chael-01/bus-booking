using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusBooking
{
    
    public partial class UpdateForm : Form
    {
        private MySqlConnection profileConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_users");
        private string email, company;
        int id;

        private void AppLoad(object sender, EventArgs e)
        {
            id = GetId(email);
            emailC.Text = email;
            companyName.Text = company;
        }

        private void UpdateProfile(object sender, EventArgs e)
        {

            email = emailC.Text;
            company = companyName.Text;
            string update = "UPDATE user SET company = @company, email = @email WHERE id = @id";

            using (MySqlCommand cmd = new MySqlCommand(update, profileConnection))
            {
                cmd.Parameters.AddWithValue("@company", company);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    profileConnection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No changes were made to the profile.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } // MySqlCommand is automatically disposed here
        }


        private int GetId(string email)
        {
            GetID id = new GetID();
            return id.userID(email);
        }

        private void ClearProfile(object sender, EventArgs e)
        {
            email = String.Empty;
            company = String.Empty;
            emailC.Text = email;
            companyName.Text = company;
        }

        private void AppClose(object sender, FormClosedEventArgs e)
        {
            MyAccount acc = new MyAccount(email);
            this.Hide();
            acc.ShowDialog();
            this.Close();
        }

        public UpdateForm(string email,string company)
        {
            this.email = email;
            this.company = company;
            InitializeComponent();
        }

      
    }
}
