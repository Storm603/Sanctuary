using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sanctuary.Common;
using Sanctuary.Data.Models.Configurable;

namespace Sanctuary.Data.Seeding
{
    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            await SeedRoleAsync(roleManager);
        }

        private static async Task SeedRoleAsync(RoleManager<ApplicationRole> roleManager)
        {
            var roleList = typeof(ExistingIdentityRolesConstants).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var roleField in roleList)
            {
                var roleName = roleField.GetValue(typeof(ExistingIdentityRolesConstants))!.ToString()!;

                var roleResult =  await roleManager.FindByNameAsync(roleName);

                if (roleResult == null)
                {
                    var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                    if (!result.Succeeded)
                    {
                        throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                    }
                }
            }
        }
    }
}
