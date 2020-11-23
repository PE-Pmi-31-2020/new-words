using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
