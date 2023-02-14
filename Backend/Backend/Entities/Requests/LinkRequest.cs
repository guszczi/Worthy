namespace backend.Entities.Requests
{
    public class LinkRequest
    {
        public string LinkUrl { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}