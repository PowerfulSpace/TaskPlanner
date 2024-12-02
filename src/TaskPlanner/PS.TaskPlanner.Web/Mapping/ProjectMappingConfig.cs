using Mapster;
using PS.TaskPlanner.Application.CQRS.Projects.Commands.CreateProject;
using PS.TaskPlanner.Application.CQRS.Projects.Commands.UpdateProject;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Mapping
{
    public class ProjectMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ProjectViewModel, UpdateProjectCommand>()
                .IgnoreNullValues(true);

            config.NewConfig<ProjectViewModel, CreateProjectCommand>()
                .IgnoreNullValues(true);
        }
    }
}
