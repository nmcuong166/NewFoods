using Microsoft.AspNetCore.Http;
using NewsFood.Core.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFood.Api.Presenters
{
    public class BaseContentRespone<T>
    {
        [JsonProperty("status")]
        public int? Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("sucess")]
        public bool Sucess { get; set; }
        [JsonProperty("data")]
        public T Data { get; set; }
        [JsonProperty("errors")]
        public IEnumerable<Error> Errors { get; set; }
    }
}
