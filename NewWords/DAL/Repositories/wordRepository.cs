using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Npgsql;

namespace DAL.Repositories
{
    class WordRepository
    {
        private DataBase db;
        public WordRepository(DataBase db)
        {
            this.db = db;
        }

        public void insertWord(Word word)
        {
            db.words.Add(word);
            db.SaveChanges();
        }
    }
}
