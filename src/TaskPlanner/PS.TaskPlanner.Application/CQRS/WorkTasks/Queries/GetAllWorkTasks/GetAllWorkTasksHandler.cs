using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetAllWorkTasks
{
    public class GetAllWorkTasksHandler : IRequestHandler<GetAllWorkTasksQuery, IEnumerable<WorkTask>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public GetAllWorkTasksHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<IEnumerable<WorkTask>> Handle(GetAllWorkTasksQuery request, CancellationToken cancellationToken)
        {
            return await _workTaskRepository.GetAllAsync();
        }
    }
}
