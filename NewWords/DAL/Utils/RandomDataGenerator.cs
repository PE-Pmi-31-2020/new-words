using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils
{
    public static class RandomDataGenerator
    {
        public static string generateUsername()
        {
            Random random = new Random();
            string[] names = { "Pete", "John", "Antony", "Dmytro", "Diana", "Jack", "Kate", "Walt", "Michael", "Sawyer", "Ben" };
            string[] mails = { "@gmail.com", "@ukr.net", "@lambda.direct" };
            return $"{names[random.Next(names.Length)]}{mails[random.Next(mails.Length)]}";
        }
        public static string generatePassword()
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, random.Next(5, 16))
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string generateSubjectName()
        {
            Random random = new Random();
            string[] subjectNames = { "Sport", "Food", "Tanks", "Cars", "Clothes", "Medicine", "Programming", "University", "Pets", "Love", "Disasters", "Countries" };
            return subjectNames[random.Next(subjectNames.Length)];
        }

        public static KeyValuePair<string, string> generateWord()
        {
            Random random = new Random();
            Dictionary<string, string> words = new Dictionary<string, string>
            {
                {"Table", "Стіл"},
                {"Candle", "Свічка"},
                {"Eagle", "Орел"},
                {"Chair", "Стілець"},
                {"Father", "Тато"},
                {"Mother", "Мама"},
                {"Sister", "Сестра"},
                {"Son", "Син"},
                {"Cake", "Торт"},
                {"Football", "Футбол"},
                {"T-shirt", "Футболка"},
                {"Button", "Кнопка"},
                {"Cat", "Кіт"}
            };
            List<string> keyList = new List<string>(words.Keys);
            string randomKey = keyList[random.Next(keyList.Count)];
            return new KeyValuePair<string, string>(randomKey, words[randomKey]);
        }
    }
}
