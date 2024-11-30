using Mapster;
using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Application.Dtos;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserHandler : IRequestHandler<UpdateAppUserCommand, AppUserDto>
    {
        private readonly IAppUserRepository _appUserRepository;

        public UpdateAppUserHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<AppUserDto> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            // Получение пользователя из базы данных
            var user = await _appUserRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.Id} not found.");
            }

            // Маппинг командных данных на сущность
            request.Adapt(user);

            // Сохранение изменений
            await _appUserRepository.UpdateAsync(user);

            return user.Adapt<AppUserDto>();
        }
    }
}
