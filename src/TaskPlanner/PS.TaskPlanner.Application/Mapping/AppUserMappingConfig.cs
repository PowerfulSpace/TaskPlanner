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
                .IgnoreNullValues(true) // Игнорировать null, чтобы не затирать существующие значения
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email)
                .Map(dest => dest.FullName, src => src.FullName);  // Маппим FullName в DTO

            config.NewConfig<AppUser, AppUserDto>()
                .IgnoreNullValues(true) // Игнорировать null, чтобы не затирать существующие значения
                .Map(dest => dest.CreatedAt, src => src.CreatedAt);


            //config.NewConfig<UpdateAppUserCommand, AppUser>()
            //    .Map(dest => dest.UserName, src => src.UserName)
            //    .Map(dest => dest.Email, src => src.Email)
            //    .Map(dest => dest.FullName, src => src.FullName)
            //    .Map(dest => dest.IsActive, src => src.IsActive)
            //    .Ignore(dest => dest.CreatedAt);
        }
    }
}
