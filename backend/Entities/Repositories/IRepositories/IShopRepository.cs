using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Repositories.IRepositories
{
    public interface IShopRepository
    {
        public Task<Shop> Add(ShopRequest shopRequest);
        public Task<Shop> Update(Shop shop);
        public Task<bool> Delete(int id);
        public Task<Shop> GetById(int id);
        public IQueryable<Shop> GetAll();
    }
}