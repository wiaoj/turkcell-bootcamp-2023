using KidegaClone.Application.DataTransferObjects.Responses;

namespace KidegaClone.Application.Services;
public interface IGenreService {
    Task<IEnumerable<GenreSelectionResponse>> GetAllSelectionGenresAsync();
}