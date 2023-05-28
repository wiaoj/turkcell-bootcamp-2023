using CourseApp.Mvc.Extensions;
using CourseApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Mvc.ViewComponents;
public class BasketLinkViewComponent : ViewComponent {
    public IViewComponentResult Invoke() {
        CourseCollection courseCollection = HttpContext.Session.GetJson<CourseCollection>("basket");
            return View(courseCollection);;
    }
}