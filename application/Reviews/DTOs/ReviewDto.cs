namespace reviewservice.Application.Reviews.Dtos
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public string Content { get; set; } = null!;
        public int? Rating { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? SellerId { get; set; }
        public int? ServiceId { get; set; }
    }
}
