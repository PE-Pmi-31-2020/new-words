// <copyright file="userRepository.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL.Models;

    public class UserRepository
    {
        private readonly DataBase db;

        public UserRepository(DataBase db)
        {
            this.db = db;
        }

        public List<User> GetUsers()
        {
            var users = from u in this.db.users
                        select u;
            return users.ToList();
        }

        public void InsertUser(User user)
        {
            this.db.users.Add(user);
            this.db.SaveChanges();
        }
    }
}
