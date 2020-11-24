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

        public void addWord(Word word)
        {
            db.words.Add(word);
            db.SaveChanges();
        }
        public List<Word> getWords(int subjectId)
        {
            var words = from w in db.words
                           where w.subject_id == subjectId
                           select w;

            return words.ToList();
        }

        public void deleteWordsOfSubject(int subjectId)
        {
            db.words.RemoveRange(db.words.Where(x => x.subject_id == subjectId));
            db.SaveChanges();
        }

        public void deleteWord(int wordId)
        {
            Word wordToDelete = db.words.Find(wordId);
            db.words.Remove(wordToDelete);
            db.SaveChanges();
        }
    }
}
