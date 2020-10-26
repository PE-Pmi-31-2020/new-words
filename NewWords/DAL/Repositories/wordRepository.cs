using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Npgsql;

namespace DAL.Repositories
{
    class WordRepository
    {
        private NpgsqlConnection connection;
        public WordRepository(NpgsqlConnection connection)
        {
            this.connection = connection;
        }

        public void insertWord(Word word)
        {
            connection.Open();
            var cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"INSERT INTO words(word, translation, subject_id) VALUES('{word.word}','{word.translation}','{word.subjectId}')";
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
