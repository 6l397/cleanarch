using FluentValidation;

namespace reviewservice.Application.Reviews.Dtos.Validators
{
    public class ReviewDtoValidator : AbstractValidator<ReviewDto>
    {
        public ReviewDtoValidator()
        {
            RuleFor(review => review.Content)
                 .NotEmpty().WithMessage("Необхідний вміст.")
                 .Length(1, 500).WithMessage("Вміст має бути від 1 до 500 символів.");

            RuleFor(review => review.Rating)
                .InclusiveBetween(1, 5).WithMessage("Рейтинг має бути від 1 до 5.");

            RuleFor(review => review.ReviewDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Дата відгуки неправильна");

            RuleFor(review => review.SellerId)
                .NotNull().WithMessage("Потрібно вказати ідентифікатор продавця.");

            RuleFor(review => review.ServiceId)
                .NotNull().WithMessage("Потрібно вказати ідентифікатор послуги.");
        }
    }
}
