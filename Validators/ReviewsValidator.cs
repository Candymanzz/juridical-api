using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class ReviewsValidator : AbstractValidator<ReviewsEntities>
    {
        public ReviewsValidator()
        {
            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("Rating is required.")
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(50).WithMessage("Comment cannot exceed 50 characters.");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date is required.");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client ID is required.");

            RuleFor(x => x.LawyerId)
                .NotEmpty().WithMessage("Lawyer ID is required.");
        }
    }
}
