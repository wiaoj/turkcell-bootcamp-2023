using CourseApp.Entities;

namespace CourseApp.Services;
public interface IUserService {
    public User ValidateUser(String username, String password);
}