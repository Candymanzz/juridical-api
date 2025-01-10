using FluentValidation;
using juridical_api.Models.Entities;

namespace juridical_api.Validators
{
    public class TasksValidator : AbstractValidator<TasksEntities>
    {
        public TasksValidator()
        {
            RuleFor(x => x.TaskDescription)
                .NotEmpty().WithMessage("Task description is required.")
                .MaximumLength(50).WithMessage("Task description cannot exceed 50 characters.");

            RuleFor(x => x.DateOfCompletion)
                .NotEmpty().WithMessage("Date of completion is required.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required.");

            RuleFor(x => x.CaseId)
                .NotEmpty().WithMessage("Case ID is required.");

            RuleFor(x => x.LawyerId)
                .NotEmpty().WithMessage("Lawyer ID is required.");
        }
    }
}
