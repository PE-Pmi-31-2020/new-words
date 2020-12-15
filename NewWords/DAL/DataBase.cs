using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using System.Configuration;

namespace DAL
{
    public class DataBase : DbContext, IDataBase
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
