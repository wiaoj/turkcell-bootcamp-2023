using CourseApp.DataTransferObjects.Responses;
using CourseApp.Mvc.CacheTools;
using CourseApp.Mvc.Models;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace CourseApp.Mvc.Controllers;
public class HomeController : Controller {
    private readonly ILogger<HomeController> logger;
    private readonly ICourseService courseService;
    private readonly IMemoryCache memoryCache;

    public HomeController(
        ILogger<HomeController> logger,
        ICourseService courseService,
        IMemoryCache memoryCache) {
        this.logger = logger;
        this.courseService = courseService;
        this.memoryCache = memoryCache;
    }

    public IActionResult Index(Int32 pageNo = 1, Int32? id = null) {
        IEnumerable<CourseDisplayResponse> courses = getCoursesMemCacheOrDb(id);

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

    private IEnumerable<CourseDisplayResponse> getCoursesMemCacheOrDb(Int32? id) {
        //Eğer; cache'de varsa cache'den çek yoksa kaynaktan çek ve cache'e aktar
        if(this.memoryCache.TryGetValue("all-courses", out CacheDataInfo? cacheDataInfo) is false) {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions()
                                .SetSlidingExpiration(TimeSpan.FromMinutes(1))
                                .SetPriority(CacheItemPriority.Normal);

            cacheDataInfo = new() {
                CacheTime = DateTime.UtcNow,
                Courses = this.courseService.GetCourseDisplayResponses()
            };

            this.memoryCache.Set("all-courses", cacheDataInfo, options);
        }

        this.logger.LogInformation($"{cacheDataInfo!.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz");
        return id == null
                    ? cacheDataInfo!.Courses
                    : this.courseService.GetCoursesByCategory(id.Value);
    }

    [ResponseCache(
        Duration = 70,
        VaryByQueryKeys = new[] { "id" },
        Location = ResponseCacheLocation.Client)]
    public IActionResult Privacy(Int32 id) {
        ViewBag.Id = id;
        ViewBag.DateTime = DateTime.Now;
        return this.View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
    }
}
