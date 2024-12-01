using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAppUserByEmail
{
    public class GetAppUserByEmailQuery : IRequest<AppUser?>
    {
        public string Email { get; set; } = string.Empty; // Email пользователя
    }
}
