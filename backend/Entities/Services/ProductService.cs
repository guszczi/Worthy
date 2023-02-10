using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Repositories;
using backend.Entities.Repositories.IRepositories;
using backend.Entities.Requests;
using backend.Entities.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Services
{
    public class ProductService : IProductService
    {
        protected readonly IProductRepository ProductRepository;
        protected readonly AppDbContext Context;

        public ProductService(IProductRepository productRepository, AppDbContext context)
        {
            ProductRepository = productRepository;
            Context = context;
        }
        
        public async Task<Product> GetProductById(int id)
        {
            return await ProductRepository.GetById(id);
        }

        public Task<List<Product>> GetAllProducts()
        {
            return ProductRepository.GetAll().ToListAsync();
        }

        public async Task<Product> AddProduct(ProductRequest productRequest)
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
    }
}