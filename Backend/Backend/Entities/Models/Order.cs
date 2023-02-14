using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int OrderNumber { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }
}