using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace BLL
{
    public class Authorization
    {

        public bool TryLogin(string email, string password)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.authenticateUser(email, password);
                if(user.email == "-1")
                {
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
                    return false;
                }
                dbRepo.createUser(email, password);
                return true;
            }
        }
    }
}