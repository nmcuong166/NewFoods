using NewsFood.Core.Interface.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Entities.BaseEntities
{
    public class Entity : IEntity
    {
        public long Id { get; set; }
    }
}
