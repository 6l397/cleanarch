using MediatR;

namespace application.Reviews.Commands.Create
{
    public class CreateReviewCommand : IRequest<int>  
    {
        public string Content { get; set; } = null!;
        public int? Rating { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? SellerId { get; set; }
        public int? ServiceId { get; set; }

    }
}
