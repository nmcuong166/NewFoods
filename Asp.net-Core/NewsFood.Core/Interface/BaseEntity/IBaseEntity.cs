using System;
using System.Collections.Generic;
using System.Text;

namespace NewsFood.Core.Entities.BaseEntities
{
    public interface IBaseEntity
    {
        bool IsDeleted { get; set; } 
        long? CreatorUserId { get; set; }
        DateTime CreationTime { get; set; }
        DateTime ModifiedTime { get; set; }
        long? DeleteUserId { get; set; }
        DateTime? DeletedTime { get; set; }
    }
}
