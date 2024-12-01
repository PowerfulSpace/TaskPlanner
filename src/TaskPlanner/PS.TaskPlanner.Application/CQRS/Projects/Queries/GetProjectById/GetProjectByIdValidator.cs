using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.Projects.Queries.GetProjectById
{
    public class GetProjectByIdValidator : AbstractValidator<GetProjectByIdQuery>
    {
        public GetProjectByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Project ID is required.");
        }
    }
}
