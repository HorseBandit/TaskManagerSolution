
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerSolution.Server.Data;
using TaskManagerSolution.Server.Models; // Your namespace for ApplicationUser
namespace TaskManagerSolution.Server.Configuration
{ 
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}