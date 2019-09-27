using NewsFood.Core.Interface.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsFood.Core.Entities.BaseEntities
{
    public class BaseEntity : Entity , IBaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public long? DeleteUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
