using GameShop.Views.SingleViews;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace GameShop.App.Components
{
    /// <summary>
    /// Provides a set of static methods for validating user input, passwords, and account information.
    /// </summary>
    /// <remarks>The <see cref="ValidationManager"/> class includes methods for validating user input,
    /// ensuring password compliance with specific requirements, checking password equality, and verifying the
    /// uniqueness of a user account. It is designed to support common validation scenarios in applications.</remarks>
    static class ValidationManager
    {
        static private string _connString = "server=localhost;uid=root; database=gameshop"; 
        static public bool InputValidation(string nickname, string password, string confirmedPassword)
        {
            if (nickname.Length == 0 || password.Length == 0 || confirmedPassword.Length == 0) return false;
            else return true;
        }
        static public bool PasswordEqualityValidation(string password, string confirmedPassword)
        {
            return password == confirmedPassword;
        }
        static public bool PasswordRequirementsValidation(string password)
        {
            bool eightLetters = password.Length >= 8;
            bool bigLetter = password.Any(char.IsUpper);
            bool number = Regex.IsMatch(password, @"\d");
            bool specialCharacter = Regex.IsMatch(password, @"[^\\p{L}\\p{N}\\s]");
            if (eightLetters && bigLetter && number) return true;
            else return false;
        }
        static public bool AccountValidation(string nickname)
        {
            try
            {
                using (MySqlConnection conn = new(_connString))
                {
                    conn.Open();
                    MySqlCommand command = new("SELECT user_id FROM users WHERE user_nickname = @nickname", conn);
                    command.Parameters.AddWithValue("nickname", nickname);
                    int nicknameCounter = Convert.ToInt32(command.ExecuteScalar());
                    conn.Close();
                    return nicknameCounter == 0;
                }
            }
            catch
            {
                Error error = new(ViewType.Error, ["  _____                     ", " | ____|_ __ _ __ ___  _ __ ", " |  _| | '__| '__/ _ \\| '__|", " | |___| |  | | | (_) | |   ", " |_____|_|  |_|  \\___/|_|   ", "                            "], ErrorType.FailedConnection);
                error.InitView();
                Environment.Exit(0);
                throw new Exception("Failed connection!");
            }
        }
    }
}
