using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking
{
    public class StationControl
    {
        private string connectionString = "datasource=localhost;port=3306;user=root;password=;database=bus_management_stations";


        public bool Add(int profileId, string destination, DateTime date)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string insert = "INSERT INTO station (place,addedDate,profileId) VALUES (@place,@date,@id)";
                MySqlCommand insertCmd = new MySqlCommand(insert, connection);
                insertCmd.Parameters.AddWithValue("@place", destination);
                insertCmd.Parameters.AddWithValue("@date", date);
                insertCmd.Parameters.AddWithValue("@id", profileId);

                try
                {
                    connection.Open();
                    int r = insertCmd.ExecuteNonQuery();
                    if (r > 0) return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }

        }
        public bool Delete(int profileId, string destination)
        {

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string del = "DELETE FROM station WHERE place = @place AND profileId = @id";
                MySqlCommand delCmd = new MySqlCommand(@del, connection);
                delCmd.Parameters.AddWithValue("@place", destination);
                delCmd.Parameters.AddWithValue("@id", profileId);

                try
                {
                    connection.Open();
                    int r = delCmd.ExecuteNonQuery();
                    if (r > 0) return true;
                    else return false;
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }


        }
        public bool Edit(int profileID, string currentName, string oldName, DateTime date)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string edit = "UPDATE station SET place = @place,addedDate = @date WHERE place = @old AND profileID = @id";
                MySqlCommand editCmd = new MySqlCommand(edit, connection);
                editCmd.Parameters.AddWithValue("@place", currentName);
                editCmd.Parameters.AddWithValue("@date", date);
                editCmd.Parameters.AddWithValue("@old", oldName);
                editCmd.Parameters.AddWithValue("@id", profileID);

                try
                {
                    connection.Open();

                    int r = editCmd.ExecuteNonQuery();
                    if (r > 0) return true;
                    else return false;
                }
                catch
                {
                    return false; ;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }

  
}