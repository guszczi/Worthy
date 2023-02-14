using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Repositories.IRepositories;
using backend.Entities.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        protected readonly AppDbContext Context;

        public PriceRepository(AppDbContext context)
        {
            Context = context;
        }
        
        public async Task<Price> Add(PriceRequest priceRequest)
        {
            var price = new Price()
            {
                PriceDate = DateTime.Today.ToLocalTime(),
                PriceValue = priceRequest.PriceValue,
                ProductId = priceRequest.ProductId,
                ShopId = priceRequest.ShopId
            };

            await Context.Prices.AddAsync(price);
            await Context.SaveChangesAsync();

            return price;
        }

        public async Task<Price> Update(Price price)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Price> GetById(int id)
        {
            return await Context.Prices.FirstOrDefaultAsync(x => x.PriceId == id);
        }

        public async Task<List<Price>> GetByProductId(int productId)
        {
            return await GetAll().Where(x => x.ProductId == productId).ToListAsync();
        }
        
        public async Task<List<Price>> GetByShopId(int shopId)
        {
            return await GetAll().Where(x => x.ShopId == shopId).ToListAsync();
        }

        public async Task<List<Price>> GetByDate(DateTime date)
        {
            return await GetAll().Where(x => x.PriceDate == date).ToListAsync();
        }

        public async Task<Price> GetHistoricalLowPriceByProductId(int productId)
        {
            return await GetAll().Where(x => x.ProductId == productId).OrderBy(x => x.PriceValue).FirstOrDefaultAsync();
        }

        public async Task<List<Price>> GetDailyPricesByProductId(int productId)
        {
            return await GetAll().Where(x => x.ProductId == productId).GroupBy(x => x.PriceDate)
                .Select(g => new Price
                {
                    PriceDate = g.Key,
                    PriceValue = g.Min(x => x.PriceValue)
                }).ToListAsync();
        }

        public IQueryable<Price> GetAll()
        {
            return Context.Prices.AsQueryable();
        }
    }
}