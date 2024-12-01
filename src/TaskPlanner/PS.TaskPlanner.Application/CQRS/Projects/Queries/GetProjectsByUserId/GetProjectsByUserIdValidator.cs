using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.Projects.Queries.GetProjectsByUserId
{
    public class GetProjectsByUserIdValidator : AbstractValidator<GetProjectsByUserIdQuery>
    {
        public GetProjectsByUserIdValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
