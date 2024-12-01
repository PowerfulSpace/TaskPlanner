using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTasksByUserId
{
    public class GetWorkTasksByUserIdHandler : IRequestHandler<GetWorkTasksByUserIdQuery, IEnumerable<WorkTask>>
    {
        private readonly IWorkTaskRepository _workTaskRepository;

        public GetWorkTasksByUserIdHandler(IWorkTaskRepository workTaskRepository)
        {
            _workTaskRepository = workTaskRepository;
        }

        public async Task<IEnumerable<WorkTask>> Handle(GetWorkTasksByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _workTaskRepository.GetByUserIdAsync(request.UserId);
        }
    }
}
