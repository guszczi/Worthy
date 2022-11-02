using System;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        protected readonly AppDbContext Context;
        
        public Task<bool> Add(PriceRequest priceRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Price price)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Price> GetById(int id)
        {
            return Context.Prices.FirstOrDefaultAsync(x => x.PriceId == id);
        }

        public IQueryable<Price> GetByProductId(int productId)
        {
            return Context.Prices.AsQueryable().Where(x => x.ProductId == productId);
        }

        public IQueryable<Price> GetByDate(DateTime date)
        {
            return Context.Prices.AsQueryable().Where(x => x.PriceDate == date);
        }

        public IQueryable<Price> GetAll()
        {
            return Context.Prices;
        }
    }
}