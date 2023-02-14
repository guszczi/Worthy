using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using backend.Entities;
using backend.Entities.Models;
using backend.Entities.Requests;
using backend.Entities.Services;
using backend.Entities.Services.IServices;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebScraperController : ControllerBase
    {
        private readonly IPriceService _priceService;
        private readonly IRatingService _ratingService;
        private readonly IOrderService _orderService;
        private readonly ILinkService _linkService;

        public WebScraperController(IPriceService priceService, IRatingService ratingService, IOrderService orderService, ILinkService linkService)
        {
            _priceService = priceService;
            _ratingService = ratingService;
            _orderService = orderService;
            _linkService = linkService;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDataFromWebScrapper()
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var links = await _linkService.GetAllLinks();

            foreach (var link in links)
            {
                var scraperRequest = new ScraperRequest
                {
                    Url = link.LinkUrl,
                    ProductId = link.ProductId,
                    ShopId = link.ShopId
                };
                
                var data = await Utils.GetData(scraperRequest);

                var price = new PriceRequest
                {
                    PriceValue = Double.Parse(data[0]),
                    ProductId = scraperRequest.ProductId,
                    ShopId = scraperRequest.ShopId
                };

                var rating = new Rating
                {
                    RatingGrade = Double.Parse(data[1]),
                    RatingNumber = Int32.Parse(data[2]),
                    ProductId = scraperRequest.ProductId,
                    ShopId = scraperRequest.ShopId
                };

                var order = new Order
                {
                    OrderNumber = Int32.Parse(data[3]),
                    ProductId = scraperRequest.ProductId,
                    ShopId = scraperRequest.ShopId
                };

                await _priceService.AddPrice(price);
                await _ratingService.UpdateRating(rating);
                await _orderService.UpdateOrder(order);
                
                Thread.Sleep(5000);
            }
            return Ok("Success.");
        }
    }
}