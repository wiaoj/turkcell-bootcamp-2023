using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CourseApp.API.Models;
using CourseApp.Services;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace CourseApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase {
    private readonly IUserService userService;

    public UsersController(IUserService userService) {
        this.userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin) {
        if(ModelState.IsValid is false)
            return BadRequest();

        var user = this.userService.ValidateUser(userLogin.UserName, userLogin.Password);

        if(user is null) {
            ModelState.AddModelError("login", "Kullanıcı adı ya da şifre yanlış!");
            return BadRequest(ModelState);
        }

        Claim[] claims = new Claim[] {
                new(JwtRegisteredClaimNames.UniqueName, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role),
        };

        //ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //ClaimsPrincipal principal = new(identity);
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes("BURASI-COK-GIZLI-ONA-GORE"));

        SigningCredentials credential = new(key, SecurityAlgorithms.HmacSha512); //owaps.org üzerinden şifreleme ile iligli bilgi alınabilir

        JwtSecurityToken token = new(
            issuer: "server", //token veren
            audience: "client", //tokeni kullanacak
            claims: claims,
            notBefore: DateTime.Now, //bu tarihten önce kullanılamaz
            expires: DateTime.Now.AddMinutes(20), //son kullanma tarihi
            signingCredentials: credential
            );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}