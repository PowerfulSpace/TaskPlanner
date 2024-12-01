using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Queries.GetAllAppUsers
{
    public class GetAllAppUsersHandler : IRequestHandler<GetAllAppUsersQuery, IEnumerable<AppUser>>
    {
        private readonly IAppUserRepository _appUserRepository;

        public GetAllAppUsersHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<IEnumerable<AppUser>> Handle(GetAllAppUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _appUserRepository.GetAllAsync();
            return users; // Возвращаем всех пользователей
        }
    }
}
