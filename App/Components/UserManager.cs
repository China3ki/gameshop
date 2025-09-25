using GameShop.Views.SingleViews;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace GameShop.App.Components
{
    static class UserManager
    {
        static public string UserNickname { get; set; } = "";
        static public void AddNewUser(string nickname, string password)
        {
            try
            {
                using (MySqlConnection conn = new("server=localhost;uid=root; database=gameshop"))
                {
                    conn.Open();
                    MySqlCommand command = new("INSERT INTO users (user_type, user_nickname, user_password) VALUES (1, @nickname, @password)", conn);
                    command.Parameters.AddWithValue("@nickname", nickname.Trim());
                    command.Parameters.AddWithValue("@password", password);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            } catch
            {
                Error error = new(ViewType.Error, ["  _____                     ", " | ____|_ __ _ __ ___  _ __ ", " |  _| | '__| '__/ _ \\| '__|", " | |___| |  | | | (_) | |   ", " |_____|_|  |_|  \\___/|_|   ", "                            "], ErrorType.FailedConnection);
                error.InitView();
                Environment.Exit(0);
                throw new Exception("Failed connection!");
            }
        }
    }
}
