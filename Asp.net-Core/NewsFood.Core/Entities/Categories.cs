using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Entities
{
    public class Categories : BaseEntity
    {
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
