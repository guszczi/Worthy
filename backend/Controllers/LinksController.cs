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
    public class LinksController : ControllerBase
    {
        private readonly ILinkService _linkService;
        private readonly IMapper _mapper;

        public LinksController(ILinkService linkService, IMapper mapper)
        {
            _linkService = linkService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLinks()
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var list = await _linkService.GetAllLinks();

            return Ok(list);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLink([FromBody] LinkRequest linkRequest)
        {
            if (!ModelState.IsValid) return new BadRequestObjectResult("Invalid payload");

            var link = await _linkService.AddLink(linkRequest);

            return Ok(link);
        }
    }
}