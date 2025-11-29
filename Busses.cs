using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BusBooking
{
    public partial class Busses : Form
    {
        private string email;
        private bool btn;
        FormControl formControl = new FormControl();
        BusControl busControl = new BusControl();
        private string select;
        private string bName, bFuel, bPlate;
        private int bCapacity;
        private bool isSearched;
        private string searchedValue = null;
        private string currentBusName;
        private MySqlConnection bussesConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_busses");
        public Busses(string email)
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

        private void StationButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.StationFormular(email);
            this.Dispose();
        }

        private void DriversButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.DriversFormular(email);
            this.Dispose();
        }

        private void MyAccountButton(object sender, EventArgs e)
        {
            this.Hide();
            formControl.MyAccountFormular(email);
            this.Dispose();
        }

        private void AppLoad(object sender, EventArgs e)
        {
            isSearched = false;
            btn = true;
            select = "SELECT * FROM bus WHERE companyID = @id";
            ShowTable(select);
        }

        private void SelectTypeFuel(object sender, EventArgs e)
        {
            ComboBox fueldBox = (ComboBox)sender;
            bFuel = fueldBox.Text;
        }

        private void ShowTable(string select)
        {
            int id = GetID(email);
        
            MySqlCommand cmd = new MySqlCommand(select, bussesConnection);
            cmd.Parameters.AddWithValue("@id", id);

            if (isSearched)
            {
                cmd.Parameters.AddWithValue("@searchedValue", "%" + searchedValue + "%");
            }
            try
            {
                bussesConnection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("ID", typeof(int));
                    dataTable.Columns.Add("Name", typeof(string));
                    dataTable.Columns.Add("Capacity", typeof(int));
                    dataTable.Columns.Add("Fuel", typeof(string));
                    dataTable.Columns.Add("Licence Plate", typeof(string));

                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["ID"] = reader.GetInt32(reader.GetOrdinal("busID"));
                        row["Name"] = reader.GetString(reader.GetOrdinal("name"));
                        row["Capacity"] = reader.GetInt32(reader.GetOrdinal("capacity"));
                        row["Fuel"] = reader.GetString(reader.GetOrdinal("fuel"));
                        row["Licence Plate"] = reader.GetString((reader.GetOrdinal("plate")));

                        dataTable.Rows.Add(row);
                    }
                    table.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(24, 48, 96);

                    table.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    table.EnableHeadersVisualStyles = false;

                    table.Columns.Clear();
                    table.DataSource = null;

                    // Update data source and display
                    table.DataSource = dataTable;

                    table.ClearSelection();
                    table.CellClick += ShowBusInfo;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bussesConnection.Close();
            }
        }

        private void ShowBusInfo(object sender, DataGridViewCellEventArgs e)
        {

           
            if (e.ColumnIndex != 4)
            {
                try
                {
                    string busNameRow = table.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                    int id = GetID(email);
                    string selectBy = "SELECT * FROM bus WHERE name = @name AND companyID = @id";
                    MySqlCommand selectbyCMD = new MySqlCommand(selectBy, bussesConnection);
                    selectbyCMD.Parameters.AddWithValue("@name", busNameRow);
                    selectbyCMD.Parameters.AddWithValue("@id", id);
                    try
                    {
                        bussesConnection.Open();
                        using (var reader = selectbyCMD.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                bName = reader.GetString("name");
                                bCapacity = reader.GetInt32("capacity");
                                bPlate = reader.GetString("plate");
                                bFuel = reader.GetString("fuel");
                            }
                            reader.Close();
                            busName.Text = bName;
                            busCapacity.Value = (int)bCapacity;
                            busLicence.Text = bPlate;
                            busFuel.Text = bFuel;
                            currentBusName = bName;
                        }
                    }
                    catch
                    {

                    }
                    finally
                    {
                        bussesConnection.Close();
                    }
                }
                catch
                {

                }
            }
        }

        private int GetID(string email)
        {
            //public class
            GetID getID = new GetID();
            return getID.userID(email);
           
        }

        private void ClearBusses(object sender, EventArgs e)
        {
            ClearOutput();
        }
        private void ClearOutput()
        {
            bName = String.Empty;
            bCapacity = 0;
            bPlate = String.Empty;
            bFuel = String.Empty;
            busName.Text = bName;
            busCapacity.Value = (int)bCapacity;
            busLicence.Text = bPlate;
            busFuel.Text = bFuel;
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            if(busNameInput.Text.Length>0)
            {
                searchedValue = busNameInput.Text;
                isSearched = true;
                select = "SELECT * FROM bus WHERE companyID = @id AND name LIKE @searchedValue";
                ShowTable(select);
            }
        }

        private void SearchByEnter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && busNameInput.Text.Length>0)
            {
                searchedValue = busNameInput.Text;
                isSearched = true;
                select = "SELECT * FROM bus WHERE companyID = @id AND name LIKE @searchedValue";
                ShowTable(select);
            }
        }

        private void ClearInput(object sender, EventArgs e)
        {
            searchedValue = String.Empty;
            busNameInput.Text = searchedValue;
            bussesConnection.Close();
            select = "SELECT * FROM bus WHERE companyID = @id";
            ShowTable(select);
        }

        private void EditBus(object sender, EventArgs e)
        {
            // if it it isnt empty
            int id = GetID(email);
            string oldName = currentBusName;
          
            bName = busName.Text;
            string x =    busControl.Edit(id, bName, (int)busCapacity.Value, bFuel, bPlate,oldName);
            MessageBox.Show(x);
            bussesConnection.Close();
            select = "SELECT * FROM bus WHERE companyID = @id";
            ShowTable(select);

        }

        private void ValueChanged(object sender, EventArgs e)
        {
            bCapacity =(int)busCapacity.Value;
        }

        private void DeleteBus(object sender, EventArgs e)
        {
            busName.Text = bName;

            try
            {
                bussesConnection.Open();
               
                int profileId = GetID(email);
                busControl.Delete(busName.Text, profileId);
                ClearOutput();
                bussesConnection.Close();
                select = "SELECT * FROM bus WHERE companyID = @id";
                ShowTable(select);
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void AddBusses(object sender, EventArgs e)
        {
            // check before
            int companyID = GetID(email);
            bName = busName.Text;
            bCapacity = (int)busCapacity.Value;
            bPlate = busLicence.Text;
            if(busControl.Add(companyID,bName,bCapacity,bFuel,bPlate))
            {
                bussesConnection.Close();
                select = "SELECT * FROM bus WHERE companyID = @id";
                ShowTable(select);

            }
        }
    }
}
