using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTasksByUserId
{
    public class GetWorkTasksByUserIdQuery : IRequest<IEnumerable<WorkTask>>
    {
        public Guid UserId { get; set; }
    }
}
