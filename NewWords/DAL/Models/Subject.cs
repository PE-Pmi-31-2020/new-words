using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Subject
    {
        public Subject(string name, int user_id)
        {
            this.name = name;
            this.user_id = user_id;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int user_id { get; set; }
    }
}
