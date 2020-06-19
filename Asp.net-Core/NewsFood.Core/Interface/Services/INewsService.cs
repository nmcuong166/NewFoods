using NewsFood.Core.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsFood.Core.Interface.Bussiness
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDto>> GetAllNewsServiceAsync();
    }
}
