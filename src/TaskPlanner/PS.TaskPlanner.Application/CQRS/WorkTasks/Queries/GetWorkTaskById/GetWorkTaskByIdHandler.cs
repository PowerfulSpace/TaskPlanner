using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTaskById
{
    public class GetWorkTaskByIdHandler : IRequestHandler<GetWorkTaskByIdQuery, WorkTask?>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public GetWorkTaskByIdHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<WorkTask?> Handle(GetWorkTaskByIdQuery request, CancellationToken cancellationToken)
        {
            return await _workTaskRepository.GetByIdAsync(request.Id);
        }
    }
}
