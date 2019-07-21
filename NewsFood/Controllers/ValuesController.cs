﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewFood.Data.Models;
using NewsFood.Core.Common;
using NewsFood.Core.Repository;

namespace NewsFood.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController 

    {
        private IUnitOfWork _unitOfWork;
        public ValuesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<News>>> Get()
        {
            var id1 = new Guid("4a293ed3-debb-4504-be1a-cb4bc9ec3266");
            return await _unitOfWork.Repository<News>()
                                    .GetAll()
                                    .Where(s => s.Id == id1).ToListAsync();
        }

        // GET api/values/5
        [HttpGet("GetProductById")]
        public async Task<ActionResult<News>> Get([FromQuery]Guid id)
        {
            return await _unitOfWork.Repository<News>().GetAsync(id);
        }

        [HttpGet("GetDynamicColumn")]
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
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
