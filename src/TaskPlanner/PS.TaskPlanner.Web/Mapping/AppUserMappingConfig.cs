using Mapster;
using PS.TaskPlanner.Application.CQRS.AppUsers.Commands.UpdateAppUser;
using PS.TaskPlanner.Web.Models;

namespace PS.TaskPlanner.Web.Mapping
{
    public class AppUserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AppUserViewModel, UpdateAppUserCommand>()
               .IgnoreNullValues(true);
        }
    }
}
