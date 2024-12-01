using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<Project?>
    {
        public Guid Id { get; set; } // ID проекта
    }
}
