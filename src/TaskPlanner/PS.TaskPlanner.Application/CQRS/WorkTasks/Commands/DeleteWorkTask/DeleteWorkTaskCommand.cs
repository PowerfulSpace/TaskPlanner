using MediatR;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
