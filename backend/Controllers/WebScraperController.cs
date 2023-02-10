using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
        private readonly IProductService _productService;
        
        public WebScraperController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpPost]
        public async Task<IActionResult> GetDataFromSite([FromBody] ScraperRequest scraperRequest)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) " +
                                                                    "AppleWebKit/537.36 (KHTML, like Gecko) " +
                                                                    "Chrome/107.0.0.0 Safari/537.36 Edg/107.0.1418.62");
                    using (HttpResponseMessage res = await client.GetAsync(scraperRequest.Url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            HtmlDocument htmlDoc = new HtmlDocument();
                            htmlDoc.LoadHtml(data);

                            var productPrice = "";

                            switch (scraperRequest.ShopId)
                            {
                                case 1:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//div[@class='sc-n4n86h-4 jwVRpW']")
                                        .First().GetDirectInnerText();
                                    productPrice = productPrice.Remove(productPrice.Length - 3).Replace(',', '.');
                                    break;
                                case 2:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//div[@class='product-price']")
                                        .First().Attributes["content"].Value;
                                    break;
                                case 3:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//span[@class='proper']")
                                        .First().GetDirectInnerText();
                                    productPrice = Regex.Replace(productPrice, @"\s+", "");
                                    break;
                                case 4:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//div[@class='prices']")
                                        .First().Attributes["rawprice"].Value;
                                    break;
                                case 5:
                                    productPrice = htmlDoc.DocumentNode.SelectNodes("//em[@class='main-price']")
                                        .First().GetDirectInnerText();
                                    productPrice = productPrice.Remove(productPrice.Length - 3).Replace(',','.');
                                    break;
                            }

                            productPrice = Regex.Replace(productPrice, @"\s+", "");

                            var price = new Price
                            {
                                PriceDate = DateTime.Today.ToLocalTime(),
                                PriceValue = Double.Parse(productPrice),
                                ProductId = scraperRequest.ProductId,
                                ShopId = scraperRequest.ShopId
                            };
                            
                            return Ok(price);
                        }
                    }
                }
            } catch(Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}