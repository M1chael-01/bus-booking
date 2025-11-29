using MySql.Data.MySqlClient;
using System;

namespace BusBooking
{
    public class PassengerControl
    {

        private string connectionString = "datasource=localhost;port=3306;user=root;password=;database=bus_management_passengers";


        public void Add(int profileID, string name, string phone, string destination, string busNum, int seat)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string add = "INSERT INTO passenger (profileID, name, phone, destination, bus_number, seat) " +
                             "VALUES (@profileID, @name, @phone, @destination, @busNum, @seat)";

                using (MySqlCommand command = new MySqlCommand(add, connection))
                {
                    command.Parameters.AddWithValue("@profileID", profileID);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@destination", destination);
                    command.Parameters.AddWithValue("@busNum", busNum);
                    command.Parameters.AddWithValue("@seat", seat);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log, show error message)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }


        public string Edit(int profileID, string newName, string oldName, string phone, string destination, string busNum, int seat)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string upd = "UPDATE passenger SET name = @newName, phone = @phone, destination = @destination, bus_number = @busNum, seat = @seat WHERE profileID = @profileID AND name = @oldName";

                MySqlCommand updCMD = new MySqlCommand(upd, connection);
                updCMD.Parameters.AddWithValue("@newName", newName);
                updCMD.Parameters.AddWithValue("@phone", phone);
                updCMD.Parameters.AddWithValue("@destination", destination);
                updCMD.Parameters.AddWithValue("@busNum", busNum);
                updCMD.Parameters.AddWithValue("@seat", seat);
                updCMD.Parameters.AddWithValue("@profileID", profileID);
                updCMD.Parameters.AddWithValue("@oldName", oldName);

                try
                {
                    connection.Open();
                    updCMD.ExecuteNonQuery();
                    return "done";
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log, show error message)
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return ex.Message;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public void Delete(int id, string name)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string del = "DELETE FROM passenger WHERE profileID = @id AND name = @name";

                using (MySqlCommand delCMD = new MySqlCommand(del, connection))
                {
                    delCMD.Parameters.AddWithValue("@id", id);
                    delCMD.Parameters.AddWithValue("@name", name);

                    try
                    {
                        connection.Open();
                        delCMD.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., log, show error message)
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }

    }
}
