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
    public class CategoryServiceTest
    {
        private IEnumerable<Category> _dataMock;
        private IEnumerable<Category> _dataMockWithProducts;
        private Mock<ICategoryRepository> _mockRepository;
        private CategoryService _service;

        public CategoryServiceTest()
        {
            InitMock();
            _mockRepository = _mockRepository = new Mock<ICategoryRepository>();
            _mockRepository.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(_dataMock));
            _mockRepository.Setup(x => x.GetTreeAsync()).Returns(Task.FromResult(_dataMock));
            _mockRepository.Setup(x => x.GetAllProducts()).Returns(Task.FromResult(_dataMockWithProducts));

            _service = new CategoryService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllTestAsync()
        {
            var result = await _service.GetAllAsync();
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Category>>(result);
            Assert.Equal(1, result.FirstOrDefault().Id);
            Assert.Equal("Categoria pai 1", result.FirstOrDefault().Name);
            Assert.Equal("Descricao da categoria pai 1", result.FirstOrDefault().Description);

        }

        [Fact]
        public async Task GetTreeTestAsync()
        {
            var result = await _service.GetTreeAsync();
            Assert.NotNull(result.FirstOrDefault().SubCategory);
            Assert.IsAssignableFrom<IEnumerable<Category>>(result);
            Assert.Equal("Categoria filha 1 da categoria pai 1", result.FirstOrDefault().SubCategory.FirstOrDefault().Name);
        }

        [Fact]
        public async Task GetAllProductsTestAsync()
        {
            var result = await _service.GetAllProducts();
            Assert.NotNull(result.FirstOrDefault().Products);
            Assert.IsAssignableFrom<IEnumerable<Product>>(result.FirstOrDefault().Products);
            Assert.IsType<int>(result.FirstOrDefault().Id);
            Assert.Equal("Produto 1", result.FirstOrDefault().Products.FirstOrDefault().Name);
            Assert.Equal("Produto 1 da categoria filha 1 da categoria pai 1", result.FirstOrDefault().Products.FirstOrDefault().Description);
        }

        private void InitMock()
        {
            _dataMock = new List<Category>{
                new Category
                {
                    Id = 1,
                    Name = "Categoria pai 1",
                    Description = "Descricao da categoria pai 1",
                    SubCategory = new List<Category>
                    {
                        new Category
                        {
                            Id = 3,
                            Name = "Categoria filha 1 da categoria pai 1",
                            Description = "Descricao da categoria filha 1",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Id = 1,
                                    Name = "Produto 1",
                                    Description = "Produto 1 da categoria filha 1 da categoria pai 1"
                                },
                                new Product
                                {
                                    Id = 2,
                                    Name = "Produto 2",
                                    Description = "Produto 2 da categoria filha 1 da categoria pai 1"
                                }
                            }
                        },
                        new Category
                        {
                            Id = 4,
                            Name = "Categoria filha 2 da categoria pai 1",
                            Description = "Descricao da categoria filha 2",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Id = 3,
                                    Name = "Produto 3",
                                    Description = "Produto 3 da categoria filha 2 da categoria pai 1"
                                },
                                new Product
                                {
                                    Id = 4,
                                    Name = "Produto 4",
                                    Description = "Produto 4 da categoria filha 2 da categoria pai 1"
                                }
                            }
                        }
                    },
                },
                new Category
                {
                    Id = 2,
                    Name = "Categoria pai 2",
                    Description = "Descricao da categoria pai 2",
                    SubCategory = new List<Category>
                    {
                        new Category
                        {
                            Id = 3,
                            Name = "Categoria filha 1 da categoria pai 2",
                            Description = "Descricao da categoria filha 2",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Id = 5,
                                    Name = "Produto 5",
                                    Description = "Produto 5 da categoria filha 1 da categoria pai 2"
                                },
                                new Product
                                {
                                    Id = 6,
                                    Name = "Produto 6",
                                    Description = "Produto 6 da categoria filha 1 da categoria pai 2"
                                }
                            }
                        },
                        new Category
                        {
                            Id = 4,
                            Name = "Categoria filha 2 da categoria pai 2",
                            Description = "Descricao da categoria filha 2"
                        }
                    },
                },
                new Category
                {
                    Id = 3,
                    Name = "Categoria pai 3",
                    Description = "Descricao da categoria pai 3"
                }
            };

            _dataMockWithProducts = new List<Category>{
                new Category
                {
                    Id = 3,
                    Name = "Categoria filha 1 da categoria pai 1",
                    Description = "Descricao da categoria filha 1",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = 1,
                            Name = "Produto 1",
                            Description = "Produto 1 da categoria filha 1 da categoria pai 1"
                        },
                        new Product
                        {
                            Id = 2,
                            Name = "Produto 2",
                            Description = "Produto 2 da categoria filha 1 da categoria pai 1"
                        }
                    }
                }
            };
        }
    }
}
