using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public enum UserType : byte
    {
        Normal = 1,
        Super = 2
    }
    public class AppUser : IdentityUser<Guid>
    {
        public string? City { get; set; }
        public UserType UserType { get; set; }
    }
}
