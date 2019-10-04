using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Dto.User
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
