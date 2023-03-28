namespace Events;

public partial class Form1 : Form {
    public Form1() {
        this.InitializeComponent();
    }

    private void textBox1_KeyDown(Object sender, KeyEventArgs e) {

    }

    private void Form1_Load(Object sender, EventArgs e) {
        UserService userService = new();
        userService.UserCreated += this.UserService_UserCreated;

        User user = new() {
            Username = "wiaoj"
        };
        userService.CreateUser(user);
    }

    private void UserService_UserCreated(Object? sender, UserCreatedEventArgs e) {
        MessageBox.Show($"{e.CreatedDate.ToLongDateString()} tarihinde, {e.User.Username} kullanýcýsý eklendi");
    }
}
