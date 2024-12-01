using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetWorkTaskById
{
    public class GetWorkTaskByIdQuery : IRequest<WorkTask?>
    {
        public Guid Id { get; set; }
    }
}
