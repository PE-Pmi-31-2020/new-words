using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Npgsql;


namespace DAL.Repositories
{
    class SubjectRepository
    {
        private DataBase db;
        public SubjectRepository(DataBase db)
        {
            this.db = db;
        }

        public List<Subject> getSubjects()
        {
            var subjects = from s in db.subjects
                        select s;

            return subjects.ToList();
        }

        public void insertSubject(Subject subject)
        {
            db.subjects.Add(subject);
            db.SaveChanges();
        }
    }
}
