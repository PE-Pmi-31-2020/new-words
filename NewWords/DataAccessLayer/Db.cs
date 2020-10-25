using System;
using Npgsql;
using System.Configuration;


namespace DataAccessLayer
{
    public class Db
    {
        private NpgsqlConnection createConnection()
        {
            string connectionString = ConfigurationManager.AppSettings["DefaultConnection"];
            return new NpgsqlConnection(connectionString);
        }

        public void getData()
        {
            var connection = createConnection();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users";
            cmd.ExecuteScalar();

            Console.WriteLine("Hello World!");
        }
    }
}
