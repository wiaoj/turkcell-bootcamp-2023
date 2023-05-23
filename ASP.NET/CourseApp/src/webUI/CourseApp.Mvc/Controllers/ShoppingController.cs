using CourseApp.DataTransferObjects.Responses;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Mvc.Controllers;
public class ShoppingController : Controller {
    private readonly ICourseService courseService;

    public ShoppingController(ICourseService courseService) {
        this.courseService = courseService;
    }

    public IActionResult Index() {
        return View();
    }

    public IActionResult AddCourse(Int32 id) {
        CourseDisplayResponse selectedCourse = this.courseService.GetCourse(id);
        return Json(new { message = $"{selectedCourse.Title} Sepete Eklendi" });
    }
}