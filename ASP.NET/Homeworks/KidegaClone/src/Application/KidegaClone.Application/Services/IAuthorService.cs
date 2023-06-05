using KidegaClone.Application.DataTransferObjects.Responses;

namespace KidegaClone.Application.Services;
public interface IAuthorService {
    Task<IEnumerable<AuthorSelectionResponse>> GetAllSelectionAuthorsAsync();
}