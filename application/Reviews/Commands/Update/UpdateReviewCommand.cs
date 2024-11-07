using MediatR;

namespace reviewservice.Application.Reviews.Commands.Update
{
    public class UpdateReviewCommand : IRequest<Unit>
    {
        public int ReviewId { get; set; }
        public string Content { get; set; } = null!;
        public int? Rating { get; set; }
        public DateTime? ReviewDate { get; set; }
        public UpdateReviewCommand(int reviewId, string content, int? rating, DateTime? reviewDate) {
        
            ReviewId = reviewId;
            Content = content;
            Rating = rating;
            ReviewDate = reviewDate;

        }
    }
}
