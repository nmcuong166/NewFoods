using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set;}

        public User(
            string email, 
            string userName, 
            long id = 0,            
            string passwordHash = null)
        {
            this.Id = id;
            this.Email = email;
            this.UserName = userName;
            this.PasswordHash = passwordHash;
        }

        public User() { }
    }
}
