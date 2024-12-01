using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAppUserById
{
    public class GetAppUserByIdHandler : IRequestHandler<GetAppUserByIdQuery, AppUser?>
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetAppUserByIdHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<AppUser?> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _appUserRepository.GetByIdAsync(request.Id);
            return user; // Возвращаем пользователя (или null, если не найден)
        }
    }
}
