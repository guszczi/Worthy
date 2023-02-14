using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Repositories.IRepositories;
using backend.Entities.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Repositories
{
    public class ShopRepository : IShopRepository
    {
        protected readonly AppDbContext Context;

        public ShopRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<Shop> Add(ShopRequest shopRequest)
        {
            var shop = new Shop()
            {
                ShopName = shopRequest.ShopName,
            };

            await Context.Shops.AddAsync(shop);
            await Context.SaveChangesAsync();

            return shop;
        }

        public async Task<Shop> Update(Shop shop)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Shop> GetById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.ShopId == id);
        }

        public IQueryable<Shop> GetAll()
        {
            return Context.Shops.AsQueryable();
        }
    }
}