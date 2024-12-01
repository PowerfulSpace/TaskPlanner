using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.Projects.Queries.GetProjectsByUserId
{
    public class GetProjectsByUserIdQuery : IRequest<IEnumerable<Project>>
    {
        public Guid UserId { get; set; } // ID пользователя
    }
}
