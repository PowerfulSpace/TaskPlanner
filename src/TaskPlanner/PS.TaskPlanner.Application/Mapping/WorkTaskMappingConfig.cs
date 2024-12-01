using Mapster;
using PS.TaskPlanner.Application.CQRS.WorkTasks.Commands.UpdateWorkTask;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Mapping
{
    public class WorkTaskMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateWorkTaskCommand, WorkTask>()
                     .IgnoreNullValues(true);
        }
    }
}
