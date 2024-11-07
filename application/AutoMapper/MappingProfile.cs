using AutoMapper;
using reviewservice.Application.Reviews.Dtos;
using domain.Entities;
using reviewservice.Application.Reviews.Commands.Update;
using application.Reviews.Commands.Create;

namespace application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CreateReviewCommand, Review>()
                .ForMember(dest => dest.ReviewId, opt => opt.Ignore())
                .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<UpdateReviewCommand, Review>();
            CreateMap<Review, ReviewDto>();

            CreateMap<Review, ReviewDto>();
        }
    }
}
