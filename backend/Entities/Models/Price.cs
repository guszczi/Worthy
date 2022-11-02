using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities.Models
{
    public class Price
    {
        [Key]
        public int PriceId { get; set; }
        public DateTime PriceDate { get; set; }
        public double PriceValue { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}