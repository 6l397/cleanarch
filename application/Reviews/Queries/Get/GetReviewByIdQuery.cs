using MediatR;
using reviewservice.Application.Reviews.Dtos;

namespace reviewservice.Application.Reviews.Queries.Get
{
    public class GetReviewByIdQuery : IRequest<ReviewDto>  
    {
        public int ReviewId { get; set; }

        public GetReviewByIdQuery(int reviewId)
        {
            ReviewId = reviewId;
        }
    }
}
