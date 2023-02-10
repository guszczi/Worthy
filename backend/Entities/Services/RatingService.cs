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
    public class RatingService : IRatingService
    {
        protected readonly IRatingRepository RatingRepository;
        protected readonly AppDbContext Context;

        public RatingService(IRatingRepository ratingRepository, AppDbContext context)
        {
            RatingRepository = ratingRepository;
            Context = context;
        }

        public Task<Rating> UpdateRating(Rating rating)
        {
            return RatingRepository.Update(rating);
        }

        public Task<Rating> AddRating(RatingRequest rating)
        {
            return RatingRepository.Add(rating);
        }

        public Task<bool> DeleteRating(int ratingId)
        {
            return RatingRepository.Delete(ratingId);
        }

        public Task<Rating> GetRatingById(int ratingId)
        {
            return RatingRepository.GetById(ratingId);
        }

        public Task<List<Rating>> GetAllRatings()
        {
            return RatingRepository.GetAll().ToListAsync();
        }

        public Task<List<Rating>> GetRatingsByProductId(int productId)
        {
            return RatingRepository.GetByProductId(productId);
        }
    }
}