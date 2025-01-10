using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class DocumentsValidator : AbstractValidator<DocumentsEntities>
    {
        public DocumentsValidator()
        {
            RuleFor(x => x.DocumentName)
                .NotEmpty().WithMessage("Document name is required.")
                .MaximumLength(50).WithMessage("Document name cannot exceed 50 characters.");

            RuleFor(x => x.CreationDate)
                .NotEmpty().WithMessage("Creation date is required.");

            RuleFor(x => x.DocumentType)
                .NotEmpty().WithMessage("Document type is required.")
                .MaximumLength(25).WithMessage("Document type cannot exceed 25 characters.");

            RuleFor(x => x.DocumentText)
                .NotEmpty().WithMessage("Document text is required.")
                .MaximumLength(100).WithMessage("Document text cannot exceed 100 characters.");

            RuleFor(x => x.CaseId)
                .NotEmpty().WithMessage("Case ID is required.");
        }
    }
}
