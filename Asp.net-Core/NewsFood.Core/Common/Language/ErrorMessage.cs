using NewsFood.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Common.Language
{
    public static class ErrorMessage
    {
        private const string  ERROR_INVALID_PASSWORD = "Password incorrect";
        private const string ERROR_INVALID_PASSWORD_CODE = "PASSWORDINCORRECT";

        public static Error GetErrorInvaildMessage()
        {
            return new Error { Code = ERROR_INVALID_PASSWORD_CODE, Description = ERROR_INVALID_PASSWORD };
        }
    }
}
