﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DAL;

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
            Db database = new Db();
            // database.insertTestData(2);
        }
    }
}