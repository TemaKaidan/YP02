using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using YP021.Models;

namespace YP021.Classes
{
    public class Database
    {
        //private static string connectionString = "server=127.0.0.1;port=3312;database=UP02;user=root;pwd=;";

        //public static Users AuthenticateUser(string username, string password)
        //{
        //    using (var connection = new MySqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT * FROM Users WHERE login = @login AND password = @password";
        //        using (var cmd = new MySqlCommand(query, connection))
        //        {
        //            cmd.Parameters.AddWithValue("@login", username);
        //            cmd.Parameters.AddWithValue("@password", password);
        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    return new Users
        //                    {
        //                        id = reader.GetInt32("id"),
        //                        login = reader.GetString("login"),
        //                        password = reader.GetString("password"),
        //                        role = reader.GetInt32("role")
        //                    };
        //                }
        //            }
        //        }
        //    }
        //    return null;
        //}
    }
}