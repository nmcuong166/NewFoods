using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; }
        public string UserName { get; }
        public string PasswordHash { get; }

        public User(string email, string userName, long id = 0, string passwordHash = null)
        {
            this.Id = id;
            this.Email = email;
            this.UserName = userName;
            this.PasswordHash = passwordHash;
        }
    }
}
