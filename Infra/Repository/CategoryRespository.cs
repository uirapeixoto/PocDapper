using Dapper;
using Infra.Interface;
using Infra.Model;
using Slapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public CategoryRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync() {
            return await _connectionFactory.GetConnection().QueryAsync<Category>("select * from Category where IdCategory is null");
        }

        public async Task<IEnumerable<Category>> GetTreeAsync()
        {
            var query = @"SELECT [Id]
                          ,[Name]
                          ,[Description]
                          ,[IdCategory]
                          ,[CreatedAt]
                          ,[ModifiedAt]
                         FROM [Customer].[dbo].[Category] Where [IdCategory] is null";
            var dados = await _connectionFactory.GetConnection().QueryAsync<Category>(query);
            dados.ToList().ForEach(
                async p => {
                    var subquery = $@"SELECT [Id]
                                      ,[Name]
                                      ,[Description]
                                      ,[IdCategory]
                                      ,[CreatedAt]
                                      ,[ModifiedAt]
                                    FROM [Customer].[dbo].[Category] Where [IdCategory] = {p.Id}";
                    p.SubCategory = await _connectionFactory.GetConnection().QueryAsync<Category>(subquery);
                }
            );

            return dados;
        }

        public async Task<IEnumerable<Category>> GetAllProducts()
        {
            var query = $@"SELECT [Id], [Name], [Description] FROM [Category] Where [IdCategory] is not null";

            var dados = await _connectionFactory.GetConnection().QueryAsync<Category>(query);
            dados.ToList().ForEach(
            async p =>
                {
                    var subquery = $@"SELECT Id, Name, Description FROM [Product] Where IdCategory = {p.Id}";
                    p.Products = await _connectionFactory.GetConnection().QueryAsync<Product>(subquery);
                });

            return dados;

        }
    }
}
