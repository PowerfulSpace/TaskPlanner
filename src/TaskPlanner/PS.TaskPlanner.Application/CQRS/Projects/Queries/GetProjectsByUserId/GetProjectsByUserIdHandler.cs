using MediatR;
using PS.TaskPlanner.Application.Common.Interfaces.Persistence;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.CQRS.Projects.Queries.GetProjectsByUserId
{
    public class GetProjectsByUserIdHandler : IRequestHandler<GetProjectsByUserIdQuery, IEnumerable<Project>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectsByUserIdHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<Project>> Handle(GetProjectsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _projectRepository.GetByUserIdAsync(request.UserId);
        }
    }
}
