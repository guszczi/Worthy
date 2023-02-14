using System;

namespace backend.Entities.Requests
{
    public class PriceRequest
    {
        public double PriceValue { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}