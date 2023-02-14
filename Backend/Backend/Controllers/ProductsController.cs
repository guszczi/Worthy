using System.Threading.Tasks;
using backend.Entities.Requests;
using backend.Entities.Services;
using backend.Entities.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet]
        [Route("{productId:int}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            return Ok(await _productService.GetProductById(productId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            return Ok(await _productService.AddProduct(productRequest));
        }
    }
}