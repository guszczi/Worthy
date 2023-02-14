using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Services.IServices
{
    public interface IRatingService
    {
        public Task<Rating> AddRating(RatingRequest rating);
        public Task<Rating> UpdateRating(Rating rating);
        public Task<bool> DeleteRating(int ratingId);
        public Task<Rating> GetRatingById(int ratingId);
        public Task<List<Rating>> GetAllRatings();
        public Task<List<Rating>> GetRatingsByProductId(int productId);
    }
}