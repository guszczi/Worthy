using System.ComponentModel.DataAnnotations;

namespace backend.Entities.Models
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }
        public string ShopName { get; set; }
    }
}