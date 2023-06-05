using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using KidegaClone.WebUI.Mvc.Models;
using KidegaClone.Application.Services;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Requests;

namespace KidegaClone.WebUI.Mvc.Controllers;

public class HomeController : Controller {
    private readonly ILogger<HomeController> _logger;
    private readonly IBookService bookService;

    public HomeController(ILogger<HomeController> logger, IBookService bookService) {
        _logger = logger;
        this.bookService = bookService;
    }

    public async Task<IActionResult> Index(Int32 page = 1) {
        PaginationRequest paginationRequest = new(page, 16);
        IPaginate<BookDisplayResponse> books = await this.bookService.GetAllBooksAsync(paginationRequest);
        return View(books);
    }

    public IActionResult Privacy() {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}