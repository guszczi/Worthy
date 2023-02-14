using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Data;
using backend.Entities.Models;
using backend.Entities.Repositories.IRepositories;
using backend.Entities.Requests;
using backend.Entities.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace backend.Entities.Services
{
    public class OrderService : IOrderService
    {
        protected readonly AppDbContext Context;
        protected readonly IOrderRepository OrderRepository;

        public OrderService(AppDbContext context, IOrderRepository orderRepository)
        {
            Context = context;
            OrderRepository = orderRepository;
        }

        public async Task<Order> AddOrder(OrderRequest order)
        {
            return await OrderRepository.Add(order);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            return await OrderRepository.Update(order);
        }

        public async Task<bool> DeleteOrder(int id)
        {
            return await OrderRepository.Delete(id);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await OrderRepository.GetById(orderId);
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await OrderRepository.GetAll().ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByProductId(int productId)
        {
            return await OrderRepository.GetByProductId(productId);
        }
    }
}