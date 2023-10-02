using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerSolution.Shared.Models
{
    public class UserCredentials
    {
        [Key]  // Make sure to add this annotation
        public int UserCredentialsId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
    }

}
