using Infra.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetWithCategoryAsync();
        Task<Product> AddAsync(Product product);
    }
}
