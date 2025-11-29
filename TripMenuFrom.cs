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
    public partial class TripMenuFrom : Form
    {
        private string email;
        private string selection;
        private int fare, maxCount;

        private string callendar;
        private MySqlConnection tripsConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_trips");
        private MySqlConnection stationConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_stations");
        public TripMenuFrom(string email)
        {
            this.email = email;
            InitializeComponent();
        }

        private void ClearValues(object sender, EventArgs e)
        {
            selection = String.Empty;
            callendar = String.Empty;
            fare = 0;
            maxCount = 0;
            selections.Text = selection;
            fareNumeric.Value = fare;
            bookingCount.Value = maxCount;
            monthCalendar1.SelectionStart = monthCalendar1.SelectionEnd = DateTime.Today; // Clear selection

        }

        private void GetFare(object sender, EventArgs e)
        {
            fare = (int)fareNumeric.Value;
        }

        private void GetCount(object sender, EventArgs e)
        {
            maxCount = (int)bookingCount.Value;
        }

        private void GetCallendar(object sender, DateRangeEventArgs e)
        {
            callendar = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            MessageBox.Show(callendar);
        }

        private void AppLoad(object sender, EventArgs e)
        {
            FillSelectTripBox();
        }

        private void FillSelectTripBox()
        {
            int id = Getid(email);
            string selectStations = "SELECT * FROM station WHERE profileID = @id";
            MySqlCommand selectStationsCmd = new MySqlCommand(selectStations,stationConnection);
            selectStationsCmd.Parameters.AddWithValue("@id", id);

            try
            {
               stationConnection.Open();
                using (var reader = selectStationsCmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        string name = reader.GetString("place");
                           selections.Items.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {

            }
        }

        private int Getid(string email)
        {
            GetID getID = new GetID();
            return getID.userID(email);
        }

        private void GetStation(object sender, EventArgs e)
        {
           ComboBox box = (ComboBox)sender;
            selection = box.Text;
        }

        private void CreateTrip(object sender, EventArgs e)
        {
            if (selection != String.Empty && fare > 0 && maxCount > 0 && callendar != String.Empty)
            {
                int id = Getid(email);
                string sql = "INSERT INTO trip (profileID,name, status, date, fare, booking, amount) VALUES (@id,@name, @status, @date, @fare, @booking, @amount)";
                MySqlCommand cmd = new MySqlCommand(sql, tripsConnection);

                // Set parameter values
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", selection); // Assuming 'selection' contains the trip name
                cmd.Parameters.AddWithValue("@status", "Pending"); // Assuming status is initially set to 'Pending'
                cmd.Parameters.AddWithValue("@date", callendar);
                cmd.Parameters.AddWithValue("@fare", fare);
                cmd.Parameters.AddWithValue("@booking", maxCount);
                cmd.Parameters.AddWithValue("@amount", maxCount * fare);

                try
                {
                    tripsConnection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Trip created successfully!");
                        ClearValues(sender, e); // Optionally clear form values after successful creation
                    }
                    else
                    {
                        MessageBox.Show("Failed to create trip.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
                finally
                {
                    tripsConnection.Close();
                }
            }
            else
            {
                MessageBox.Show("Please fill it");
            }
        }
        

    }
}
