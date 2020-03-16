using Infra.Interface;
using Infra.Model;
using Moq;
using Service.Services;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Service.Test
{
    [ExcludeFromCodeCoverage]
    public class ProductServiceTest
    {
        private IEnumerable<Product> _dataMock;
        private ProductService _mockService;
        private Mock<IProductRepository> _mockRepository;

        public ProductServiceTest()
        {
            InitMock();
            _mockRepository = new Mock<IProductRepository>();
            _mockRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_dataMock));
            _mockRepository.Setup(x => x.GetWithCategoryAsync()).Returns(Task.FromResult(_dataMock));
            _mockRepository.Setup(x => x.AddAsync(It.IsAny<Product>())).Returns((Product target) => {
                if(target != null)
                {
                    _dataMock.ToList().Add(target);
                    Task<Product> response = Task.FromResult(target);
                    return response;
                }
                else
                {
                    return null;
                }
            });
            _mockService = new ProductService(_mockRepository.Object);

        }

        [Fact]
        public async Task GetAllTestAsync()
        {
            var result = await _mockService.GetAllAsync();
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Product>>(result);
            Assert.Equal("Produto 1", result.FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetWithCategoryTestAsync()
        {
            var result = await _mockService.GetWithCategoryAsync();
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Product>>(result);
            Assert.IsAssignableFrom<Category>(result.FirstOrDefault().Category);
            Assert.Equal("Produto 1", result.FirstOrDefault().Name);
        }

        [Fact]
        public async Task AddTestAsync()
        {
            var product = new Product
            {
                Id = 2,
                Name = "Product add",
                Description = "Description add",
                Category = new Category
                {
                    Id = 7 
                }
            };

            var result = await _mockService.AddAsync(product);
            
            Assert.NotNull(result);
            Assert.IsAssignableFrom<Product>(result);
            Assert.Equal(2, result.Id);
            Assert.IsType<string>(result.Description);
        }

        [Fact]
        public void TestContract()
        {
            var service = new ProductService(_mockRepository.Object);
            _mockRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_dataMock));
            Assert.Equal("Produto 1", service.GetAllAsync().Result.FirstOrDefault().Name);
        }

        private void InitMock()
        {
            _dataMock = new List<Product> {
                new Product { 
                    Id = 1,
                    Name = "Produto 1",
                    Description = "Descricao do produto 1",
                    Category = new Category
                    {
                        Id = 2,
                        Name = "SubCategoria",
                        Description = "Descricao da subcategoria"
                    }
                }
            };
        }
    }
}
