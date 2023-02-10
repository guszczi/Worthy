using System.Threading.Tasks;
using AutoMapper;
using backend.Entities.Requests;
using backend.Entities.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var list = await _orderService.GetAllOrders();

            return Ok(list);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddOrder([FromBody] OrderRequest orderRequest)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var order = await _orderService.AddOrder(orderRequest);

            return Ok(order);
        }
            
    }
}