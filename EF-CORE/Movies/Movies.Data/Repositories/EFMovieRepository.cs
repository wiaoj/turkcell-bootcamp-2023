using Microsoft.EntityFrameworkCore;
using Movies.Data.Data;
using Movies.Entities;

namespace Movies.Data.Repositories;
public class EFMovieRepository : IMovieRepository {
    private readonly MoviesDbContext moviesDbContext;

    public EFMovieRepository(MoviesDbContext moviesDbContext) {
        this.moviesDbContext = moviesDbContext;
    }

    public async Task CreateAsync(Movie entity) {
        await this.moviesDbContext.Movies.AddAsync(entity);
        await this.moviesDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Int32 id) {
        Movie movie = await this.moviesDbContext.Movies.AsNoTracking().FirstOrDefaultAsync(movie => movie.Id == id);
        this.moviesDbContext.Movies.Remove(movie);
        await this.moviesDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Movie>> GetAllAsync() {
        return await this.moviesDbContext.Movies
            .AsNoTracking()
            .Include(movie => movie.Director)
            .Include(movie => movie.Players)
            .ThenInclude(players => players.Player)
            .ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(Int32 id) {
        return await this.moviesDbContext.Movies.AsNoTracking().FirstOrDefaultAsync(movie => movie.Id == id);
    }

    public async Task<IEnumerable<Movie>> SearchMoviesByTitle(String title) {
        return await this.moviesDbContext.Movies.AsNoTracking().Where(movie => movie.Name.Contains(title)).ToListAsync();
    }

    public async Task AddPlayersToMovie(Int32 movieId, List<Int32> selectedPlayerIds) {
        Movie movie = await this.moviesDbContext.Movies.FindAsync(movieId);
        selectedPlayerIds.ForEach(playerId => {
            movie?.Players.Add(new MoviesPlayer {
                MovieId = movie.Id,
                PlayerId = playerId
            });
        });
        await this.moviesDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie entity) {
        this.moviesDbContext.Movies.Update(entity);
        await this.moviesDbContext.SaveChangesAsync();
    }
}