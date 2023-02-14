using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Entities.Models;
using backend.Entities.Requests;

namespace backend.Entities.Services.IServices
{
    public interface ILinkService
    {
        public Task<Link> AddLink(LinkRequest link);
        public Task<Link> UpdateLink(Link link);
        public Task<bool> DeleteLink(int id);
        public Task<Link> GetLinkById(int linkId);
        public Task<List<Link>> GetAllLinks();
        public Task<List<Link>> GetLinksByProductId(int productId);
    }
}