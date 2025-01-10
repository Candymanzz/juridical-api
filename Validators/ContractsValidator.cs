using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class ContractsValidator : AbstractValidator<ContractsEntities>
    {
        public ContractsValidator()
        {
            RuleFor(x => x.SigningDate)
                .NotEmpty().WithMessage("Signing date is required.")
                .LessThan(x => x.ExpirationDate).WithMessage("Signing date must be before expiration date.");

            RuleFor(x => x.ExpirationDate)
                .NotEmpty().WithMessage("Expiration date is required.")
                .GreaterThan(x => x.SigningDate).WithMessage("Expiration date must be after signing date.");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client ID is required.");

            RuleFor(x => x.LawyerId)
                .NotEmpty().WithMessage("Lawyer ID is required.");
        }
    }
}
