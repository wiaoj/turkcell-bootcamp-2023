using KidegaClone.Application.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using KidegaClone.WebUI.Mvc.Models;
using KidegaClone.Domain.Entities;

namespace KidegaClone.WebUI.Mvc.Controllers;
public class UsersController : Controller {
    private readonly IUserService userService;

    public UsersController(IUserService userService) {
        this.userService = userService;
    }
    public IActionResult Login(String? returnUrl) {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginViewModel userLogin, String? returnUrl) {
        if(ModelState.IsValid is false)
            return View();

        (UserEntity user, String role) = await this.userService.ValidateUser(userLogin.Email, userLogin.Password);

        Claim[] claims = new Claim[] {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, role)
            };

        ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal principal = new(identity);
        await HttpContext.SignInAsync(principal);

        if(String.IsNullOrEmpty(returnUrl) is false && Url.IsLocalUrl(returnUrl)) {
            return Redirect(returnUrl);
        }
        return Redirect("/");
    }

    [HttpGet]
    public async Task<IActionResult> Logout() {
        await HttpContext.SignOutAsync();
        return Redirect("/");
    }

    public IActionResult AccessDenied() {
        return View();
    }
}