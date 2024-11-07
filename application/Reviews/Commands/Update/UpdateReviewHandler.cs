using MediatR;
using domain;
using Microsoft.EntityFrameworkCore;

namespace reviewservice.Application.Reviews.Commands.Update
{
    public class UpdateReviewHandler : IRequestHandler<UpdateReviewCommand, Unit>
    {
        private readonly DogmateMarketplaceContext _context;

        public UpdateReviewHandler(DogmateMarketplaceContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.ReviewId == request.ReviewId, cancellationToken);
            if (review == null)
            {   
                throw new KeyNotFoundException($"Review with ID {request.ReviewId} not found.");
            }

            review.Content = request.Content;
            review.Rating = request.Rating;
            review.ReviewDate = request.ReviewDate ?? review.ReviewDate;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
