using CourseApp.DataTransferObjects.Responses;
using CourseApp.Mvc.Extensions;
using CourseApp.Mvc.Models;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CourseApp.Mvc.Controllers;
public class ShoppingController : Controller {
    private readonly ICourseService courseService;

    public ShoppingController(ICourseService courseService) {
        this.courseService = courseService;
    }

    public IActionResult Index() {
        CourseCollection courseCollection = getCourseCollectionFromSession();
        return this.View(courseCollection);
    }

    public IActionResult AddCourse(Int32 id) {
        CourseDisplayResponse selectedCourse = this.courseService.GetCourse(id);

        CourseItem courseItem = new() {
            Course = selectedCourse,
            Quantity = 1
        };

        CourseCollection courseCollection = getCourseCollectionFromSession();
        courseCollection.AddNewCourse(courseItem);
        saveToSession(courseCollection);
        return this.Json(new { message = $"{selectedCourse.Title} Sepete Eklendi" });
    }

    private CourseCollection getCourseCollectionFromSession() {
        return HttpContext.Session.GetJson<CourseCollection>("basket") 
            ?? new CourseCollection();
    }

    private void saveToSession(CourseCollection courseCollection) {
        HttpContext.Session.SetJson<CourseCollection>("basket", courseCollection);
    }
}