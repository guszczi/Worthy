using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Repositories.IRepositories
{
    public interface IPriceRepository
    {
        public Task<Price> Add(PriceRequest priceRequest);
        public Task<Price> Update(Price price);
        public Task<bool> Delete(int id);
        public Task<Price> GetById(int id);
        public Task<List<Price>> GetByProductId(int productId);
        public Task<List<Price>> GetByShopId(int shopId);
        public Task<List<Price>> GetByDate(DateTime date);
        public Task<Price> GetHistoricalLowPriceByProductId(int productId);
        public Task<List<Price>> GetDailyPricesByProductId(int productId);
        public IQueryable<Price> GetAll();
    }
}