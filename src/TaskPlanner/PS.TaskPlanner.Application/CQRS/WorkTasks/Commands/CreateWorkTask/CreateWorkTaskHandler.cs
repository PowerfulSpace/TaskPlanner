using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.CreateWorkTask
{
    public class CreateWorkTaskHandler : IRequestHandler<CreateWorkTaskCommand, WorkTask>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public CreateWorkTaskHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<WorkTask> Handle(CreateWorkTaskCommand request, CancellationToken cancellationToken)
        {
            var workTask = new WorkTask
            {
                Title = request.Title,
                Description = request.Description,
                Status = request.Status,
                Priority = request.Priority,
                DueDate = request.DueDate,
                AssignedToUserId = request.AssignedToUserId,
                ProjectId = request.ProjectId
            };

            await _workTaskRepository.AddAsync(workTask);

            return workTask;
        }
    }
}
