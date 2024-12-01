using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.CreateWorkTask
{
    public class CreateWorkTaskValidator : AbstractValidator<CreateWorkTaskCommand>
    {
        public CreateWorkTaskValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid task status.");

            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("Invalid task priority.");

            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Project ID is required.");
        }
    }
}
