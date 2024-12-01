using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.Projects.Commands.CreateProject
{
    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Project title is required.")
                .MaximumLength(100).WithMessage("Project title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate.GetValueOrDefault(DateTime.MaxValue))
                .WithMessage("Start date must be before the end date.");
        }
    }
}
