using MySql.Data.MySqlClient;

namespace BusBooking
{
    public class GetID
    {
        private MySqlConnection profileConnection = new MySqlConnection("datasource=localhost;port=3306;user=root;password=;database=bus_management_users");
        public int userID(string email)
        {
            string select = "SELECT id FROM user WHERE email = @email";
            MySqlCommand selectCmd = new MySqlCommand(select,profileConnection);
            selectCmd.Parameters.AddWithValue("@email", email);

            try
            {
                profileConnection.Open();
                MySqlDataReader reader = selectCmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("id");
                    return id;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
            finally
            {
                profileConnection.Close();
            }
        }
    }
}
