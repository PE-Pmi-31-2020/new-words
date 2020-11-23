// <copyright file="User.cs" company="DmytroAndDmytroAndDianaCompany">
// Copyright (c) DmytroAndDmytroAndDianaCompany. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace DAL.Models
{
    public class User
    {
        public User(int id, string email, string password)
        {
            this.Id = id;
            this.Email = email;
            this.Password = password;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
