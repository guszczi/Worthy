using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Repositories;
using backend.Entities.Requests;

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

        public async Task<Product> AddProduct(ProductRequest productRequest)
        {
            var product = new Product()
            {
                ProductName = productRequest.ProductName,
                ProductRating = productRequest.ProductRating,
                ProductImageUrl = productRequest.ProductImageUrl,
                ProductNumberOfOrders = productRequest.ProductNumberOfOrders
            };

            await Context.Products.AddAsync(product);
            await Context.SaveChangesAsync();

            return product;
        }
    }
}