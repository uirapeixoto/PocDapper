using Infra.Interface;
using Infra.Model;
using Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _respository;

        public ProductService(IProductRepository respository)
        {
            _respository = respository;
        }
        
        public async Task<Product> AddAsync(Product product) => await _respository.AddAsync(product);
        public async Task<IEnumerable<Product>> GetAllAsync() => await _respository.GetAllAsync();
        public async Task<IEnumerable<Product>> GetWithCategoryAsync() => await _respository.GetWithCategoryAsync();
        
    }
}
