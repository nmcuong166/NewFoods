using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsFood.Core.Dto.BussinessService
{
    public class CategoriesRespone
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long? ParentId { get; set; }
        public List<CategoriesRespone> SubCategories { get; set; }
        [JsonIgnore]
        public bool Checked { get; set; }
    }
}
