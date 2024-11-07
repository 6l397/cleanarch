using MediatR;
using Microsoft.AspNetCore.Mvc;
using application.Reviews.Commands.Create;
using reviewservice.Application.Reviews.Commands.Delete;
using reviewservice.Application.Reviews.Commands.Update;
using reviewservice.Application.Reviews.Dtos;
using reviewservice.Application.Reviews.Queries.Get;
using reviewservice.Application.Reviews.Queries.List;

namespace reviewservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<ReviewDto>>> GetAllReviews()
        {
            var query = new GetAllReviewsQuery();
            var reviews = await _mediator.Send(query);
            return Ok(reviews);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int id)
        {
            var query = new GetReviewByIdQuery(id);
            var review = await _mediator.Send(query);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }


        [HttpPost]
        public async Task<ActionResult<int>> CreateReview(CreateReviewCommand command)
        {
            var reviewId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetReviewById), new { id = reviewId }, reviewId);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, UpdateReviewCommand command)
        {
            if (id != command.ReviewId)
            {
                return BadRequest("Review ID mismatch.");
            }

            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var command = new DeleteReviewCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
