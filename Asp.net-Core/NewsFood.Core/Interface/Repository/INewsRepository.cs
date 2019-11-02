using NewsFood.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Repository
{
    public interface INewsRepository 
    {
        Task<IEnumerable<News>> GetAll();
    }
}
