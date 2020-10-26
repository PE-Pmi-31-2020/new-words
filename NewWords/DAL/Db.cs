using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;
using DAL.Models;
using DAL.Repositories;
using DAL.Utils;

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
            UserRepository userRepository = new UserRepository(connection);
            List<User> users = userRepository.getUsers();
        }

        public void insertTestData(int numberOfInsertions)
        {
            var connection = createConnection();
            UserRepository userRepository = new UserRepository(connection);
            SubjectRepository subjectRepository = new SubjectRepository(connection);
            WordRepository wordRepository = new WordRepository(connection);
            Random random = new Random();

            for (int i = 0; i < numberOfInsertions;i++)
            {
                User randomUser = new User(0, RandomDataGenerator.generateUsername(), RandomDataGenerator.generatePassword());
                userRepository.insertUser(randomUser);
            }

            List<User> users = userRepository.getUsers();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                Subject randomSubject = new Subject(0, RandomDataGenerator.generateSubjectName(), users[random.Next(users.Count)].id);
                subjectRepository.insertSubject(randomSubject);
            }
            List<Subject> subjects = subjectRepository.getSubjects();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                KeyValuePair<string, string> word = RandomDataGenerator.generateWord();
                Word randomWord = new Word(0, word.Key, word.Value, subjects[random.Next(subjects.Count)].id);
                wordRepository.insertWord(randomWord);
            }
        }
    }
}
