using Dapper;
using Infra.Interface;
using Infra.Model;
using Infra.Model.QueryResult;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public ProductRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<Product> AddAsync(Product product)
        {
            int _id = 0;
            var insertQuery = @"INSERT [Product] VALUES(@Name, @Desctription, @IdCategory); SELECT CAST(SCOPE_IDENTITY() as int);";
            var _connection = _connectionFactory.GetConnection();
            try
            {
                using (var transaction = _connection.BeginTransaction())
                {
                    _id = await _connection.QueryFirstOrDefaultAsync<int>(insertQuery, new
                    {
                        Name = product.Name,
                        Description = product.Description,
                        IdCategory = product.Category.Id
                    });
                    
                    transaction.Commit();
                }

                return await GetByIdAsync(_id);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public async Task<Product> GetByIdAsync(int id) => await
            _connectionFactory.GetConnection().QueryFirstOrDefaultAsync<Product>("select * from Product where Id = @Id", new { Id = id});

        public async Task<IEnumerable<Product>> GetAllAsync() => await 
            _connectionFactory.GetConnection().QueryAsync<Product>("select * from Product");

        public async Task<IEnumerable<Product>> GetWithCategoryAsync()
        {
            var product =  await _connectionFactory.GetConnection().QueryAsync<ProductCategoryResult>($@"select a.Id, a.Name, a.Description,  c.Id IdCategory, c.Name Category, b.ID IdSubCategory,  b.Name SubCategory  
            from Product a 
            join Category b on a.IdCategory = b.Id
            join Category c on b.IdCategory = c.Id");

            return product.Select(x => new Product { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Category = new Category
                {
                    Id = x.IdCategory,
                    Name = x.Category
                }
            });
        }
    }
}
