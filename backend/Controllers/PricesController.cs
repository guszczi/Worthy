using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using backend.Entities.Models;
using backend.Entities.Requests;
using backend.Entities.Responses;
using backend.Entities.Services;
using backend.Entities.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly IMapper _mapper;

        public PricesController(IPriceService priceService, IMapper mapper)
        {
            _priceService = priceService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPrices()
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var list = await _priceService.GetAllPrices();
            
            return Ok(list.ToArray());
        }
        
        [HttpGet("byDate")]
        public async Task<IActionResult> GetPricesByDate(DateTime date)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var list = await _priceService.GetPricesByDate(date);
            
            return Ok(list.ToArray());
        }

        [HttpGet("byProductId")]
        public async Task<IActionResult> GetPricesByProductId(int id)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var list = await _priceService.GetPricesByProductId(id);

            return Ok(list);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddPrice([FromBody] PriceRequest priceRequest)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var price = await _priceService.AddPrice(priceRequest);

            return Ok(price);
        }
    }
}