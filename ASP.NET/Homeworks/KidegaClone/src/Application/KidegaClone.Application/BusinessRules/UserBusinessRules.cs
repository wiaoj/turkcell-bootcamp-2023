using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.BusinessRules;
internal sealed class UserBusinessRules : IUserBusinessRules {
    public void IfUserIsNullThrow(UserEntity? user) {
        _ = user ?? throw new Exception("Kullanıcı bulunamadı");
    }

    public void IfUserPasswordIsNotCorrectThrow(Boolean isPasswordCorrect) {
        if(isPasswordCorrect)
            return;

        throw new Exception("Kullanıcı bulunamadı");
    }
}