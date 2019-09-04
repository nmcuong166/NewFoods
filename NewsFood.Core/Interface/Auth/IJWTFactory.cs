using NewsFood.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Auth
{
    public interface IJWTFactory
    {
        Task<Token> GenerateToken(long id, string userName);
    }
}
