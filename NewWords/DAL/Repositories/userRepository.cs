﻿using System;
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
        private DataBase db;
        public UserRepository(DataBase db)
        {
            this.db = db;
        }

        public List<User> getUsers()
        {
            var users = from u in db.users
                        select u;
            return users.ToList();
        }

        public User getUser(string username, string password)
        {
            var user = (from u in db.users
                       where u.email == username && u.password == password.ToString()
                       select u).FirstOrDefault();

            if (user != null) return user;
            return new User("-1", "-1");
        }

        public User findUserByUsername(string username)
        {
            var user = (from u in db.users
                        where u.email == username
                        select u).FirstOrDefault();

            if (user != null) return (User)user;
            return new User("-1", "-1");
        }

        public void createUser(User user)
        {
            db.users.Add(user);
            db.SaveChanges();
        }

    }
}
