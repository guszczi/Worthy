using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Repositories.IRepositories
{
    public interface IProductRepository
    {
        public Task<Product> Add(ProductRequest productRequest);
        public Task<Product> Update(Price price);
        public Task<bool> Delete(int id);
        public Task<Product> GetById(int id);
        public IQueryable<Product> GetAll();
    }
}