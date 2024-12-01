using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAppUserById
{
    public class GetAppUserByIdValidator : AbstractValidator<GetAppUserByIdQuery>
    {
        public GetAppUserByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
