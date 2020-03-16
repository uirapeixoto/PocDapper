using Infra.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetTreeAsync();
        Task<IEnumerable<Category>> GetAllProducts();
    }
}
