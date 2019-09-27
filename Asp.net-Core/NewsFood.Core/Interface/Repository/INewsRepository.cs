using NewsFood.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Repository
{
    public interface INewsRepository
    {
        Task<IEnumerable<News>> GetAll();
    }
}
