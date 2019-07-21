using Microsoft.AspNetCore.Mvc;
using NewsFood.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFood.Application.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        public AppBaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
