using System;
using System.Collections.Generic;
using System.Text;

namespace NewFood.Data.BaseModels
{
    public interface IBaseModel
    {
        bool IsDeleted { get; set; }
        long? CreatorUserId { get; set; }
        DateTime CreationTime { get; set; }
        long? DeleteUserId { get; set; }
        DateTime? DeletedTime { get; set; }
    }
}
