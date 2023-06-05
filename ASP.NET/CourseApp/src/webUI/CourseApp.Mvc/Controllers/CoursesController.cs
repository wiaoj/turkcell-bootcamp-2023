using CourseApp.DataTransferObjects.Requests;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseApp.Mvc.Controllers;
[Authorize(Roles = "Admin,Editor")]
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

    public async Task<IActionResult> Edit(Int32 id) {
        ViewBag.Categories = getCategoriesForSelectlist();
        UpdateCourseRequest course = await this.courseService.GetCourseForUpdateAsync(id);
        return View(course);
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Int32 id, UpdateCourseRequest updateCourseRequest) {
        if(await this.courseService.CourseIsExists(id) is false)
            return NotFound();

        if(ModelState.IsValid is false) {
            ViewBag.Categories = getCategoriesForSelectlist();
            return View();
        }

        await this.courseService.UpdateCourseAsync(updateCourseRequest);
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