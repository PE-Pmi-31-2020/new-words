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
using System.IO;

namespace DAL
{
    public class DatabaseRepository
    {
        DataBase db;
        public DatabaseRepository(DataBase db)
        {
            this.db = db;
        }

        public void getAllUsers()
        {
            UserRepository userRepository = new UserRepository(db);
            List<User> users = userRepository.getUsers();
            string writePath = @"C:\Users\Дмитро\Desktop\test.txt";

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                foreach (User user in users)
                {
                    sw.WriteLine(user.email);
                }
            }
        }

        public void insertTestData(int numberOfInsertions)
        {
            UserRepository userRepository = new UserRepository(db);
            SubjectRepository subjectRepository = new SubjectRepository(db);
            WordRepository wordRepository = new WordRepository(db);

            Random random = new Random();

            for (int i = 0; i < numberOfInsertions; i++)
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
