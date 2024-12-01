using MediatR;

namespace PS.TaskPlanner.Application.CQRS.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
