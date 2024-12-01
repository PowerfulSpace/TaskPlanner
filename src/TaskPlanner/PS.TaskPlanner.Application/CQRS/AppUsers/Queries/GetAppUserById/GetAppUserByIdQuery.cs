using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAppUserById
{
    public class GetAppUserByIdQuery : IRequest<AppUser?>
    {
        public Guid Id { get; set; } // ID пользователя
    }
}
