using CourseApp.DataTransferObjects.Responses;
using CourseApp.Mvc.Models;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseApp.Mvc.Controllers;
public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly ICourseService courseService;

    public HomeController(
        ILogger<HomeController> logger,
        ICourseService courseService) {
        this._logger = logger;
        this.courseService = courseService;
    }

    public IActionResult Index(Int32 pageNo = 1, Int32? id = null) {
        IEnumerable<CourseDisplayResponse> courses = id == null 
            ? this.courseService.GetCourseDisplayResponses()
            : this.courseService.GetCoursesByCategory(id.Value);

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
        Int32 coursePerPage = 4;
        Int32 courseCount = courses.Count();
        Decimal totalPage = Math.Ceiling((Decimal)courseCount / coursePerPage);

        PagingInfo pagingInfo = new() {
            CurrentPage = pageNo,
            ItemsPerPage = coursePerPage,
            TotalItems = courseCount
        };

        IEnumerable<CourseDisplayResponse> paginatedCourses = courses.OrderBy(x => x.Id).Skip((pageNo - 1) * coursePerPage).Take(coursePerPage);

        PaginationCourseModel model = new() {
            Courses = paginatedCourses,
            PagingInfo = pagingInfo
        };

        return this.View(model);
    }

    public IActionResult Privacy() {
        return this.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
