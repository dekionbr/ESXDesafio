using Microsoft.AspNetCore.Identity;

namespace Infrastructure.ESX.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
