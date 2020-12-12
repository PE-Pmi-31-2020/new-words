using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace BLL
{
    public class Authorization : IAuthorization
    {
        private ILogger logger = new FileLogger("./logs.log");

        public void TryLogin(string email, string password)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.authenticateUser(email, password);
                if (user.email == "-1")
                {
                    this.logger.Error("Could not authenticate with credentials " + email.Trim() + ", " + password.Trim());
                    throw new InvalidDataCustomerException("INVALID DATA!");
                }
            }
        }

        public void TrySignup(string email, string password)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.authenticateUser(email, password);
                if (user.email != "-1")
                {
                    this.logger.Error("Could not sign up with credentials " + email.Trim() + ", " + password.Trim() + ". The user already exists.");
                    throw new InvalidDataCustomerException("INVALID DATA!");
                }
                dbRepo.createUser(email, password);
            }
        }
    }
}