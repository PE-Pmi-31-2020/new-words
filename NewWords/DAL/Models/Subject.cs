// <copyright file="Subject.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DAL.Models
{
    public class Subject
    {
        public Subject(int id, string name, int userId)
        {
            this.Id = id;
            this.Name = name;
            this.UserId = userId;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }
    }
}
