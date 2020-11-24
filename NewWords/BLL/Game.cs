using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BLL
{
    public class Game
    {
        private int sessionId;
        public Game(int sessionId)
        {
            this.sessionId = sessionId;
        }
        public List<Word> startGame()
        {
            using (DataBase db = new DataBase())
            {
                DatabaseRepository dbRepo = new DatabaseRepository(db);
                List<Word> words = dbRepo.getAllWords(sessionId);
                return words;
            }
        }
    }
}
