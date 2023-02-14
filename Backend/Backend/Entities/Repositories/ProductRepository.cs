using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Repositories.IRepositories;
using backend.Entities.Requests;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Repositories
{
    public class ProductRepository : IProductRepository
    {
        protected readonly AppDbContext Context;

        public ProductRepository(AppDbContext context)
        {
            Context = context;
        }
        
        public async Task<Product> Add(ProductRequest productRequest)
        {
            var product = new Product()
            {
                ProductName = productRequest.ProductName,
                ProductDescription = productRequest.ProductDescription,
                ProductImageUrl = productRequest.ProductImageUrl,
            };

            await Context.Products.AddAsync(product);
            await Context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(Price price)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetById(int id)
        {
            return await Context.Products.FirstOrDefaultAsync(x => x.ProductId == id);
        }

        public IQueryable<Product> GetAll()
        {
            return Context.Products.AsQueryable();
        }
    }
}