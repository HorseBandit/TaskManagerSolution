
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerSolution.Server.Data;
using TaskManagerSolution.Server.Models;
using TaskManagerSolution.Shared.Models; // Make sure this matches the namespace of your ApplicationUser

namespace TaskManagerSolution.Server.Configuration
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();
        }
    }
}

