using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Services.IServices
{
    public interface IOrderService
    {
        public Task<Order> AddOrder(OrderRequest order);
        public Task<Order> UpdateOrder(Order order);
        public Task<bool> DeleteOrder(int id);
        public Task<Order> GetOrderById(int orderId);
        public Task<List<Order>> GetAllOrders();
        public Task<List<Order>> GetOrdersByProductId(int productId);
    }
}