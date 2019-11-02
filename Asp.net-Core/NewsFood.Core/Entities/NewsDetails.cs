using NewsFood.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsFood.Core.Entities
{
    public class NewsDetails : Entity
    {
        public long NewsId { get; set; }
        [ForeignKey(nameof(NewsId))]
        public News News { get; set; }
        public string Contents { get; set; }
    }
}
