// <copyright file="Card.xaml.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace NewWords
{
    using System.Windows;
    using DAL;

    public partial class App : Application
    {
        App()
        {
            this.CreateConnection();
        }

        private void CreateConnection()
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
            }
        }
    }
}
