using DependencyInjectionLifeTime.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionLifeTime.Controllers;
public class HomeController : Controller {
    private readonly ISingletonGuid singleton;
    private readonly ITransientGuid transient;
    private readonly IScopedGuid scoped;
    private readonly GuidService guidService;

    public HomeController(
        ISingletonGuid singleton,
        ITransientGuid transient,
        IScopedGuid scoped,
        GuidService guidService) {
        this.singleton = singleton;
        this.transient = transient;
        this.scoped = scoped;
        this.guidService = guidService;
    }

    public IActionResult Index() {
        ViewBag.Singleton = this.singleton.Guid.ToString();
        ViewBag.Transient = this.transient.Guid.ToString();
        ViewBag.Scoped = this.scoped.Guid.ToString();

        ViewBag.GuidServiceSingleton = this.guidService.Singleton.Guid.ToString();
        ViewBag.GuidServiceTransient = this.guidService.Transient.Guid.ToString();
        ViewBag.GuidServiceScoped = this.guidService.Scoped.Guid.ToString();
        return View();
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
