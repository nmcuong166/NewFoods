using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewFood.Data.BaseModels
{
    public class BaseModel : Entity, IBaseModel
    {
        public BaseModel()
        {
            IsDeleted = false;
            CreationTime = DateTime.UtcNow;
        }
        public bool IsDeleted { get; set; }
        public long? CreatorUserId { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationTime { get; set; }
        public long? DeleteUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
