using FirstMVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers;
public class HomeController : Controller {
    public IActionResult Index() {
        //ViewBag -> dynamic bir object
        ViewBag.Name = "Wiaoj";
        ViewBag.Month = DateTime.UtcNow.Month;
        ViewBag.Year = DateTime.UtcNow.Year;
        ViewBag.Items = new List<String> { "A", "B", "C" };
        return View();
    }

    public IActionResult Privacy() {
        Models.Privacy privacy = new() {
            Info = "Bu uygulama çerezleri kullanır.",
            Header = "Gizlilik "
        };
        //Strongly Typed View
        return View(privacy);
    }

    public IActionResult Register() {

        return View();
    }

    [HttpPost]
    public IActionResult Register(UserRegisterModel values) {
        var items = values;
        return View();
    }
}