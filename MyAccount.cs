using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BusBooking
{
    public partial class MyAccount : Form
    {
        private string email;
        FormControl formControl = new FormControl();
        private string company, loggedDate;
        private int id;

        private MySqlConnection profileConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_users");

        public MyAccount(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void TripButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.TripFormular(email);
            this.Dispose();
        }

        private void PassengersButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.PassengersFormular(email);
            this.Dispose();
        }

        private void BussesButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.BussesFormular(email);
            this.Dispose();
        }

        private void DriversButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.DriversFormular(email);
            this.Dispose();
        }

        private void AppLoad(object sender, EventArgs e)
        {
            int profileID = GetId(email);
            LoadData();
        }

        private int GetId(string email)
        {
            GetID getID = new GetID();
            return getID.userID(email);
        }

        private void LoadData()
        {
            string select = "SELECT * FROM user WHERE email = @email";
            MySqlCommand selectCmd = new MySqlCommand(select,profileConnection);
            selectCmd.Parameters.AddWithValue("@email", email);

            try
            {
                profileConnection.Open();
                MySqlDataReader reader = selectCmd.ExecuteReader();

                while (reader.Read())
                {
                    company = reader.GetString("company");
                    loggedDate = reader.GetString("logged");
                    id = reader.GetInt32("id");
                    if (loggedDate == "false") loggedDate = CurrentDate();
                }
                reader.Close();
                companyName.Text = company;
                companyEmail.Text = email;
                companyLogged.Text = loggedDate;
                companyID.Text = id.ToString(); 
            }
            catch
            {

            }
            finally
            {

            }
            
        }

        private void ShowUpdateForm(object sender, EventArgs e)
        {
            UpdateForm updForm = new UpdateForm(email,company);
            updForm.ShowDialog();
        }

        private void ShowStationForm(object sender, EventArgs e)
        {
            this.Hide();
            formControl.StationFormular(email);
            this.Dispose();
        }

        private string CurrentDate()
        {
            DateTime now = DateTime.Now;

            // Format the date and time
            string formattedDateTime = now.ToString("dd.MM yyyy HH:mm");
            return formattedDateTime;
        }
    }
}
