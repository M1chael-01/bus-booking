using MySql.Data.MySqlClient;
using System;

namespace BusBooking
{
    public class BusControl
    {
        private string connectionString = "datasource=localhost;port=3306;user=root;password=;database=bus_management_busses";
        public bool Add(int companyId, string name, int capacity, string fuel, string plate)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO bus (companyID, name, capacity, fuel, plate) VALUES (@companyID, @name, @capacity, @fuel, @plate)";
                MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection);

                // Add parameters to prevent SQL injection
                insertCmd.Parameters.AddWithValue("@companyID", companyId);
                insertCmd.Parameters.AddWithValue("@name", name);
                insertCmd.Parameters.AddWithValue("@capacity", capacity);
                insertCmd.Parameters.AddWithValue("@fuel", fuel);
                insertCmd.Parameters.AddWithValue("@plate", plate);

                try
                {
                    connection.Open();
                    int rowsAffected = insertCmd.ExecuteNonQuery(); // Execute the INSERT command
                    if (rowsAffected > 0) return true;
                    else return false;
                }
                catch 
                {
                    // Handle any MySQL exceptions
                    return false;
                }
                finally
                {
                    connection.Close();
                }


            }

            
        }
        public void Delete(string bus,int profile)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string del = "DELETE FROM bus WHERE name = @name AND companyID = @id";

                MySqlCommand delCMD = new MySqlCommand(del, connection);
                delCMD.Parameters.AddWithValue("@name", bus);
                delCMD.Parameters.AddWithValue("@id", profile);
               
                try
                {
                    connection.Open();
                   delCMD.ExecuteNonQuery();
                    
                }
                catch
                {
                   
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public string Edit(int companyId, string name, int capacity, string fuel, string plate, string oldName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string upd = "UPDATE bus SET name = @bus, capacity = @capacity, fuel = @fuel, plate = @plate WHERE companyID = @companyId AND name = @old";

                using (MySqlCommand command = new MySqlCommand(upd, connection))
                {
                    command.Parameters.AddWithValue("@bus", name);
                    command.Parameters.AddWithValue("@capacity", capacity);
                    command.Parameters.AddWithValue("@fuel", fuel);
                    command.Parameters.AddWithValue("@plate", plate);
                    command.Parameters.AddWithValue("@companyId", companyId);
                    command.Parameters.AddWithValue("@old", oldName);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return "done";
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                    finally
                    {
                        // Ensure the connection is always closed, even if an exception occurs
                        connection.Close();
                    }
                }
            }
        }


    }
}
