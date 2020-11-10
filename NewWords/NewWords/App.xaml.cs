using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DAL;
using DAL.Models;

namespace NewWords
{

    public partial class App : Application
    {
        App()
        {
            createConnection();
        }
        private void createConnection()
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                // dbRepo.insertTestData(10);
            }
        }
    }
}
