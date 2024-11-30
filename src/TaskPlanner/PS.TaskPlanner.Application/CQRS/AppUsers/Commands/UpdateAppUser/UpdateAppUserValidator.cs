using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserValidator : AbstractValidator<UpdateAppUserCommand>
    {
        public UpdateAppUserValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name is required.")
                .MaximumLength(50).WithMessage("User name cannot exceed 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.FullName)
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters.");

            RuleFor(x => x.IsActive)
                .NotNull().WithMessage("Active status must be specified.");
        }
    }
}
