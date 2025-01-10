using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class CourtHearingsValidator : AbstractValidator<CourtHearingsEntities>
    {
        public CourtHearingsValidator()
        {
            RuleFor(x => x.HearingDate)
                .NotEmpty().WithMessage("Hearing date is required.");

            RuleFor(x => x.Place)
                .NotEmpty().WithMessage("Place is required.")
                .MaximumLength(50).WithMessage("Place cannot exceed 50 characters.");

            RuleFor(x => x.CaseId)
                .NotEmpty().WithMessage("Case ID is required.");
        }
    }
}
