using MediatR;
using PS.TaskPlanner.Application.Dtos;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommand : IRequest<AppUserDto>
    {
        public Guid Id { get; set; } // ID пользователя
        public string UserName { get; set; } = string.Empty; // Имя пользователя
        public string Email { get; set; } = string.Empty; // Email пользователя
        public string FullName { get; set; } = string.Empty; // Полное имя
        public bool IsActive { get; set; } // Статус активности
    }
}
