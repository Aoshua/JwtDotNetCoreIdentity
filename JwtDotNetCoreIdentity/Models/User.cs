using Microsoft.AspNetCore.Identity;

namespace JwtDotNetCoreIdentity.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
