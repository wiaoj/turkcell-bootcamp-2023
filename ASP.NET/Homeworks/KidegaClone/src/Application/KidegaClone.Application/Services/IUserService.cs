using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Services;
public interface IUserService {
    Task<(UserEntity, String)> ValidateUser(String email, String password);
}