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
    public partial class Trips : Form
    {
        private string email;
        private string sql, searchedValue;
        private bool searched;

        private MySqlConnection tripsConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_trips");
        FormControl form = new FormControl();


       private string pickedStation;
        private int pickedFare,pickedStationCount;

        private string callendar;

       
        public Trips(string email)
        {
            InitializeComponent();
            this.email = email;
            timer.Start();
            CurrentDate();
           
        }

        private void CurrentDate()
        {
            dateLabel.Text = DateTime.Now.ToString();
        }

        private void PassengersButton(object sender, EventArgs e)
        {
            this.Hide();
            form.PassengersFormular(email);
            this.Dispose();
        }

        private void BussesButton(object sender, EventArgs e)
        {
            this.Hide();
            form.BussesFormular(email);
            this.Dispose();
        }

        private void StationButton(object sender, EventArgs e)
        {
            this.Hide();
            form.StationFormular(email);
            this.Dispose();
        }

        private void DriversButton(object sender, EventArgs e)
        {
            this.Hide();
            form.DriversFormular(email);
            this.Dispose();
        }

        private void MyAccountButton(object sender, EventArgs e)
        {
            this.Hide();
            form.MyAccountFormular(email);
            this.Dispose();
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            CurrentDate();
        }

        private void ShowCreateForm(object sender, EventArgs e)
        {
            TripMenuFrom trimMenuForm = new TripMenuFrom(email);
            trimMenuForm.ShowDialog();
        }

        private void AppLoad(object sender, EventArgs e)
        {
            searched = false;
            searchedValue = String.Empty;
            sql = "SELECT * FROM trip WHERE profileID = @id";
            ShowTable(sql);
        }

        private void ShowTable(string select)
        {
            int id = GetId(email);
            MySqlCommand cmd = new MySqlCommand(select, tripsConnection);
            cmd.Parameters.AddWithValue("@id", id);
            if (searched)
            {
                cmd.Parameters.AddWithValue("@searchedValue", "%" + searchedValue + "%");
            }
            try
            {
                tripsConnection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Destination", typeof(string));
                    dataTable.Columns.Add("Status", typeof(string)); // Changed data type to string
                    dataTable.Columns.Add("Date", typeof(DateTime)); // Added Date column
                    dataTable.Columns.Add("Fare", typeof(int)); // Changed data type to int
                    dataTable.Columns.Add("Booking", typeof(int)); // Changed data type to int
                    dataTable.Columns.Add("Amount", typeof(int)); // Changed data type to int

                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Destination"] = reader.GetString(reader.GetOrdinal("name"));
                        row["Status"] = reader.GetString(reader.GetOrdinal("status")); // Changed data type to string
                        row["Date"] = reader.GetDateTime(reader.GetOrdinal("date"));
                        row["Fare"] = reader.GetInt32(reader.GetOrdinal("fare")); // Changed data type to int
                        row["Booking"] = reader.GetInt32(reader.GetOrdinal("booking")); // Changed data type to int
                        row["Amount"] = reader.GetInt32(reader.GetOrdinal("amount")); // Changed data type to int

                        dataTable.Rows.Add(row);
                    }
                    table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 48, 96);
                    table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    table.EnableHeadersVisualStyles = false;

                    table.DataSource = dataTable;
                    table.ClearSelection();
                    table.CellClick += TripInfo;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tripsConnection.Close();
            }
        }

        private void TripInfo(object sender, DataGridViewCellEventArgs e)
        {
           string name = table.Rows[e.RowIndex].Cells["Destination"].Value.ToString();
            int id = GetId(email);
           string sql = "SELECT * FROM trip WHERE name = @name AND profileID = @id";

           MySqlCommand sqlCommand = new MySqlCommand(sql, tripsConnection);

            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@id", id);

            try
            {
                tripsConnection.Open();
              
                using(var reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string destination = reader.GetString("name");
                        int fare = reader.GetInt32("fare");
                        int count = reader.GetInt32("booking");
                        callendar = reader.GetString("date");

                        pickedStation = destination;
                        pickedStationCount = count;
                        pickedFare = fare;
                    }
                   
                    
                    
                }
            }

            catch
            {

            }

            finally
            {

            }







        }

        private void SearchedByBtn(object sender, EventArgs e)
        {
            searchedValue = searchedArea.Text;
            if(searchedValue.Length > 0)
            {
                searched = true;
                sql = "SELECT * FROM trip WHERE profileID = @id AND name LIKE @searchedValue";
                ShowTable(sql);
            }
        }

        private void SearchedByEnter(object sender, KeyEventArgs e)
        {
            searchedValue = searchedArea.Text;
            if (searchedValue.Length > 0  && e.KeyCode == Keys.Enter)
            {
                searched = true;
                sql = "SELECT * FROM trip WHERE profileID = @id AND name LIKE @searchedValue";
                ShowTable(sql);
            }
        }

        private void ClearOutput(object sender, EventArgs e)
        {
            searched = false;
            sql = "SELECT * FROM trip WHERE profileID = @id";
            ShowTable(sql);

        }

        private void EditTripButton(object sender, EventArgs e)
        {
          if(pickedFare != 0  && pickedStation != String.Empty && pickedStationCount !=0)
            {
                UpdateTripMenuForm form = new UpdateTripMenuForm(pickedStation , pickedFare , pickedStationCount,email ,callendar);
                form.ShowDialog();
            }


            
        }

        private int GetId(string email)
        {
            GetID getID = new GetID();
            return getID.userID(email);
        }
    }
}
