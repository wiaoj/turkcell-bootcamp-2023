using Movies.Entities;

namespace Movies.Data.Repositories;
public interface IMovieRepository : IRepository<Movie> {
    public Task<IEnumerable<Movie>> SearchMoviesByTitle(String title);
}