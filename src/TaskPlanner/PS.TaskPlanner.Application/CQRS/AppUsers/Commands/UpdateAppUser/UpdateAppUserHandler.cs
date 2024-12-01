using Mapster;
using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserHandler : IRequestHandler<UpdateAppUserCommand, AppUser>
    {
        private readonly IAppUserRepository _appUserRepository;

        public UpdateAppUserHandler(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public async Task<AppUser> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _appUserRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {request.Id} not found.");
            }

            request.Adapt(user);

            await _appUserRepository.UpdateAsync(user);

            return user;

        }
    }
}
