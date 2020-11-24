using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAL.Models;
using DAL.Repositories;
using DAL.Utils;

namespace DAL
{
    public class DatabaseRepository
    {
        DataBase db;
        public DatabaseRepository(DataBase db)
        {
            this.db = db;
        }

        public List<User> getAllUsers()
        {
            UserRepository userRepository = new UserRepository(db);
            List<User> users = userRepository.getUsers();
            return users;
        }
        public List<Subject> getAllSubjectsForUser(int sessionId)
        {
            SubjectRepository subjectRepository = new SubjectRepository(db);
            List<Subject> subjects = subjectRepository.getSubjects(sessionId);
            return subjects;
        }
        public List<Word> getAllWordsForSubject(int subjectId)
        {
            WordRepository wordRepository = new WordRepository(db);
            List<Word> words = wordRepository.getWords(subjectId);
            return words;
        }

        public User authenticateUser(string username, string password)
        {
            UserRepository userRepository = new UserRepository(db);
            User user = userRepository.getUser(username, password);
            return user;
        }

        public User findUser(string username)
        {
            UserRepository userRepository = new UserRepository(db);
            User user = userRepository.findUserByUsername(username);
            return user;
        }

        public void createUser(string username, string password)
        {
            UserRepository userRepository = new UserRepository(db);
            User user = new User(username, password);
            userRepository.createUser(user);
        }

        public void addWord(string word, string translation, int subjectId)
        {
            WordRepository wordRepository = new WordRepository(db);
            Word wordToAdd = new Word(word, translation, subjectId);
            wordRepository.addWord(wordToAdd);
        }

        public void addSubject(string subjectName, int sessionId)
        {
            SubjectRepository subjectRepository = new SubjectRepository(db);
            Subject subject = new Subject(subjectName, sessionId);
            subjectRepository.addSubject(subject);
        }

        public void insertTestData(int numberOfInsertions)
        {
            UserRepository userRepository = new UserRepository(db);
            SubjectRepository subjectRepository = new SubjectRepository(db);
            WordRepository wordRepository = new WordRepository(db);

            Random random = new Random();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                User randomUser = new User(RandomDataGenerator.generateUsername(), RandomDataGenerator.generatePassword());
                userRepository.createUser(randomUser);
            }

            List<User> users = userRepository.getUsers();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                Subject randomSubject = new Subject(RandomDataGenerator.generateSubjectName(), users[random.Next(users.Count)].id);
                subjectRepository.addSubject(randomSubject);
            }
            List<Subject> subjects = subjectRepository.getAllSubjects();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                KeyValuePair<string, string> word = RandomDataGenerator.generateWord();
                Word randomWord = new Word( word.Key, word.Value, subjects[random.Next(subjects.Count)].id);
                wordRepository.addWord(randomWord);
            }
        }
    }
}
