using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagerSolution.Server.Models;
using TaskManagerSolution.Shared.Models;

namespace TaskManagerSolution.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskToDo> Tasks { get; set; }
        public DbSet<Squad> Squads { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}