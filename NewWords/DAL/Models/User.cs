using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class User
    {
        public User(int id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
