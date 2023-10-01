using Microsoft.AspNetCore.Identity;

namespace TaskManagerSolution.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string CustomTag { get; set; }  // Just an example, you can add more properties
        // Foreign Key to your User in Shared models
        public int ApplicationUserId { get; set; }
    }
}
