using KidegaClone.Application.BusinessRules;
using KidegaClone.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace KidegaClone.Application.Services;
internal sealed class UserService : IUserService {
    private readonly UserManager<UserEntity> userManager;
    private readonly IUserBusinessRules userBusinessRules;

    public UserService(UserManager<UserEntity> userManager,
                       IUserBusinessRules userBusinessRules) {
        this.userManager = userManager;
        this.userBusinessRules = userBusinessRules;
    }

    public async Task<(UserEntity, String)> ValidateUser(String email, String password) {
        UserEntity? user = await this.userManager.FindByEmailAsync(email);
        this.userBusinessRules.IfUserIsNullThrow(user);

        Boolean isPasswordCorrect = await this.userManager.CheckPasswordAsync(user!, password);

        this.userBusinessRules.IfUserPasswordIsNotCorrectThrow(isPasswordCorrect);

        IList<String> userRoles = await this.userManager.GetRolesAsync(user!);

        String roles = String.Join(',', userRoles);

        return (user!, roles);
    }
}