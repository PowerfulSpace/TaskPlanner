using Mapster;
using PS.TaskPlanner.Application.Dtos;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Mapping
{
    public class AppUserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AppUser, AppUserDto>()
                .Map(dest => dest.FullName, src => src.UserName) // Полное имя - пока используем имя пользователя (можно расширить)
                .Map(dest => dest.IsActive, src => true) // Для примера ставим true, можно подключить логику активности
                .Map(dest => dest.CreatedAt, src => src.CreatedAt); // Дата создания пользователя
        }
    }
}
