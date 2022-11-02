using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly AppDbContext Context;
        
        public Task<bool> Add(ProductRequest productRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Price price)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            return Context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public IQueryable<Product> GetAll()
        {
            return Context.Products;
        }
    }
}