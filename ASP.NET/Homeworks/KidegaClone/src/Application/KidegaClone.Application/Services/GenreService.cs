using KidegaClone.Application.DataTransferObjects.Responses;
using KidegaClone.Application.Extensions;
using KidegaClone.Application.Repositories;
using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Services;
internal sealed class GenreService : IGenreService {
    private readonly IGenreRepository genreRepository;

    public GenreService(IGenreRepository genreRepository) {
        this.genreRepository = genreRepository;
    }

    public async Task<IEnumerable<GenreSelectionResponse>> GetAllSelectionGenresAsync() {
        IEnumerable<GenreEntity> genres = await this.genreRepository.GetAllAsync();
        return genres.MapTo<GenreSelectionResponse>();
    }
}