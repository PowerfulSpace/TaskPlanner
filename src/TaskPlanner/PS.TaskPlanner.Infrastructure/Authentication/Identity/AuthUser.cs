using Microsoft.AspNetCore.Identity;

namespace PS.TaskPlanner.Infrastructure.Authentication.Identity
{
    public class AuthUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
