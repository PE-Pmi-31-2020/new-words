using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;

namespace BLL
{
    public class Authorization
    {

        public bool TryLogin(String email, String password)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.findUser(email, password);
                if(user.email == "0")
                {
                    return false;
                }
                return true;
            }
        }

        public bool TrySignup(String email, String password)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.findUser(email, password);
                if (user.email != "0")
                {
                    return false;
                }
                dbRepo.createUser(email, password);
                return true;
            }
        }
    }
}