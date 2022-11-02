using System;

namespace backend.Entities.Requests
{
    public class PriceRequest
    {
        public DateTime PriceDate { get; set; }
        public int PriceValue { get; set; }
        public int ProductId { get; set; }
    }
}