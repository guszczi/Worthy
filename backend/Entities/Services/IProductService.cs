using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Services
{
    public interface IProductService
    {
        public Task<Product> GetProductById(int id);
        public Task<Product> AddProduct(ProductRequest productRequest);
    }
}