using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Infrastructure.ESX.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { Name="Admin",  UserName = "admin@gmail.com", Email = "admin@gmail.com" };
            await userManager.CreateAsync(defaultUser, "Pass@word1");
        }
    }
}
