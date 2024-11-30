using Mapster;
using PS.TaskPlanner.Application.Dtos;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Mapping
{
    public class ProjectMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Project, ProjectDto>()
                .Map(dest => dest.OwnerName, src => src.Owner != null ? src.Owner.UserName : string.Empty) // Имя владельца
                .Map(dest => dest.Tasks, src => src.Tasks.Adapt<List<WorkTaskDto>>()); // Преобразование задач в список WorkTaskDto
        }
    }
}
