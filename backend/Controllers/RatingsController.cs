using System.Threading.Tasks;
using AutoMapper;
using backend.Entities.Models;
using backend.Entities.Requests;
using backend.Entities.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;

        public RatingsController(IRatingService ratingService, IMapper mapper)
        {
            _ratingService = ratingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var list = await _ratingService.GetAllRatings();

            return Ok(list);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddRating([FromBody] RatingRequest ratingRequest)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var rating = await _ratingService.AddRating(ratingRequest);

            return Ok(ratingRequest);
        }
        
        [HttpPut]
        [Route("{ratingId:int}")]
        public async Task<IActionResult> UpdateRating([FromBody] RatingRequest ratingRequest, int ratingId)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var rating = new Rating()
            {
                RatingId = ratingId,
                RatingNumber = ratingRequest.RatingNumber,
                RatingGrade = ratingRequest.RatingGrade,
            };

            await _ratingService.UpdateRating(rating);

            return Ok(rating);
        }

        [HttpDelete]
        [Route("{ratingId:int}")]
        public async Task<IActionResult> DeleteRating(int ratingId)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            await _ratingService.DeleteRating(ratingId);

            return Ok(true);
        }
        
    }
}