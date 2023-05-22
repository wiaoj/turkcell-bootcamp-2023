using CourseApp.Entities;
using CourseApp.Services;
using CourseApp.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace CourseApp.Mvc.Controllers;
public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly ICourseService courseService;

    public HomeController(
        ILogger<HomeController> logger,
        ICourseService courseService) {
        _logger = logger;
        this.courseService = courseService;
    }

    public IActionResult Index(Int32 pageNo = 1) {
        var courses = this.courseService.GetCourseDisplayResponses();

        /*
         * 1. Sayfa; 
         *  Koleksiyon içerisinden 0 eleman atla, 8 eleman al
         *  
         * 2. Sayfa;
         *  Koleksiyon içerisinden 8 eleman atla, 8 eleman al
         *  
         * 3. Sayfa;
         *  Koleksiyon içerisinden 16 eleman atla, 8 eleman al
         */


        /*
         * Kursların toplam sayfa sayısı için hangi bilgiler gerkeli?
         * 1 -> Sayfada kaç kurs olacak?
         * 2 -> Toplam kaç kurs var? 
         */
        var coursePerPage = 8;
        var courseCount = courses.Count();
        var totalPage = Math.Ceiling((Decimal)courseCount / coursePerPage);

        PagingInfo pagingInfo = new() {
            CurrentPage = pageNo,
            ItemsPerPage = 8,
            TotalItems = courseCount
        };

        pageNo--;
        var paginatedCourses = courses.OrderBy(x => x.Id).Skip(pageNo * coursePerPage).Take(coursePerPage);

        PaginationCourseModel model = new() {
            Courses = paginatedCourses, 
            PagingInfo = pagingInfo 
        };

        return View(model);
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
