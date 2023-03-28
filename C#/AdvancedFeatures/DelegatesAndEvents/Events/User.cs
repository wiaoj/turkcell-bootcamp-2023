namespace Events;
public class User {
    public Int32 Id { get; set; }
    public String Username { get; set; }
}

public sealed class UserCreatedEventArgs : EventArgs {
    public User User { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class UserService {
    private List<User> users = new();
    // Fırlatılacağı zaman => Yeni kullanıcı oluşturulduğunda event fırlatmaya karar verildi!
    //public delegate void UserCreatedEventHandler(Object sender, UserCreatedEventArgs eventArgs);
    //public event Action<Object, UserCreatedEventArgs> UserCreated;
    public event EventHandler<UserCreatedEventArgs> UserCreated; // üstteki 2 eventle aynı işlevi sağlar
    // EventArgs => event içeriğini getirir
    // Object => eventi fırlatan objeyi döndürür
    public void CreateUser(User user) {
        // TODO 01: Kullanıcı oluşturuldu event'i burada fırlayacak

        this.SetUserCreatedEvent(user);
    }

    private void SetUserCreatedEvent(User user) {
        if(UserCreated is not null) {
            UserCreatedEventArgs args = new() {
                User = user,
                CreatedDate = DateTime.UtcNow
            };
            this.UserCreated(this, args);
        }
    }

    //public void AddUser(User user) {
    //    this.users.Add(user);
    //}

    public void AddUser(User user) => this.users.Add(user);

    public Boolean IsEmpty() => this.users.Count is 0;

    public void Clear() => this.users.Clear();
}