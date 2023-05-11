using Movies.Application.DTOs.Requests;
using Movies.Application.DTOs.Responses;

namespace Movies.Application;
public interface IMovieService {
    public Task<Int32> CreateNewMovie(CreateNewMovieRequest createNewMovie);
    public Task UpdateMovie(UpdateMovieRequest updateMovie);
    public Task<IEnumerable<MovieListResponse>> GetAllMovies();
    public Task AddPlayersToMovie(Int32 movieId, List<Int32> players);
}