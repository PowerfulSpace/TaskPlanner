using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTasksByUserId
{
    public class GetWorkTasksByUserIdValidator : AbstractValidator<GetWorkTasksByUserIdQuery>
    {
        public GetWorkTasksByUserIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
