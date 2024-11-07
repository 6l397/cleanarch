using MediatR;
using System.Collections.Generic;
using reviewservice.Application.Reviews.Dtos;

namespace reviewservice.Application.Reviews.Queries.List
{
    public class GetAllReviewsQuery : IRequest<List<ReviewDto>>
    {
    }
}
