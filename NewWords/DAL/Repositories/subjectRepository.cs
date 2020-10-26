using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Npgsql;


namespace DAL.Repositories
{
    class SubjectRepository
    {
        private NpgsqlConnection connection;
        public SubjectRepository(NpgsqlConnection connection)
        {
            this.connection = connection;
        }
        public List<Subject> getSubjects()
        {
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM subjects";
            List<Subject> subjects = new List<Subject>();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                subjects.Add(new Subject(Convert.ToInt32(reader["id"].ToString()),
                                                   reader["name"].ToString(),
                                                   Convert.ToInt32(reader["user_id"].ToString())
                                  ));
            }
            connection.Close();
            return subjects;
        }

        public void insertSubject(Subject subject)
        {
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"INSERT INTO subjects(name, user_id) VALUES('{subject.name}','{subject.userId}')";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
