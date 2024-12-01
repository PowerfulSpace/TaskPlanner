using MediatR;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommand : IRequest<AppUser>
    {
        public Guid Id { get; set; } // ID пользователя
        public string UserName { get; set; } = string.Empty; // Имя пользователя
        public string Email { get; set; } = string.Empty; // Email пользователя
        public bool IsActive { get; set; } // Статус активности
    }
}
