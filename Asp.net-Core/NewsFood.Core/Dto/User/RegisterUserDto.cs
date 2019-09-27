using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Dto.User
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
