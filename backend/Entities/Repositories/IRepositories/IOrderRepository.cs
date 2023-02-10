using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Repositories.IRepositories
{
    public interface IOrderRepository
    {
        public Task<Order> Add(OrderRequest orderRequest);
        public Task<Order> Update(Order order);
        public Task<bool> Delete(int id);
        public Task<Order> GetById(int id);
        public Task<List<Order>> GetByProductId(int productId);
        public IQueryable<Order> GetAll();
    }
}