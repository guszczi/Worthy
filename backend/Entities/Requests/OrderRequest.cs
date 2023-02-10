namespace backend.Entities.Requests
{
    public class OrderRequest
    {
        public int OrderNumber { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}