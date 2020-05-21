using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsFood.Core.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFood.Api.Presenters
{
    public class JsonContentResult<T> : ContentResult
    {
        public JsonContentResult(T Data, BaseRespone respone)
        {
            Handle(Data, respone);
        }

        public JsonContentResult(BaseRespone respone)
        {
            ContentType = "application/json";
            StatusCode = respone.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
            var baseContent = new BaseContentRespone<T>
            {
                Data = default(T),
                Sucess = respone.Success,
                Status = respone.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest,
                Errors = respone.Errors,
                Message = HandleMessage(respone.Errors)
            };

            Content = JsonConvert.SerializeObject(baseContent);
        }

        public void Handle(T Data, BaseRespone respone)
        {
            ContentType = "application/json";
            StatusCode = respone.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest;
            var baseContent = new BaseContentRespone<T>
            {
                Data = Data,
                Sucess = respone.Success,
                Status = respone.Success ? StatusCodes.Status200OK : StatusCodes.Status400BadRequest,
                Errors = respone.Errors,
                Message = HandleMessage(respone.Errors)
            };
            
            Content = JsonConvert.SerializeObject(baseContent);
        }

        public string HandleMessage(IEnumerable<Error> errors)
        {
            if(errors != null && errors.Any())
            {
                return string.Join(",", errors.Select(s => s.Description));
            }
            return string.Empty;
        }
    }
}
