using Mapster;
using PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser;
using PS.TaskPlanner.Application.Dtos;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Mapping
{
    public class AppUserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UpdateAppUserCommand, AppUser>()
                .IgnoreNullValues(true)
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.IsActive, src => src.IsActive);

            //config.NewConfig<AppUser, AppUserDto>()
            //    .IgnoreNullValues(true)
            //    .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            //    .Map(dest => dest.IsActive, src => src.IsActive);  // Добавляем маппинг для IsActive
        }
    }
}
