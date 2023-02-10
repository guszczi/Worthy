namespace backend.Entities.Responses
{
    public class RatingResponse
    {
        public int RatingNumber { get; set; }
        public double RatingGrade { get; set; }
        public int ProductId { get; set; }
        public int ShopId { get; set; }
    }
}