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
    public class LinkRepository : ILinkRepository
    {
        protected readonly AppDbContext Context;

        public LinkRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<Link> Add(LinkRequest linkRequest)
        {
            var link = new Link()
            {
                LinkUrl = linkRequest.LinkUrl,
                ProductId = linkRequest.ProductId,
                ShopId = linkRequest.ShopId,
            };

            await Context.Links.AddAsync(link);
            await Context.SaveChangesAsync();

            return link;
        }

        public async Task<Link> Update(Link link)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Link> GetById(int id)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.LinkId == id);
        }

        public async Task<List<Link>> GetByProductId(int productId)
        {
            return await GetAll().Where(x => x.ProductId == productId).ToListAsync();
        }

        public IQueryable<Link> GetAll()
        {
            return Context.Links.AsQueryable();
        }
    }
}