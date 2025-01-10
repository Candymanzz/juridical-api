using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class LawyersValidator : AbstractValidator<LawyersEntities>
    {
        public LawyersValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

            RuleFor(x => x.Specialization)
                .NotEmpty().WithMessage("Specialization is required.")
                .MaximumLength(25).WithMessage("Specialization cannot exceed 25 characters.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.  Example: +15551234567");


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
