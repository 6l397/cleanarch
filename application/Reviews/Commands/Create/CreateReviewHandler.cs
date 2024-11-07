using application.Reviews.Commands.Create;
using domain;
using domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace application.Reviews.Commands.Create
{
    public class CreateReviewHandler : IRequestHandler<CreateReviewCommand, int>
    {
        private readonly DogmateMarketplaceContext _context;

        public CreateReviewHandler(DogmateMarketplaceContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var review = new Review
            {
                Content = request.Content,
                Rating = request.Rating,
                ReviewDate = request.ReviewDate ?? DateTime.Now,
                SellerId = request.SellerId,
                ServiceId = request.ServiceId
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync(cancellationToken);

            return review.ReviewId;
        }
    }
}
