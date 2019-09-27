using Microsoft.AspNetCore.Identity;
using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewFood.Infurstructure.Data.Entities
{
    public class AppUsers : IdentityUser<long>, IBaseEntity
    {
        public bool IsDeleted { get; set; } = false;
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModifiedTime { get; set; }
        public long? DeleteUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
