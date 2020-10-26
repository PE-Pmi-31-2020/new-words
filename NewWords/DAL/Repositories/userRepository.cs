using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Npgsql;


namespace DAL.Repositories
{
    class UserRepository
    {
        private NpgsqlConnection connection;
        public UserRepository(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public List<User> getUsers()
        {
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM users";
            List<User> users = new List<User>();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User(Convert.ToInt32(reader["id"].ToString()),
                                                   reader["email"].ToString(), 
                                                   reader["password"].ToString())
                                  );
            }
            connection.Close();
            return users;
        }

        public void insertUser(User user)
        {
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"INSERT INTO users(email, password) VALUES('{user.email}','{user.password}')";
            cmd.ExecuteNonQuery();
            this.connection.Close();
        }

    }
}
