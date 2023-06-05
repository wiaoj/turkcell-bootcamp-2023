using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Application.Services;
using KidegaClone.WebUI.Mvc.Extensions;
using KidegaClone.WebUI.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidegaClone.WebUI.Mvc.Controllers;
[Route("[controller]")]
public class BooksController : Controller {
    private readonly IBookService bookService;
    private readonly IGenreService genreService;
    private readonly IAuthorService authorService;

    public BooksController(
        IBookService bookService,
        IGenreService genreService,
        IAuthorService authorService) {
        this.bookService = bookService;
        this.genreService = genreService;
        this.authorService = authorService;
    }

    [HttpGet]
    [Authorize("admin")]
    public async Task<IActionResult> Index(Int32 page = 1) {
        PaginationRequest paginationRequest = new(page, 8);
        IPaginate<BookDisplayResponse> books = await this.bookService.GetAllBooksAsync(paginationRequest);
        return View(books);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Details(Guid id) {
        BookDetailResponse book = await this.bookService.GetBookByIdWithAuthorAsync(id);

        if(book is null) {
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).TrimControllerSuffix());
        }
        return View(book);
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize("admin")]
    public async Task<IActionResult> Create() {
        IEnumerable<GenreSelectionResponse> selectionGenres = await this.genreService.GetAllSelectionGenresAsync();
        IEnumerable<SelectListItem<GenreSelectionResponse>> selectListGenres =
            selectionGenres.Select(genre => genre.ToSelectListItem(genre.Name, genre.Id.ToString()));

        IEnumerable<AuthorSelectionResponse> selectionAuthors = await this.authorService.GetAllSelectionAuthorsAsync();
        IEnumerable<SelectListItem<AuthorSelectionResponse>> selectListAuthors =
            selectionAuthors.Select(author => author.ToSelectListItem(author.FullName, author.Id.ToString()));
        CreateBookViewModel createBookViewModel = new(new(), selectListGenres, selectListAuthors);
        return View(createBookViewModel);
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize("admin")]
    public async Task<IActionResult> Create(CreateBookRequest createBookRequest) {
        if(ModelState.IsValid is false) {
            return View();
        }

        await this.bookService.CreateBookAsync(createBookRequest);
        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).TrimControllerSuffix());
    }

    [HttpPut]
    [Route("[action]/{id:Guid}")]
    [Authorize("admin")]
    public async Task<IActionResult> Update(UpdateBookRequest updateBookRequest) {
        await this.bookService.UpdateBookAsync(updateBookRequest);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [Route("{id:Guid}/[action]")]
    [Authorize("admin")]
    public async Task<IActionResult> GetBookDetailsForUpdate(Guid id) {
        UpdateBookDetailsResponse bookDetails = await this.bookService.GetBookDetailsByIdForUpdate(id);
        return Json(bookDetails);
    }

   
    [HttpDelete]
    [Route("{id:Guid}")]
    [Authorize("admin")]
    public async Task<IActionResult> Delete(Guid id) {
        await this.bookService.DeleteBookAsync(new DeleteBookRequest { Id = id });
        return RedirectToAction(nameof(Index));
    }
}