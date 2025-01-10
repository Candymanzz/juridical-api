using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class ClientsValidator : AbstractValidator<ClientsEntities>
    {
        public ClientsValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(50).WithMessage("First Name cannot exceed 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(50).WithMessage("Last Name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.")
                .EmailAddress().WithMessage("Invalid email address format."); //Проверка формата email

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.  Please use international format (e.g., +15551234567)."); //Пример проверки формата телефона.  Модифицируйте регулярное выражение по необходимости.


            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(50).WithMessage("Address cannot exceed 50 characters.");
        }
    }
}
