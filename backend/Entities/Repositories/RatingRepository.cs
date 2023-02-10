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
    public class RatingRepository : IRatingRepository
    {
        protected readonly AppDbContext Context;

        public RatingRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<Rating> Add(RatingRequest ratingRequest)
        {
            var rating = new Rating()
            {
                RatingNumber = ratingRequest.RatingNumber,
                RatingGrade = ratingRequest.RatingGrade,
                ProductId = ratingRequest.ProductId,
                ShopId = ratingRequest.ShopId,
            };

            await Context.Ratings.AddAsync(rating);
            await Context.SaveChangesAsync();

            return rating;
        }

        public async Task<Rating> Update(Rating rating)
        {
            var result = Context.Ratings.First(x => x.RatingId == rating.RatingId);
            
            if (result != null)
            {
                result.RatingNumber = rating.RatingNumber;
                result.RatingGrade = rating.RatingGrade;
                await Context.SaveChangesAsync();
            }
            

            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var rating = new Rating()
            {
                RatingId = id,
            };
            Context.Ratings.Attach(rating);
            Context.Ratings.Remove(rating);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<Rating> GetById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.RatingId == id);
        }

        public async Task<List<Rating>> GetByProductId(int productId)
        {
            return await GetAll().Where(x => x.ProductId == productId).ToListAsync();
        }

        public IQueryable<Rating> GetAll()
        {
            return Context.Ratings.AsQueryable();
        }
    }
}