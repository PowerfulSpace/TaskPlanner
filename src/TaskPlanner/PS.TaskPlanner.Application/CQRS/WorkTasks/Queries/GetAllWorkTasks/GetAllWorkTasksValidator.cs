using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.WorkTasks.Queries.GetAllWorkTasks
{
    public class GetWorkTaskByIdQuery : IRequest<WorkTask?>
    {
        public Guid Id { get; set; }
    }
}
