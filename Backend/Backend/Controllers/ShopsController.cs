using System.Threading.Tasks;
using AutoMapper;
using backend.Entities.Requests;
using backend.Entities.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly IMapper _mapper;

        public ShopsController(IShopService shopService, IMapper mapper)
        {
            _shopService = shopService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShops()
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var list = await _shopService.GetAllShops();

            return Ok(list);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddShop([FromBody] ShopRequest shopRequest)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var shop = await _shopService.AddShop(shopRequest);

            return Ok(shop);
        }
    }
}