using Mapster;
using PS.TaskPlanner.Application.Dtos;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Mapping
{
    public class WorkTaskMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<WorkTask, WorkTaskDto>()
                .Map(dest => dest.Status, src => src.Status.ToString()) // Конвертация статуса в строку
                .Map(dest => dest.Priority, src => src.Priority.ToString()) // Конвертация приоритета в строку
                .Map(dest => dest.AssignedToUserName, src => src.AssignedToUser != null ? src.AssignedToUser.UserName : null)
                .Map(dest => dest.ProjectTitle, src => src.Project != null ? src.Project.Title : string.Empty);
        }
    }
}
