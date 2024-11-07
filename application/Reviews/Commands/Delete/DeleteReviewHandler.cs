using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using domain;

namespace reviewservice.Application.Reviews.Commands.Delete
{
    public class DeleteReviewHandler : IRequestHandler<DeleteReviewCommand, Unit>  
    {
        private readonly DogmateMarketplaceContext _context;

        public DeleteReviewHandler(DogmateMarketplaceContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.ReviewId == request.ReviewId, cancellationToken);
            if (review == null)
            {
                throw new KeyNotFoundException($"Review with ID {request.ReviewId} not found.");
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
