using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Dto
{
    public class Token
    {
        public long Id { get; set; }
        public string AuthToken { get; }
        public int ExpiresIn { get; }
        public Token(long id, string authToken, int expiresIn)
        {
            Id = id;
            AuthToken = authToken;
            ExpiresIn = expiresIn;
        }
    }
}
