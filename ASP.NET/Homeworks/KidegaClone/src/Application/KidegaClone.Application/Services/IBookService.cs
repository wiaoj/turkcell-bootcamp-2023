using KidegaClone.Application.DataTransferObjects.Pagination;
using KidegaClone.Application.DataTransferObjects.Requests;
using KidegaClone.Application.DataTransferObjects.Responses;

namespace KidegaClone.Application.Services;
public interface IBookService {
    Task CreateBookAsync(CreateBookRequest createBookRequest);
    Task DeleteBookAsync(DeleteBookRequest deleteBookRequest);
    Task<IPaginate<BookDisplayResponse>> GetAllBooksAsync(PaginationRequest paginationRequest);
    Task<BookDetailResponse> GetBookByIdWithAuthorAsync(Guid id);
    Task<UpdateBookDetailsResponse> GetBookDetailsByIdForUpdate(Guid id);
    Task UpdateBookAsync(UpdateBookRequest updateBookRequest);
}