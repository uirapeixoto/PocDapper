using Infra.Interface;
using Infra.Model;
using Service.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<IEnumerable<Category>> GetTreeAsync() => await _repository.GetTreeAsync();
        public async Task<IEnumerable<Category>> GetAllProducts() => await _repository.GetAllProducts();
    }
}
