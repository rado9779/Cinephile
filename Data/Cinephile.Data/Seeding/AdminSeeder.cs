namespace Cinephile.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Common;
    using Cinephile.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            if (dbContext.Users.Any(x => x.UserName == GlobalConstants.AdministratorUsername) == false)
            {
                var user = new ApplicationUser()
                {
                    UserName = GlobalConstants.AdministratorUsername,
                    Email = GlobalConstants.AdministratorEmail,
                };

                var password = GlobalConstants.AdministratorPassword;

                var result = await userManager.CreateAsync(user, password);
                await userManager.AddToRoleAsync(user, GlobalConstants.AdministratorRoleName);
            }
        }
    }
}
