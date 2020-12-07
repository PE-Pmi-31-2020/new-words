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
        private ILogger logger = new FileLogger("./logs.log");

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
                logger.Info("Successfully started the game. Number of words to go: " + words.Count.ToString());
                return words;
            }
        }
    }
}
