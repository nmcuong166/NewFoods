using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Entities.BaseEntities
{
    public class BaseEntity : Entity
    {
        public bool IsDeleted { get; set; } = false;
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public long? DeleteUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
