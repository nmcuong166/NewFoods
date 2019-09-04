using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Dto
{
    public abstract class  BaseRespone
    {
        public bool Success { get; set; }
        public IEnumerable<Error> Errors { get; set; }
        protected BaseRespone(bool success = false, IEnumerable<Error> errors = null)
        {
            Success = success;
            Errors = errors;
        }
    }
}
