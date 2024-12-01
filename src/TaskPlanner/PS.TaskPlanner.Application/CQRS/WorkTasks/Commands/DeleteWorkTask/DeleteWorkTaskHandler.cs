using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.DeleteWorkTask
{
    public class DeleteWorkTaskHandler : IRequestHandler<DeleteWorkTaskCommand, Unit>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public DeleteWorkTaskHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<Unit> Handle(DeleteWorkTaskCommand request, CancellationToken cancellationToken)
        {
            await _workTaskRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
