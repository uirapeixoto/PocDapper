using Infra.Factory;
using Infra.Interface;
using Infra.Repository;
using Microsoft.Extensions.DependencyInjection;
using Service.Contract;
using Service.Services;
using System;

namespace CrossCutting
{
    public class StartupIoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Infra
            services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
            #endregion

            #region Product
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            #endregion

            #region Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion

        }
    }
}
