using MediatR;

namespace reviewservice.Application.Reviews.Commands.Delete
{
    public class DeleteReviewCommand : IRequest<Unit>
    {
        public int ReviewId { get; }

        public DeleteReviewCommand(int reviewId)
        {
            ReviewId = reviewId;
        }
    }
}
