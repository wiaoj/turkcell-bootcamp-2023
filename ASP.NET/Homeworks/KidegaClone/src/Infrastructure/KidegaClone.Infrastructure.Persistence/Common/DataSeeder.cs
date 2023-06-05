using KidegaClone.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace KidegaClone.Infrastructure.Persistence.Common;
public static class DataSeeder {
    public static async void SeedData(UserManager<UserEntity> userManager, RoleManager<IdentityRole> roleManager) {
        await createRoleIfNotExistsAsync(roleManager, "Admin");
        await createRoleIfNotExistsAsync(roleManager, "User");
        await createUserIfNotExistsAsync(userManager, "admin");
        await createUserIfNotExistsAsync(userManager, "user");
    }

    private static async Task createUserIfNotExistsAsync(UserManager<UserEntity> userManager, String username) {
        UserEntity? user = await userManager.FindByNameAsync(username);
        if(user is not null)
            return;

        user = new UserEntity {
            UserName = username,
            Email = $"{username}@{username}.com"
        };

        IdentityResult result = await userManager.CreateAsync(user, username);

        if(result.Succeeded)
            await userManager.AddToRoleAsync(user, username);
    }

    private static async Task createRoleIfNotExistsAsync(RoleManager<IdentityRole> roleManager, String roleName) {
        if(await roleManager.RoleExistsAsync(roleName) is false)
            await roleManager.CreateAsync(new IdentityRole(roleName));
    }
}