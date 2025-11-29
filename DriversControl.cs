using MySql.Data.MySqlClient;
using System;

namespace BusBooking
{
    public class DriversControl
    {
        private string connectionString = "datasource=localhost;port=3306;user=root;password=;database=bus_management_drivers";

        public bool Add(int companyID, string name, string email, string phone, string licence)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO driver (companyID, name, email, phone, licence) VALUES (@companyID, @name, @email, @phone, @licence)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

                // Add parameters to prevent SQL injection
                insertCmd.Parameters.AddWithValue("@companyID", companyID);
                insertCmd.Parameters.AddWithValue("@name", name);
                insertCmd.Parameters.AddWithValue("@email", email);
                insertCmd.Parameters.AddWithValue("@phone", phone);
                insertCmd.Parameters.AddWithValue("@licence", licence);

                try
                {
                    connection.Open();
                    int row = insertCmd.ExecuteNonQuery();
                    if (row > 0) return true;
                    else return false;
                }
                catch (MySqlException ex)
                {
                    // Handle any MySQL exceptions
                    Console.WriteLine("Error: " + ex.Message);
                    return false;

                }
                finally
                {
                    connection.Close();
                }
            }

        }
        public bool Delete(int id, string currentName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string del = "DELETE FROM driver WHERE companyID = @id AND name = @current";
                MySqlCommand delCmd = new MySqlCommand(del, connection);
                delCmd.Parameters.AddWithValue("@id", id); ;
                delCmd.Parameters.AddWithValue("@current", currentName);

                try
                {
                    connection.Open();
                    int row = delCmd.ExecuteNonQuery();
                    if (row > 0) return true;
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
        public string Update(int profileId, string name, string currentName, string email, string phone, string licence)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {


                string query = "UPDATE driver SET name = @name, email = @email, phone = @phone, licence = @licence WHERE companyID = @profileId AND name = @current";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@licence", licence);
                command.Parameters.AddWithValue("@profileId", profileId);
                command.Parameters.AddWithValue("@current", currentName);


                try
                {
                    connection.Open();
                    int row = command.ExecuteNonQuery();
                    if (row > 0) return "yes";
                    else return "no"; ;
                }
                catch(Exception ex)
                {
                    return ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}