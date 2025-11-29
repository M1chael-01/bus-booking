using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BusBooking
{
    public partial class UpdateTripMenuForm : Form
    {
        private string pickedStation, email, callendar;
        private int pickedFare, pickedStationCount;

        private string stationCurrentName;
        private string currentCallendar;
        private MySqlConnection stationConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_stations");
        private MySqlConnection tripsConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_trips");

        public UpdateTripMenuForm(string pickeStation, int pickedFare, int pickedStationCount, string email , string curCallendar)
        {
            this.pickedStation = pickeStation;
            this.pickedFare = pickedFare;
            this.pickedStationCount = pickedStationCount;
            this.email = email;
            this.currentCallendar = curCallendar;
            InitializeComponent();
        }
        private void AppLoad(object sender, EventArgs e)
        {
            selections.Text = pickedStation;
            fareNumeric.Value = pickedFare;
            bookingCount.Value = pickedStationCount;
            stationCurrentName = pickedStation;
            monthCalendar1.SetDate(DateTime.Parse(currentCallendar));

            FillSelectTripBox();

            FillSelectTripBox();


        }

        private void GetStation(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            pickedStation = box.Text;
        }

        private void GetFare(object sender, EventArgs e)
        {
            pickedFare = (int)fareNumeric.Value;
        }

        private void getCount(object sender, EventArgs e)
        {
            pickedStationCount = (int)bookingCount.Value;
        }

        private void ClearValues(object sender, EventArgs e)
        {
            pickedFare = 0;
            pickedStationCount = 0;
            pickedStation = String.Empty;

            fareNumeric.Value = pickedStationCount;
            bookingCount.Value = pickedStationCount;
            selections.Text = pickedStation;
            selections.Select();
        }

        private void UpdateTrip(object sender, EventArgs e)
        {
            if (pickedFare > 0 && pickedStationCount > 0 && pickedStation != String.Empty && callendar != String.Empty) { 
            
            string updateQuery = "UPDATE trip SET name = @name, date = @date, fare = @fare, booking = @count, amount = @amount WHERE profileID = @id AND name = @current";

            int id = Getid(email); // Assuming GetId is a method that retrieves the profile ID based on email
            string current = stationCurrentName;

                using (MySqlCommand updatedCommand = new MySqlCommand(updateQuery, tripsConnection))
                {
                    updatedCommand.Parameters.AddWithValue("@name", pickedStation);
                    updatedCommand.Parameters.AddWithValue("@date", callendar); // Assuming callendar is a typo and should be calendar
                    updatedCommand.Parameters.AddWithValue("@fare", pickedFare);
                    updatedCommand.Parameters.AddWithValue("@count", pickedStationCount);
                    updatedCommand.Parameters.AddWithValue("@amount", pickedFare * pickedStationCount);
                    updatedCommand.Parameters.AddWithValue("@id", id);
                    updatedCommand.Parameters.AddWithValue("@current", current);

                    try
                    {
                        tripsConnection.Open();
                        int rowsAffected = updatedCommand.ExecuteNonQuery();
                        MessageBox.Show("Trip updated successfully. Rows affected: " + rowsAffected);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                        Clipboard.SetText(ex.ToString()); // Copying the full exception details for debugging
                    }
                    finally
                    {
                        tripsConnection.Close();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Please fill it up");
            }
        }


        private void GetDate(object sender, DateRangeEventArgs e)
        {
            callendar = monthCalendar1.SelectionRange.Start.ToString("yyyy-MM-dd");
            MessageBox.Show(callendar);
            Clipboard.SetText(callendar);
        }

        

        private void FillSelectTripBox()
        {
            int id = Getid(email);
            string selectStations = "SELECT * FROM station WHERE profileID = @id";
            MySqlCommand selectStationsCmd = new MySqlCommand(selectStations, stationConnection);
            selectStationsCmd.Parameters.AddWithValue("@id", id);

            try
            {
                stationConnection.Open();
                using (var reader = selectStationsCmd.ExecuteReader())
                {
                    while (reader.Read())
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
                stationConnection.Close();
            }
        }

        private int Getid(string email)
        {
            GetID getID = new GetID();
            return getID.userID(email);
        }

      
    }
}
