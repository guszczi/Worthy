namespace backend.Entities.Requests
{
    public class RatingRequest
    {
        public int RatingNumber { get; set; }
        public double RatingGrade { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}