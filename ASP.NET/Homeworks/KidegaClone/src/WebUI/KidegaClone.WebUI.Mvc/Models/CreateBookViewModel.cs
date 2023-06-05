using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Application.DataTransferObjects.Responses;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidegaClone.WebUI.Mvc.Models;
public sealed record CreateBookViewModel(
    CreateBookRequest CreateBookRequest,
    IEnumerable<SelectListItem<GenreSelectionResponse>> Genres,
    IEnumerable<SelectListItem<AuthorSelectionResponse>> Authors);