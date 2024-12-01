using Mapster;
using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.UpdateWorkTask
{
    public class UpdateWorkTaskHandler : IRequestHandler<UpdateWorkTaskCommand, WorkTask>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public UpdateWorkTaskHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<WorkTask> Handle(UpdateWorkTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _workTaskRepository.GetByIdAsync(request.Id);

            if (task == null)
            {
                throw new KeyNotFoundException($"WorkTask with ID {request.Id} not found.");
            }

            request.Adapt(task);

            await _workTaskRepository.UpdateAsync(task);

            return task;
        }
    }
}
