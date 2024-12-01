using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetAllWorkTasks
{
    public class GetAllWorkTasksQuery : IRequest<IEnumerable<WorkTask>>
    {
    }
}
