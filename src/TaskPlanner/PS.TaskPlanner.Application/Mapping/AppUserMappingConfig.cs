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
            // Настройка маппинга для UpdateAppUserCommand -> AppUser
            config.NewConfig<UpdateAppUserCommand, AppUser>()
                .IgnoreNullValues(true); // Игнорировать null, чтобы не затирать существующие значения


            config.NewConfig<AppUser, AppUserDto>()
                .IgnoreNullValues(true); // Игнорировать null, чтобы не затирать существующие значения

            //config.NewConfig<UpdateAppUserCommand, AppUser>()
            //    .Map(dest => dest.UserName, src => src.UserName)
            //    .Map(dest => dest.Email, src => src.Email)
            //    .Map(dest => dest.FullName, src => src.FullName)
            //    .Map(dest => dest.IsActive, src => src.IsActive)
            //    .Ignore(dest => dest.CreatedAt);
        }
    }
}
