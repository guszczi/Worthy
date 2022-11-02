using System;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Repositories
{
    public interface IPriceRepository
    {
        public Task<bool> Add(PriceRequest priceRequest);
        public Task<bool> Update(Price price);
        public Task<bool> Delete(int id);
        public Task<Price> GetById(int id);
        public IQueryable<Price> GetByProductId(int productId);
        public IQueryable<Price> GetByDate(DateTime date);
        public IQueryable<Price> GetAll();
    }
}