using CourseApp.Entities;
using CourseApp.Services;
using CourserApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourserApp.Mvc.Controllers;
public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly ICourseService courseService;

    public HomeController(
        ILogger<HomeController> logger,
        ICourseService courseService) {
        _logger = logger;
        this.courseService = courseService;
    }

    public IActionResult Index() {
        var courses = this.courseService.GetCourseDisplayResponses();
        return View(courses);
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
