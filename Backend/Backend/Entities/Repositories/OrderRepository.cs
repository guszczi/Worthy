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
    public class OrderRepository : IOrderRepository
    {
        protected readonly AppDbContext Context;

        public OrderRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<Order> Add(OrderRequest orderRequest)
        {
            var order = new Order()
            {
                OrderNumber = orderRequest.OrderNumber,
                ProductId = orderRequest.ProductId,
                ShopId = orderRequest.ShopId,
            };

            await Context.Orders.AddAsync(order);
            await Context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> Update(Order order)
        {
            var result = Context.Orders.First(x => x.ProductId == order.ProductId && x.ShopId == order.ShopId);
            
            if (result != null)
            {
                result.OrderNumber = order.OrderNumber;
                await Context.SaveChangesAsync();
            }
            
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Order> GetById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<List<Order>> GetByProductId(int productId)
        {
            return await GetAll().Where(x => x.ProductId == productId).ToListAsync();
        }

        public IQueryable<Order> GetAll()
        {
            return Context.Orders.AsQueryable();
        }
    }
}