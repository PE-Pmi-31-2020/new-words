using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;

namespace DAL
{
    public class Db
    {
        private NpgsqlConnection createConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return new NpgsqlConnection(connectionString);
        }

        public void getAllUsers()
        {
            var connection = createConnection();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users";
            cmd.ExecuteReader();
            connection.Close();
        }
        public void insertTestData()
        {
            string[] testNames = {"Pete", "John", "Antony", "Dmytro", "Diana", "Jack", "Kate", "Walt", "Michael", "Sawyer", "Ben"}
            var connection = createConnection();
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.CommandText = "INSERT INTO users(email,password) VALUES('kappa@gmail.com','123123123')";

        }
    }
}
