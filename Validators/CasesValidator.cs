using FluentValidation;
using juridical_api.Contracts;
using juridical_api.DTO;
using juridical_api.Models.Entities;
using juridical_api.Repository;

namespace juridical_api.Validators
{
    public class CasesValidator : AbstractValidator<CasesEntities>
    {
        public CasesValidator()
        {
            RuleFor(x => x.CaseName)
                .NotEmpty().WithMessage("Case Name is required.")
                .MaximumLength(30).WithMessage("Case Name cannot exceed 30 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(100).WithMessage("Description cannot exceed 100 characters.");

            RuleFor(x => x.OpeningDate)
                .NotEmpty().WithMessage("Opening Date is required.")
                .GreaterThanOrEqualTo(DateTime.MinValue).WithMessage("Opening Date must be a valid date.");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client ID is required.");

            RuleFor(x => x.LawyerId)
                .NotEmpty().WithMessage("Lawyer ID is required.");
        }
    }
}
