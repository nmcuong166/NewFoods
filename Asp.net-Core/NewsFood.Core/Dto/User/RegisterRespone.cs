using NewsFood.Core.Interface.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Dto.User
{
    public class RegisterRespone : BaseRespone, IEntity
    {
        public long Id { get; set; }
        public RegisterRespone(long id, bool sucesss = false, IEnumerable<Error> errors = null) : base(sucesss, errors)
        {
            this.Id = id;
        }
    }
}
