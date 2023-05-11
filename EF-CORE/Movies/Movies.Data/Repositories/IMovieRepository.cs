using Movies.Entities;

namespace Movies.Data.Repositories;
public interface IMovieRepository : IRepository<Movie> {
    public Task<IEnumerable<Movie>> SearchMoviesByTitle(String title);
    public Task AddPlayersToMovie(Int32 movieId, List<Int32> selectedPlayerIds);
}