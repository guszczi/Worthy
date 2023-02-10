namespace backend.Entities.Requests
{
    public class ScraperRequest
    {
        public string Url { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}