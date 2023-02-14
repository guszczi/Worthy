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
    public class LinkService : ILinkService
    {
        protected readonly ILinkRepository LinkRepository;
        protected readonly AppDbContext Context;

        public LinkService(ILinkRepository linkRepository, AppDbContext context)
        {
            LinkRepository = linkRepository;
            Context = context;
        }

        public async Task<Link> AddLink(LinkRequest link)
        {
            return await LinkRepository.Add(link);
        }

        public async Task<Link> UpdateLink(Link link)
        {
            return await LinkRepository.Update(link);
        }

        public async Task<bool> DeleteLink(int id)
        {
            return await LinkRepository.Delete(id);
        }

        public async Task<Link> GetLinkById(int linkId)
        {
            return await LinkRepository.GetById(linkId);
        }

        public async Task<List<Link>> GetAllLinks()
        {
            return await LinkRepository.GetAll().ToListAsync();
        }

        public async Task<List<Link>> GetLinksByProductId(int productId)
        {
            return await LinkRepository.GetByProductId(productId);
        }
    }
}