using System.ComponentModel.DataAnnotations;

namespace backend.Entities.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public int RatingNumber { get; set; }
        public double RatingGrade { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}