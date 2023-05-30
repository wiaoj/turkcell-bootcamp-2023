using CourseApp.Mvc.Models;
using CourseApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CourseApp.Mvc.Controllers;
public class UserController : Controller {
    private readonly IUserService userService;

    public UserController(IUserService userService) {
        this.userService = userService;
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult Login(String? returnUrl) {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin, String returnUrl) {
        if(ModelState.IsValid is false)
            return View();

        var user = this.userService.ValidateUser(userLogin.UserName, userLogin.Password);

        if(user is null) {
            ModelState.AddModelError("login", "Kullanıcı adı ya da şifre yanlış!");
            return View();
        }

        Claim[] claims = new Claim[] {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role),
            };

        ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new(identity);
        await HttpContext.SignInAsync(principal);

        if(String.IsNullOrEmpty(returnUrl) is false
            && Url.IsLocalUrl(returnUrl)) {
            return Redirect(returnUrl);
        }
        return Redirect("/");
    }

    public async Task<IActionResult> Logout() {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }

    public IActionResult AccessDenied() {
        return View();
    }

}