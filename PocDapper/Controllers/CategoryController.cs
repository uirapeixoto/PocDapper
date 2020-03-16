using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using System.Threading.Tasks;

namespace PocDapper.Controllers
{
    [Route("api/v1/category")]
    [Produces("application/json")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(await _service.GetAllAsync());
        [HttpGet]
        [Route("tree")]
        public async Task<IActionResult> GetTreeAsync() => Ok(await _service.GetTreeAsync());[HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProductsAsync() => Ok(await _service.GetAllProducts());
    }
}