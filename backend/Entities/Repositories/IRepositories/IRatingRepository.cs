using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Repositories.IRepositories
{
    public interface IRatingRepository
    {
        public Task<Rating> Add(RatingRequest ratingRequest);
        public Task<Rating> Update(Rating rating);
        public Task<bool> Delete(int id);
        public Task<Rating> GetById(int id);
        public Task<List<Rating>> GetByProductId(int productId);
        public IQueryable<Rating> GetAll();
    }
}