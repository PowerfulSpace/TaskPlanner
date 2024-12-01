using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTaskById
{
    public class GetWorkTaskByIdValidator : AbstractValidator<GetWorkTaskByIdQuery>
    {
        public GetWorkTaskByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("WorkTask ID is required.");
        }
    }
}
