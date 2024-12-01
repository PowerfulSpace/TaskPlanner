using Mapster;
using PS.TaskPlanner.Application.CQRS.Projects.Commands.CreateProject;
using PS.TaskPlanner.Application.CQRS.Projects.Commands.UpdateProject;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Mapping
{
    public class ProjectMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateProjectCommand, Project>()
                 .IgnoreNullValues(true);

            config.NewConfig<CreateProjectCommand, Project>()
                .IgnoreNullValues(true);
        }
    }
}
