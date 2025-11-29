using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusBooking
{
    public partial class Passengers : Form
    {
        private string email;
        FormControl formControl = new FormControl();
        private string passengerName, passengerPhone, passengerBusNumber, passengerDestination;
        private int passengerSeat;
        private bool searched;
        private string searchedValue;

        private string message;
        private string sql;

        PassengerControl passControl = new PassengerControl();


        private string currentPassengerName;

        private MySqlConnection passengerConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_passengers");
        private MySqlConnection stationConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_stations");
        public Passengers(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void BussesButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.BussesFormular(email);
            this.Dispose();
        }

        private void TripsButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.TripFormular(email);
            this.Dispose();
        }

        private void StationButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.StationFormular(email);
            this.Dispose();
        }

        private void GetDestination(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            passengerDestination = box.Text;
        }

        private void DriversButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.DriversFormular(email);
            this.Dispose();
        }

        private void GetBusNumber(object sender, EventArgs e)
        {
            // push id from busses
            ComboBox box = (ComboBox)sender;
            passengerBusNumber = box.Text;
        }

        private void AppLoad(object sender, EventArgs e)
        {
            searched = false;
            sql = "SELECT * FROM passenger WHERE profileID = @id";
            ShowTable(sql);
            FillSelectTripBox();


        }
        private void FillSelectTripBox()
        {
            int id = getId(email);
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
                        pasDestination.Items.Add(name);
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

        private void ShowTable(string select)
        {
            int id = getId(email);
          
            MySqlCommand cmd = new MySqlCommand(select, passengerConnection);
            cmd.Parameters.AddWithValue("@id", id);

            if (searched)
            {
                cmd.Parameters.AddWithValue("@searchedName", "%" + searchedValue + "%");
            }
            try
            {
                passengerConnection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Phone", typeof(string));
                    dataTable.Columns.Add("Destination", typeof(string));
                    dataTable.Columns.Add("Bus ID", typeof(string));
                    dataTable.Columns.Add("Seat", typeof(int));

                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Name"] = reader.GetString(reader.GetOrdinal("name"));
                        row["Phone"] = reader.GetString(reader.GetOrdinal("phone"));
                        row["Destination"] = reader.GetString(reader.GetOrdinal("destination"));
                        row["Bus ID"] = reader.GetString(reader.GetOrdinal("bus_number"));
                        row["Seat"] = reader.GetInt32(reader.GetOrdinal("seat"));

                        dataTable.Rows.Add(row);
                    }
                    table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 48, 96);

                    table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    table.EnableHeadersVisualStyles = false;

                    table.DataSource = dataTable;

                    table.ClearSelection();
                    table.CellClick += ShowInformation;
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                passengerConnection.Close();
            }
        }

       

        private void ShowInformation(object sender, DataGridViewCellEventArgs e)
        {
         
            
                try
                {
                passengerConnection.Open();
                    string busName = table.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    int id = getId(email);
                    string select = "SELECT * FROM passenger WHERE profileID = @id AND name = @name";

                    MySqlCommand cmd = new MySqlCommand(select, passengerConnection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", busName);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            passengerName = reader.GetString("name");
                            passengerPhone = reader.GetString("phone");
                            passengerDestination = reader.GetString("destination");
                            passengerBusNumber = reader.GetString("bus_number");
                            passengerSeat = reader.GetInt32("seat");
                          

                            pasName.Text = passengerName;
                            pasPhone.Text = passengerPhone;
                            pasDestination.Text = passengerDestination;
                            pasSeat.Value = passengerSeat;
                        pasBusNumber.Text = passengerBusNumber;
                        currentPassengerName = passengerName;
                        }
                    }

                }
                catch
                {

                }
            finally
            {
                passengerConnection.Close();
            }

            }
        

     
           

        private void Clear(object sender, EventArgs e)
        {
            // clear it 
            passengerName = String.Empty;
            passengerPhone = String.Empty;
            passengerBusNumber = String.Empty;
            passengerDestination = String.Empty;
            pasName.Text = passengerName;
            pasPhone.Text = passengerPhone;
            pasBusNumber.Text = passengerBusNumber;
            pasDestination.Text = passengerDestination;


        }

        private void DeletePassenger(object sender, EventArgs e)
        {
            // delete
            int id = getId(email);
            string name = currentPassengerName;
            passControl.Delete(id, name);
            sql = "SELECT * FROM passenger WHERE profileID = @id";
            ShowTable(sql);
        }

        private void InvalidError(string message)
        {
            MessageBox.Show(message);
        }

       

        private void UpdateProfile(object sender, EventArgs e)
        {
            // update profile
            string old = currentPassengerName;
            string newName = pasName.Text;

            int id = getId(email);

          string msg =   passControl.Edit(id, newName,old, pasPhone.Text, pasDestination.Text, pasBusNumber.Text, (int)pasSeat.Value);

            MessageBox.Show(msg);
            sql = "SELECT * FROM passenger WHERE profileID = @id";
            ShowTable(sql);




        }

        private void SearchPassenger(object sender, KeyEventArgs e)
        {
            searchedValue = passengerSearchBox.Text;
            if (e.KeyCode == Keys.Enter && searchedValue.Length > 0)
            {
                searched = true;
                sql = "SELECT * FROM passenger WHERE profileID = @id AND name LIKE @searchedName";
                ShowTable(sql);


            }
        }

        private void SearchPassengerButton(object sender, EventArgs e)
        {
            searchedValue = passengerSearchBox.Text;
            if (searchedValue.Length > 0)
            {
                searched = true;
                sql = "SELECT * FROM passenger WHERE profileID = @id AND name LIKE @searchedName";
                ShowTable(sql);
            }
        }

        private void ClearSearchBox(object sender, EventArgs e)
        {
            searchedValue = String.Empty;
            passengerSearchBox.Text = searchedValue;
            searched = false;
            sql = "SELECT * FROM passenger WHERE profileID = @id";
            ShowTable(sql);
        }

        private void SelectDestination(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            passengerDestination = box.Text;

        }

        private void MyAccountButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.MyAccountFormular(email);
            this.Dispose();
        }

        private void AddPassenger(object sender, EventArgs e)
        {
            passengerName = pasName.Text;
            passengerPhone = pasPhone.Text;

            passengerSeat = (int)pasSeat.Value;

            if (string.IsNullOrEmpty(passengerName) || string.IsNullOrEmpty(passengerBusNumber) || string.IsNullOrEmpty(passengerDestination))
            {
                message = "Please fill the form";
                InvalidError(message);
            }

            else
            {
                if (string.IsNullOrEmpty(passengerPhone))
                {
                    message = "Please enter a phone";
                    InvalidError(message);
                }
                else
                {
                    if (!IsPhoneNumber(int.Parse(passengerPhone)))
                    {
                        message = "Please enter correct phone number";
                        InvalidError(message);
                    }
                    else
                    {
                        //check before
                        int id = getId(email);
                      

                        string insertQuery = "INSERT INTO passenger (profileID, name, phone, destination, bus_number, seat) " +
                                             "VALUES (@id, @name, @phone, @destination, @bus_number, @seat)";

                        using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, passengerConnection))
                        {
                            insertCmd.Parameters.AddWithValue("@id", id);
                            insertCmd.Parameters.AddWithValue("@name", passengerName);
                            insertCmd.Parameters.AddWithValue("@phone", passengerPhone);
                            insertCmd.Parameters.AddWithValue("@destination", passengerDestination);
                            insertCmd.Parameters.AddWithValue("@bus_number", passengerBusNumber);
                            insertCmd.Parameters.AddWithValue("@seat", passengerSeat);

                            try
                            {
                                if (passengerConnection.State != ConnectionState.Open)
                                {
                                    passengerConnection.Open();
                                    int rowsAffected = insertCmd.ExecuteNonQuery();
                                    // Check if insertion was successful
                                    if (rowsAffected > 0)
                                    {
                                        passengerConnection.Close();
                                        sql = "SELECT * FROM passenger WHERE profileID = @id";
                                        ShowTable(sql);
                                    }
                                    else
                                    {
                                        // Insertion failed
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Handle exceptions
                            }
                            finally
                            {
                                passengerConnection.Close();
                            }
                        }
                    }
                }
            }

        }

        private bool IsPhoneNumber(int phoneNumber)
        {
            return true;
        }


        private int getId(string email)
        {
            GetID id = new GetID();
            return id.userID(email);
        }
    }
}
