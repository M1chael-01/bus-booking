using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusBooking
{
    public partial class Station : Form
    {
        private string email;

        private string sPlace, sql, searchedValue;
        private DateTime  sAddedDate;
        private bool searched;
       

       
        FormControl formControl = new FormControl();
        StationControl stationControl = new StationControl();
        private MySqlConnection stationConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_stations");
        public Station(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void DeleteDestination(object sender, EventArgs e)
        {
            int id = GetId(email);
            if ((stationControl.Delete(id, sPlace)))
            {
                UpdateDate();
                CleanDestination();
                searched = false;
                sql = "SELECT * FROM station WHERE profileId = @id";
                ShowTable(sql);
            }
            // profileID,place
        }

        private int GetId(string email)
        {
            GetID getID = new GetID();
            return getID.userID(email);
        }

        private void ClearDestination(object sender, EventArgs e)
        {
            sPlace = String.Empty;
            sAddedDate = DateTime.MinValue;
            destinationName.Text = sPlace;
            addedDate.Text = sPlace;
            UpdateDate();
        }

        private void AddDestination(object sender, EventArgs e)
        {
            sPlace = destinationName.Text;
            int id = GetId(email);
            if (stationControl.Add(id, sPlace, sAddedDate))
            {
                UpdateDate();
                CleanDestination();
                searched = false;
                sql = "SELECT * FROM station WHERE profileId = @id";
                ShowTable(sql);
            }
           
            // profileId,place,date
        }

        private void EditDestination(object sender, EventArgs e)
        {
            int id = GetId(email);
            string current = destinationName.Text;
            string old = sPlace;
            string updatedDateString = DateTime.Now.ToShortDateString(); // Store the current date as a string

            DateTime updatedDate;
            if (DateTime.TryParse(updatedDateString, out updatedDate)) // Attempt to parse the string to a DateTime object
            {
                if (stationControl.Edit(id, current, old, updatedDate)) // Pass the updatedDate as a DateTime parameter to the Edit method
                {
                    searched = false;
                    UpdateDate();
                    CleanDestination();
                    sql = "SELECT * FROM station WHERE profileId = @id";
                    ShowTable(sql);
                }
              
            }
           
        }
        

        private void ShowTripsForm(object sender, EventArgs e)
        {
            this.Hide();
            formControl.TripFormular(email);
            this.Dispose();
        }

        private void ShowPassengerForm(object sender, EventArgs e)
        {
            this.Hide();
            formControl.PassengersFormular(email);
            this.Dispose();
        }

        private void ShowBussesForm(object sender, EventArgs e)
        {
            this.Hide();
            formControl.BussesFormular(email);
            this.Dispose();
        }

        private void ShowDriversForm(object sender, EventArgs e)
        {
            this.Hide();
            formControl.DriversFormular(email);
            this.Dispose();
        }
        private void UpdateDate()
        {
            DateTime sAddedDate = DateTime.Now; // Store the current date and time
            string formattedDate = sAddedDate.ToShortDateString(); // Convert to short date string format
            addedDate.Text = formattedDate; // Display the formatted date in the text box
        }
        private void CleanDestination()
        {
            sPlace = String.Empty;
            destinationName.Text = sPlace;
        }

        private void AppLoad(object sender, EventArgs e)
        {
            try
            {
                UpdateDate();

            }
            catch { };
          
            searched = false;
            sql = "SELECT * FROM station WHERE profileId = @id";
            ShowTable(sql);
        }

        private void ShowTable(string select)
        {
            int id = GetId(email);
            MySqlCommand cmd = new MySqlCommand(select, stationConnection);
            cmd.Parameters.AddWithValue("@id", id);
            if (searched)
            {
                cmd.Parameters.AddWithValue("@searchedValue", "%" + searchedValue + "%");
            }
            try
            {
                stationConnection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Destination", typeof(string));
                    dataTable.Columns.Add("Added Date", typeof(DateTime));

                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Destination"] = reader.GetString(reader.GetOrdinal("place"));
                        row["Added Date"] = reader.GetDateTime(reader.GetOrdinal("addedDate"));
                      

                        dataTable.Rows.Add(row);
                    }
                    table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 48, 96);

                    table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    table.EnableHeadersVisualStyles = false;

                    table.DataSource = dataTable;

                    table.ClearSelection();
                    table.CellClick += StationInfo;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
               stationConnection.Close();
            }
        }

        private void SearchByClick(object sender, EventArgs e)
        {
            searchedValue = stationTextBox.Text;
            if (searchedValue.Length > 0)
            {
                searched = true;
                sql = "SELECT * FROM station WHERE profileId = @id AND place LIKE @searchedValue";
                ShowTable(sql);
            }
        }

        private void SearchByEnter(object sender, KeyEventArgs e)
        {
            searchedValue = stationTextBox.Text;
            if (searchedValue.Length > 0 && e.KeyCode == Keys.Enter)
            {
                searched = true;
                sql = "SELECT * FROM station WHERE profileId = @id AND place LIKE @searchedValue";
                ShowTable(sql);
            }
        }

        private void ClearTextBox(object sender, EventArgs e)
        {
            searchedValue = String.Empty;
            stationTextBox.Text = searchedValue;
            searched = false;
            sql = "SELECT * FROM station WHERE profileId = @id";
            ShowTable(sql);
        }

        private void StationInfo(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string destination = table.Rows[e.RowIndex].Cells["Destination"].Value.ToString();
                int id = GetId(email);
                string sql = "SELECT * FROM station WHERE place = @place AND profileID = @id";
                MySqlCommand sqlCmd = new MySqlCommand(sql,stationConnection);
                sqlCmd.Parameters.AddWithValue("@place", destination);
                sqlCmd.Parameters.AddWithValue("@id", id);

                stationConnection.Open();

                using (var reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sAddedDate = reader.GetDateTime("addedDate");
                        sPlace = destination;
                    }
                    addedDate.Text = sAddedDate.ToString();
                    destinationName.Text = sPlace;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                stationConnection.Close();
            }
        }

        private void ShowAccountForm(object sender, EventArgs e)
        {
            this.Hide();
            formControl.MyAccountFormular(email);
            this.Dispose();
        }
    }
}
