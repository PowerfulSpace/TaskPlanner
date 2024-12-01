using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAppUserByEmail
{
    public class GetAppUserByEmailValidator : AbstractValidator<GetAppUserByEmailQuery>
    {
        public GetAppUserByEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
