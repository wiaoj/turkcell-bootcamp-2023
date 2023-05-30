using System.ComponentModel.DataAnnotations;

namespace CourseApp.Mvc.Models;
public class UserLoginViewModel {
    [Required(ErrorMessage = "Kullanıcı adı boş olamaz")]
    public String UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public String Password { get; set; }
}