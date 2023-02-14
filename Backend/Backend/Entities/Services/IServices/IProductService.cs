using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Services.IServices
{
    public interface IProductService
    {
        public Task<Product> GetProductById(int id);
        public Task<List<Product>> GetAllProducts();
        public Task<Product> AddProduct(ProductRequest productRequest);
    }
}