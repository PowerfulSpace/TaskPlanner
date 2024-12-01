using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTasksByProjectId
{
    public class GetWorkTasksByProjectIdHandler : IRequestHandler<GetWorkTasksByProjectIdQuery, IEnumerable<WorkTask>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public GetWorkTasksByProjectIdHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<IEnumerable<WorkTask>> Handle(GetWorkTasksByProjectIdQuery request, CancellationToken cancellationToken)
        {
            return await _workTaskRepository.GetByProjectIdAsync(request.ProjectId);
        }
    }
}
