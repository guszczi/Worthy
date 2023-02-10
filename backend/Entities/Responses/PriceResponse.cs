using System;

namespace backend.Entities.Responses
{
    public class PriceResponse
    {
        public DateTime PriceDate { get; set; }
        public double PriceValue { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}