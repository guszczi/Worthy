using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Repositories.IRepositories;
using backend.Entities.Requests;
using backend.Entities.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Services
{
    public class ShopService : IShopService
    {
        protected readonly AppDbContext Context;
        protected readonly IShopRepository ShopRepository;

        public ShopService(AppDbContext context, IShopRepository shopRepository)
        {
            Context = context;
            ShopRepository = shopRepository;
        }

        public async Task<Shop> AddShop(ShopRequest shop)
        {
            return await ShopRepository.Add(shop);
        }

        public async Task<Shop> UpdateShop(Shop shop)
        {
            return await ShopRepository.Update(shop);
        }

        public async Task<bool> DeleteShop(int shopId)
        {
            return await ShopRepository.Delete(shopId);
        }

        public async Task<Shop> GetShopById(int shopId)
        {
            return await ShopRepository.GetById(shopId);
        }

        public async Task<List<Shop>> GetAllShops()
        {
            return await ShopRepository.GetAll().ToListAsync();
        }
    }
}