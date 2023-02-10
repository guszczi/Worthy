using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Services.IServices
{
    public interface IShopService
    {
        public Task<Shop> AddShop(ShopRequest shop);
        public Task<Shop> UpdateShop(Shop shop);
        public Task<bool> DeleteShop(int shopId);
        public Task<Shop> GetShopById(int orderId);
        public Task<List<Shop>> GetAllShops();
    }
}