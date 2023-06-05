using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.BusinessRules;
internal interface IUserBusinessRules {
    void IfUserIsNullThrow(UserEntity? user);
    void IfUserPasswordIsNotCorrectThrow(Boolean isPasswordCorrect);
}