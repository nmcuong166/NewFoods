using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewFood.Data.Models;
using NewsFood.Application.Controllers;
using NewsFood.Core.Common;
using NewsFood.Core.Common.ProcedureHelper;
using NewsFood.Core.Repository;

namespace NewsFood.Controllers
{
    [ApiController]
    public class ValuesController : AppBaseController
    {
        private IProcHelper _procHelper;
        public ValuesController
        (
            IUnitOfWork unitOfWork
        )
            : base(unitOfWork)
        {
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetAll()
        {
            var id1 = new Guid("4a293ed3-debb-4504-be1a-cb4bc9ec3266");
            return await _unitOfWork.Repository<News>()
                                    .GetAll()
                                    .Where(s => s.Id == id1).ToListAsync();
        }

        [HttpGet]
        public async Task<IEnumerable<ContentDataResult>> TestProc()
        {
            var query = "select Contents from News";
            ContentDataResult dataResult = new ContentDataResult();

            var contents = await _procHelper.ExecuteQueryAsync<ContentDataResult>(query, dataResult, CommandType.Text);
            return contents.Data;
        }

        public class ContentDataResult
        {
            public string Contents { get; set; }
        }


        // GET api/values/5
        [HttpGet]
        public async Task<ActionResult<News>> GetProductById([FromQuery]Guid id)
        {
            return await _unitOfWork.Repository<News>().GetAsync(id);
        }

        //[HttpGet("GetDynamicColumn")]
        [HttpGet]
        [Route("/Values/GetDynamicColumn")]
        public async Task<ActionResult<News>> GetFollowColumn([FromQuery]Guid id)
        {
            return await _unitOfWork.Repository<News>()
                .GetAll()
                .Where("Id", id.ToString()).FirstOrDefaultAsync();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
        }

        [HttpGet]
        public IEnumerable<string> GetContents()
        {
            return _unitOfWork.Repository<News>().GetAll().Select(s => s.Contents);
        }
    }
}
