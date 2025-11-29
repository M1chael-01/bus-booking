using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BusBooking
{
    public partial class Drivers : Form
    {
        private string email;
        private bool btn;
        FormControl formControl = new FormControl();
        DriversControl driveControl = new DriversControl(); 

        private string dName, dEmail, dPhone, dLicence;
        private string select;

        private string currentName;

        private bool searched;
        private string searchedValue;

        private MySqlConnection driversConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_drivers");
        public Drivers(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void TripsButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.TripFormular(email);
            this.Dispose();
        }

        private void PassangersButton(object sender, EventArgs e)
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

        private void AppLoad(object sender, EventArgs e)
        {
            btn = true;
            searched = false;
            searchedValue = String.Empty;
            select = "SELECT * FROM driver WHERE companyID = @id";
            ShowTable(select);
        }

        private void ShowTable(string select)
        {
            int id = GetId(email);
            MySqlCommand cmd = new MySqlCommand(select, driversConnection);
            cmd.Parameters.AddWithValue("@id", id);
            if(searched)
            {
                cmd.Parameters.AddWithValue("@searchedValue", "%" + searchedValue + "%");
            }
            try
            {
                driversConnection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Email", typeof(string));
                    dataTable.Columns.Add("Phone", typeof(string));
                    dataTable.Columns.Add("Licence", typeof(string));

                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Name"] = reader.GetString(reader.GetOrdinal("name"));
                        row["Email"] = reader.GetString(reader.GetOrdinal("email"));
                        row["Phone"] = reader.GetString(reader.GetOrdinal("phone"));
                        row["Licence"] = reader.GetString(reader.GetOrdinal("licence"));

                        dataTable.Rows.Add(row);
                    }
                    table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24,48,96);
                
                    table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    table.EnableHeadersVisualStyles = false;

                    table.DataSource = dataTable;

                    table.ClearSelection();
                    table.CellClick += DriverInfo;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                driversConnection.Close();
            }
        }

        private void DriverInfo(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string driver = table.Rows[e.RowIndex].Cells["Name"].Value.ToString();

                string selectDriver = "SELECT * FROM driver WHERE name = @name  AND companyID = @id";
                int id = GetId(email);
                MySqlCommand selectCMD = new MySqlCommand(selectDriver,driversConnection);

                selectCMD.Parameters.AddWithValue("@name", driver);
                selectCMD.Parameters.AddWithValue("@id", id);

                driversConnection.Open();

                using (var reader = selectCMD.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dName = reader.GetString("name");
                        dEmail = reader.GetString("email");
                        dPhone = reader.GetString("phone");
                        dLicence = reader.GetString("licence");
                        currentName = dName;
                    }
                    driverName.Text = dName;
                    driverEmail.Text = dEmail;
                    driverPhone.Text = dPhone;
                    driverLicence.Text = dLicence;
                 
                }
               

                


                }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                driversConnection.Close();
            }
        }

        private void StationButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.StationFormular(email);
            this.Dispose();
        }

        private void EditDriver(object sender, EventArgs e)
        {
            // edit driver
            string currentName = dName;
            int id = GetId(email);
            string msg = (driveControl.Update(id, driverName.Text,currentName,driverEmail.Text,driverPhone.Text,driverLicence.Text));

            MessageBox.Show(msg);
            
                select = "SELECT * FROM driver WHERE companyID = @id";
                ShowTable(select);
            
        }

        private void ClearDriver(object sender, EventArgs e)
        {
            dName = String.Empty;
            dEmail = String.Empty;
            dPhone = String.Empty;
            dLicence = String.Empty;
            //clear driver
            driverName.Text = dName;
            driverEmail.Text = dEmail;
            driverPhone.Text = dPhone;
            driverLicence.Text = dLicence;
        }

        private void DeleteDriver(object sender, EventArgs e)
        {
            // delete driver
            string newName = driverName.Text;

            int id = GetId(email);
            if (driveControl.Delete(id, dName))
            {
              
                select = "SELECT * FROM driver WHERE companyID = @id";
                ShowTable(select);
            }
            
        }

        private void SearchButton(object sender, EventArgs e)
        {
            if(searchedBox.Text.Length>0)
            {
                searched = true;
                searchedValue = searchedBox.Text;
                select = "SELECT * FROM driver WHERE companyID = @id AND name LIKE @searchedValue";
                ShowTable(select);
            }
        }

        private void SearchUserBox(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && searchedBox.Text.Length>0)
            {
                searched = true;
                searchedValue = searchedBox.Text;
                select = "SELECT * FROM driver WHERE companyID = @id AND name LIKE @searchedValue";
                ShowTable(select);
            }
        }

        private void CleanOutput(object sender, EventArgs e)
        {
            searchedValue = String.Empty;
            searchedBox.Text = String.Empty;
            searched = false;

            select = "SELECT * FROM driver WHERE companyID = @id";
            ShowTable(select);
        }

        private void MyAccountButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.MyAccountFormular(email);
            this.Dispose();
        }

        private void AddDriver(object sender, EventArgs e)
        {
            // check before 
            int companyID = GetId(email);
            dName = driverName.Text;
            dEmail = driverEmail.Text;
            dPhone = driverPhone.Text;
            dLicence = driverLicence.Text;
            if (driveControl.Add(companyID, dName, dEmail, dPhone, dLicence))
            {
                driversConnection.Close();
                select = "SELECT * FROM driver WHERE companyID = @id";
                ShowTable(select);
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private int GetId(string email)
        {
            GetID getID = new GetID();
            return getID.userID(email);
        }
    }
}
