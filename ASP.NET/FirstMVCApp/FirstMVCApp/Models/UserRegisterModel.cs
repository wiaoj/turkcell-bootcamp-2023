using System.ComponentModel.DataAnnotations;

namespace FirstMVCApp.Models;
public class UserRegisterModel {
    public String UserName { get; set; }
    [DataType(DataType.Password)]
    public String Password { get; set; }
    public DateTime BirthDate { get; set; }
}