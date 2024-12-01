using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAppUserByEmail
{
    public class GetAppUserByEmailHandler : IRequestHandler<GetAppUserByEmailQuery, AppUser?>
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetAppUserByEmailHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<AppUser?> Handle(GetAppUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _appUserRepository.GetByEmailAsync(request.Email);
            return user; // Возвращаем пользователя (или null, если не найден)
        }
    }
}
