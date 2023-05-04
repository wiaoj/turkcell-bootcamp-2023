using Movies.Entities;

namespace Movies.Data.Repositories;
public class EFMovieRepository : IMovieRepository {
    public Task CreateAsync(Movie entity) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Movie>> GetAllAsync() {
        throw new NotImplementedException();
    }

    public Task<Movie> GetByIdAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Movie>> SearchMoviesByTitle(String title) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Movie entity) {
        throw new NotImplementedException();
    }
}