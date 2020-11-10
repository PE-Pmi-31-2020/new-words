using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Word
    {
        public Word(int id, string word, string translation, int subject_id)
        {
            this.id = id;
            this.word = word;
            this.translation = translation;
            this.subject_id = subject_id;
        }
        public int id { get; set; }
        public string word { get; set; }
        public string translation { get; set; }
        public int subject_id { get; set; }
    }
}
