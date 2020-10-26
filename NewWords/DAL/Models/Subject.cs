using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class Subject
    {
        public Subject(int id, string name, int userId)
        {
            this.id = id;
            this.name = name;
            this.userId = userId;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int userId { get; set; }
    }
}
