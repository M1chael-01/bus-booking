using MySql.Data.MySqlClient;
using System;

public enum LoginStatus
{
    Success,
    IncorrectPassword,
    UserNotFound,
    Error
}

public class UserSetting
{
    private string connectionString = "datasource=localhost;port=3306;user=root;password=;database=bus_management_users";

    public LoginStatus Login(string email, string password)
    {
        string selectProfile = "SELECT email, password FROM user WHERE email = @Email";

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            MySqlCommand selectProfileCmd = new MySqlCommand(selectProfile, connection);
            selectProfileCmd.Parameters.AddWithValue("@Email", email);

            try
            {
                connection.Open();
                using (MySqlDataReader reader = selectProfileCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader.GetString("password");
                       if(storedPassword == password)
                        {
                            return LoginStatus.Success;
                        }
                        else
                        {
                            return LoginStatus.IncorrectPassword;
                        }
                    }
                    else
                    {
                        return LoginStatus.UserNotFound;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error for debugging purposes
                Console.WriteLine("Error: " + ex.Message);
                return LoginStatus.Error;
            }
        }
    }
}
