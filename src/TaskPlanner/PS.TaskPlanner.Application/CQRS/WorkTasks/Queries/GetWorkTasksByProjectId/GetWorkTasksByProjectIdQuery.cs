using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTasksByProjectId
{
    public class GetWorkTasksByProjectIdQuery : IRequest<IEnumerable<WorkTask>>
    {
        public Guid ProjectId { get; set; }
    }
}
