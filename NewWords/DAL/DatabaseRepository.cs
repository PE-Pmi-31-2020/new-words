// <copyright file="DatabaseRepository.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DAL
{
    using System;
    using System.Collections.Generic;
    using DAL.Models;
    using DAL.Repositories;
    using DAL.Utils;

    public class DatabaseRepository
    {
        private readonly DataBase db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseRepository"/> class.
        /// </summary>
        /// <param name="db">instance of DataBase object.</param>
        public DatabaseRepository(DataBase db) => this.db = db;

        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>List of users</returns>
        public List<User> GetAllUsers()
        {
            UserRepository userRepository = new UserRepository(this.db);
            return userRepository.GetUsers();
        }

        /// <summary>
        /// Inserts test data to a newly created database.
        /// <param name="numberOfInsertions">number of users, subjects and words to insert</param>
        /// </summary>
        public void InsertTestData(int numberOfInsertions)
        {
            UserRepository userRepository = new UserRepository(this.db);
            SubjectRepository subjectRepository = new SubjectRepository(this.db);
            WordRepository wordRepository = new WordRepository(this.db);

            Random random = new Random();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                User randomUser = new User(0, RandomDataGenerator.GenerateUsername(), RandomDataGenerator.GeneratePassword());
                userRepository.InsertUser(randomUser);
            }

            List<User> users = userRepository.GetUsers();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                Subject randomSubject = new Subject(0, RandomDataGenerator.GenerateSubjectName(), users[random.Next(users.Count)].Id);
                subjectRepository.InsertSubject(randomSubject);
            }
            List<Subject> subjects = subjectRepository.GetSubjects();

            for (int i = 0; i < numberOfInsertions; i++)
            {
                KeyValuePair<string, string> word = RandomDataGenerator.GenerateWord();
                Word randomWord = new Word(0, word.Key, word.Value, subjects[random.Next(subjects.Count)].Id);
                wordRepository.InsertWord(randomWord);
            }
        }
    }
}
