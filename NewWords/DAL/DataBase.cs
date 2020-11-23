// <copyright file="DataBase.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DAL
{
    using System.Configuration;
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;

    public class DataBase : DbContext
    {
        public DbSet<User> users { get; set; }

        public DbSet<Subject> subjects { get; set; }

        public DbSet<Word> words { get; set; }

        public DataBase()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}
