using FluentValidation;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskValidator : AbstractValidator<DeleteWorkTaskCommand>
    {
        public DeleteWorkTaskValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("WorkTask ID is required.");
        }
    }
}
