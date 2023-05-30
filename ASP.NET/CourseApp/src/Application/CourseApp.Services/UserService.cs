using CourseApp.Entities;

namespace CourseApp.Services;
public sealed class UserService : IUserService {
    private List<User> users;

    public UserService() {
        this.users = new() {
            new() {
                Id = 1,
                Name = "Test",
                Email = "abc@xyz.com",
                UserName = "wiaoj",
                Password = "123",
                Role = "Admin"
            }
        };
    }

    public User ValidateUser(String username, String password) {
        return this.users.SingleOrDefault(
            user => user.UserName == username
            && user.Password == password);
    }
}