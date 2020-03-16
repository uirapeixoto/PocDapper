using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Service.Services;
using System.Threading.Tasks;

namespace PocDapper.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        /// <summary>
        /// Retorna a lista de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        /// <summary>
        /// Retorna a lista de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("category")]
        public async Task<IActionResult> GetWithCategory()
        {
            var response = await _service.GetWithCategoryAsync();
            return Ok(response);
        }
    }
}