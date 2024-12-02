using Mapster;
using PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.CreateWorkTask;
using PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.UpdateWorkTask;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Mapping
{
    public class WorkTaskMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WorkTaskViewModel, UpdateWorkTaskCommand>()
                     .IgnoreNullValues(true);

            config.NewConfig<WorkTaskViewModel, CreateWorkTaskCommand>()
                    .IgnoreNullValues(true);
        }
    }
}
