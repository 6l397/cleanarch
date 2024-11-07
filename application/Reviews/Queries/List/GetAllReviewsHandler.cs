using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using reviewservice.Application.Reviews.Dtos;
using domain;

namespace reviewservice.Application.Reviews.Queries.List
{
    public class GetAllReviewsHandler : IRequestHandler<GetAllReviewsQuery, List<ReviewDto>>
    {
        private readonly DogmateMarketplaceContext _context;

        public GetAllReviewsHandler(DogmateMarketplaceContext context)
        {
            _context = context;
        }

        public async Task<List<ReviewDto>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _context.Reviews
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return reviews.Select(review => new ReviewDto
            {
                ReviewId = review.ReviewId,
                Content = review.Content,
                Rating = review.Rating,
                ReviewDate = review.ReviewDate,
                SellerId = review.SellerId,
                ServiceId = review.ServiceId
            }).ToList();
        }
    }
}
