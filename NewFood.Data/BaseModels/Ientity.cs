using System;
using System.Collections.Generic;
using System.Text;

namespace NewFood.Data.BaseModels
{
    interface IEntity
    {
        Guid Id { get; set; }
    }
}
