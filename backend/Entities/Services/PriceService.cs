using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Data;
using backend.Entities.Repositories;
using backend.Entities.Repositories.IRepositories;
using backend.Entities.Requests;
using backend.Entities.Services.IServices;
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
            return await PriceRepository.Add(priceRequest);
        }

        public async Task<Price> UpdatePrice(Price price)
        {
            return await PriceRepository.Update(price);
        }

        public async Task<bool> DeletePrice(int priceId)
        {
            return await PriceRepository.Delete(priceId);
        }

        public async Task<List<Price>> GetAllPrices()
        {
            return await PriceRepository.GetAll().ToListAsync();
        }

        public async Task<List<Price>> GetPricesByProductId(int productId)
        {
            return await PriceRepository.GetByProductId(productId);
        }

        public async Task<List<Price>> GetPricesByDate(DateTime date)
        {
            return await PriceRepository.GetByDate(date);
        }
    }
}