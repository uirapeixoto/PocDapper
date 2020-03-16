using Infra.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetTreeAsync();
        Task<IEnumerable<Category>> GetAllProducts();
    }
}
