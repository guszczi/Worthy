using System.ComponentModel.DataAnnotations;

namespace backend.Entities.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductRating { get; set; }
        public int ProductNumberOfOrders { get; set; }
        public string ProductImageUrl { get; set; }
    }
}