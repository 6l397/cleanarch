using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using reviewservice.Application.Reviews.Dtos;
using domain;

namespace reviewservice.Application.Reviews.Queries.Get
{
    public class GetReviewByIdHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto> 
    {
        private readonly DogmateMarketplaceContext _context;

        public GetReviewByIdHandler(DogmateMarketplaceContext context)
        {
            _context = context;
        }

        public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.ReviewId == request.ReviewId, cancellationToken);

            if (review == null)
            {
                throw new KeyNotFoundException("Review not found");
            }

            return new ReviewDto
            {
                ReviewId = review.ReviewId,
                Content = review.Content,
                Rating = review.Rating,
                ReviewDate = review.ReviewDate,
                SellerId = review.SellerId,
                ServiceId = review.ServiceId
            };
        }
    }
}
