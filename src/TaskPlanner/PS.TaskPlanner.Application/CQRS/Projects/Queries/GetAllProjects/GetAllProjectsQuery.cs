using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
    {
        // Без параметров, получение всех проектов
    }
}
