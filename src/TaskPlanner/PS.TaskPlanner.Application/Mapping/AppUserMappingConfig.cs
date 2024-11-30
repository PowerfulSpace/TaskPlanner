using Mapster;
using PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser;
using PS.TaskPlanner.Application.Dtos;
using PS.TaskPlanner.Domain.Entities;

namespace PS.TaskPlanner.Application.Mapping
{
    public class AppUserMappingConfig : IRegister
    {
        //public void Register(TypeAdapterConfig config)
        //{
        //    config.NewConfig<UpdateAppUserCommand, AppUser>()
        //        .Map(dest => dest.UserName, src => src.UserName) // Полное имя - пока используем имя пользователя (можно расширить)
        //        .Map(dest => dest.CreatedAt, src => src.CreatedAt); // Дата создания пользователя
        //}

        public void Register(TypeAdapterConfig config)
        {
            // Настройка маппинга для UpdateAppUserCommand -> AppUser
            config.NewConfig<UpdateAppUserCommand, AppUser>()
                .IgnoreNullValues(true); // Игнорировать null, чтобы не затирать существующие значения


            config.NewConfig<AppUser, AppUserDto>()
                .IgnoreNullValues(true); // Игнорировать null, чтобы не затирать существующие значения

        }
    }
}
