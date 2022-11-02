using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Data;
using backend.Entities.Repositories;
using backend.Entities.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Services
{
    public class PriceService : IPriceService
    {
        protected readonly IPriceRepository PriceRepository;
        protected readonly AppDbContext Context;

        public PriceService(IPriceRepository priceRepository, AppDbContext context)
        {
            PriceRepository = priceRepository;
            Context = context;
        }
        
        public async Task<Price> AddPrice(PriceRequest priceRequest)
        {
            var price = new Price()
            {
                PriceDate = priceRequest.PriceDate,
                PriceValue = priceRequest.PriceValue,
                ProductId = priceRequest.ProductId
            };

            await Context.Prices.AddAsync(price);
            await Context.SaveChangesAsync();

            return price;
        }

        public async Task<List<Price>> GetPricesByProductId(int productId)
        {
            return await Context.Prices.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<List<Price>> GetPricesByDate(DateTime date)
        {
            return await Context.Prices.Where(x => x.PriceDate == date).ToListAsync();
        }
    }
}