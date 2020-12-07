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
        private ILogger logger = new FileLogger("./logs.log");

        public int getSessionId(string username)
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                User user = dbRepo.findUser(username);
                if (user.email == "0")
                {
                    this.logger.Error("User with username " + username + ". Does not exist.");
                    return -1;
                }
                this.logger.Info("Found user with username " + username);
                return user.id;
            }
        }
    }
}
