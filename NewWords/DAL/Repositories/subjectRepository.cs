// <copyright file="subjectRepository.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DAL.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using DAL.Models;

    public class SubjectRepository
    {
        private readonly DataBase db;

        public SubjectRepository(DataBase db)
        {
            this.db = db;
        }

        public List<Subject> GetSubjects()
        {
            var subjects = from s in this.db.subjects
                        select s;

            return subjects.ToList();
        }

        public void InsertSubject(Subject subject)
        {
            this.db.subjects.Add(subject);
            this.db.SaveChanges();
        }
    }
}
