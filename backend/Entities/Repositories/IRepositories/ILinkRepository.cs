using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Repositories.IRepositories
{
    public interface ILinkRepository
    {
        public Task<Link> Add(LinkRequest linkRequest);
        public Task<Link> Update(Link link);
        public Task<bool> Delete(int id);
        public Task<Link> GetById(int id);
        public Task<List<Link>> GetByProductId(int productId);
        public IQueryable<Link> GetAll();
    }
}