using System.ComponentModel.DataAnnotations;

namespace backend.Entities.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        public string LinkUrl { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}