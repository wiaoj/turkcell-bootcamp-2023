using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace KidegaClone.WebUI.Mvc.Models;
public class UserLoginViewModel {
    [Required(ErrorMessage = "Email boş olamaz")]
    //[DataType(DataType.EmailAddress)]
    public String Email { get; set; }

    [Required(ErrorMessage = "Şifre boş olamaz")]
    [DataType(DataType.Password)]
    public String Password { get; set; }
}