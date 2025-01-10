using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class PaymentsValidator : AbstractValidator<PaymentsEntities>
    {
        public PaymentsValidator()
        {
            RuleFor(x => x.PaymentDate)
                .NotEmpty().WithMessage("Payment date is required.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount is required.")
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required.")
                .MaximumLength(20).WithMessage("Payment method cannot exceed 20 characters.");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client ID is required.");

            RuleFor(x => x.CaseId)
                .NotEmpty().WithMessage("Case ID is required.");
        }
    }
}
