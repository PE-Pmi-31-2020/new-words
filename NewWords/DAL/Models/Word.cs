using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Word
    {
        public Word(int id, string word, string translation, int subjectId)
        {
            this.id = id;
            this.word = word;
            this.translation = translation;
            this.subjectId = subjectId;
        }
        public int id { get; set; }
        public string word { get; set; }
        public string translation { get; set; }
        public int subjectId { get; set; }
    }
}
