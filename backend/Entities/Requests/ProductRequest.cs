namespace backend.Entities.Requests
{
    public class ProductRequest
    {
        public string ProductName { get; set; }
        public double ProductRating { get; set; }
        public int ProductNumberOfOrders { get; set; }
        public string ProductImageUrl { get; set; }
    }
}