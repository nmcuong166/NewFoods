using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsFood.Core.Dto.BussinessService
{
    public class CategoriesRespone
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public long? ParentId { get; set; }
        [JsonProperty("subcategories")]
        public List<CategoriesRespone> SubCategories { get; set; }
        [JsonIgnore]
        public bool Checked { get; set; }
    }
}
