namespace DAL.Repositories
{
    using DAL.Models;

    public class WordRepository
    {
        private readonly DataBase db;

        public WordRepository(DataBase db)
        {
            this.db = db;
        }

        public void InsertWord(Word word)
        {
            this.db.words.Add(word);
            this.db.SaveChanges();
        }
    }
}
