using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Dto
{
    public class LoginRespone : BaseRespone
    {
        public Token Token { get; }
        
        public LoginRespone(IEnumerable<Error> errors,Token token, bool success = false) : base(success, errors)
        {
            Token = token;
        }

        public LoginRespone(Token token,bool success) : base(success)
        {
            Token = token;
        }

    }
}
