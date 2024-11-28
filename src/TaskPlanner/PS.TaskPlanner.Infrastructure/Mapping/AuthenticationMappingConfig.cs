using Mapster;
using PS.TaskPlanner.Domain.Entities;
using PS.TaskPlanner.Infrastructure.Authentication.Identity;

namespace PS.TaskPlanner.Infrastructure.Mapping
{
    public static class AuthenticationMappingConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<AuthUser, AppUser>.NewConfig()
                .Map(dest => dest.Id, src => Guid.Parse(src.Id))
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email);

            TypeAdapterConfig<AppUser, AuthUser>.NewConfig()
                .Map(dest => dest.Id, src => src.Id.ToString())
                .Map(dest => dest.UserName, src => src.UserName)
                .Map(dest => dest.Email, src => src.Email);
        }
    }
}
