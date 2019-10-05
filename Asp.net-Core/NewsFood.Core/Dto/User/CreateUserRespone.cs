using NewsFood.Core.Interface.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Dto.User
{
    public class CreateUserRespone : BaseRespone, IEntity
    {
        public long Id { get ; set ; }

        public CreateUserRespone(long id, bool success,IEnumerable <Error> errors) : base(success, errors)
        {
            this.Id = id;
        }

        public CreateUserRespone(long id, bool success) : base(success)
        {
            this.Id = id;
        }
    }
}
