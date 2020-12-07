using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace BLL
{
    public class Authorization
    {
        private ILogger logger = new FileLogger("./logs.log");

        public bool TryLogin(string email, string password)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.authenticateUser(email, password);
                if(user.email == "-1")
                {
                    this.logger.Error("Could not authenticate with credentials " + email.Trim() + ", " + password.Trim());
                    return false;
                }
                return true;
            }
        }

        public bool TrySignup(string email, string password)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.authenticateUser(email, password);
                if (user.email != "-1")
                {
                    this.logger.Error("Could not sign up with credentials " + email.Trim() + ", " + password.Trim() + ". The user already exists.");
                    return false;
                }
                dbRepo.createUser(email, password);
                return true;
            }
        }
    }
}