using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTasksByProjectId
{
    public class GetWorkTasksByProjectIdValidator : AbstractValidator<GetWorkTasksByProjectIdQuery>
    {
        public GetWorkTasksByProjectIdValidator()
        {
            RuleFor(x => x.ProjectId)
                .NotEmpty().WithMessage("Project ID is required.");
        }
    }
}
