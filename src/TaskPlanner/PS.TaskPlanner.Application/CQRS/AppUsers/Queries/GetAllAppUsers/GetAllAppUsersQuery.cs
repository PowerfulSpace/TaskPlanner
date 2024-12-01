using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAllAppUsers
{
    public class GetAllAppUsersQuery : IRequest<IEnumerable<AppUser>>
    {
    }
}
