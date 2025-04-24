using Microsoft.AspNetCore.Identity;

namespace LabWork15.DataBase
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));

            var admin = new IdentityUser { UserName = "admin@test.com", Email = "admin@test.com" };
            var user = new IdentityUser { UserName = "user@test.com", Email = "user@test.com" };

            if (await userManager.FindByEmailAsync(admin.Email) == null)
            {
                await userManager.CreateAsync(admin, "Qwerty123!");
                await userManager.AddToRoleAsync(admin, "Admin");
            }

            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                await userManager.CreateAsync(user, "Qwerty123!");
                await userManager.AddToRoleAsync(user, "User");
            }
        }
    }
}
