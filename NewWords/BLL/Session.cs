using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL
{
    public class Session
    {

        public int getSessionId(string username)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.findUser(username);
                if (user.email == "0")
                {
                    return -1;
                }
                return user.id;
            }
        }
    }
}
