using CourseApp.DataTransferObjects.Requests;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseApp.Mvc.Controllers;
public class CoursesController : Controller {
    private readonly ICourseService courseService;
    private readonly ICategoryService categoryService;

    public CoursesController(
        ICourseService courseService,
        ICategoryService categoryService) {
        this.courseService = courseService;
        this.categoryService = categoryService;
    }

    public IActionResult Index() {
        var courses = this.courseService.GetCourseDisplayResponses();
        return View(courses);
    }

    public async Task<IActionResult> Create() {
        ViewBag.Categories = getCategoriesForSelectlist();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNewCourseRequest createNewCourseRequest) {
        if(ModelState.IsValid is false) {
            ViewBag.Categories = getCategoriesForSelectlist();
            return View();
        }

        await this.courseService.CreateCourseAsync(createNewCourseRequest);
        return RedirectToAction(nameof(Index));
    }

    private IEnumerable<SelectListItem> getCategoriesForSelectlist() {
        IEnumerable<SelectListItem> categories = categoryService.GetCategoriesForList()
                             .Select(category => new SelectListItem {
                                 Text = category.Name,
                                 Value = category.Id.ToString()
                             });
        return categories;
    }
}