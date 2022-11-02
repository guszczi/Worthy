using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Services
{
    public interface IPriceService
    {
        public Task<Price> AddPrice(PriceRequest price);
        public Task<List<Price>> GetPricesByProductId(int productId);
        public Task<List<Price>> GetPricesByDate(DateTime date);
    }
}