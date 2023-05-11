using Microsoft.EntityFrameworkCore;
using Movies.Data.Data;
using Movies.Entities;

namespace Movies.Data.Repositories;
public class EFPlayerRepository : IPlayerRepository {
    private readonly MoviesDbContext moviesDbContext;

    public EFPlayerRepository(MoviesDbContext moviesDbContext) {
        this.moviesDbContext = moviesDbContext;
    }

    public async Task CreateAsync(Player entity) {
        await this.moviesDbContext.Players.AddAsync(entity);
        await this.moviesDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Int32 id) {
        Player? player = await this.moviesDbContext.Players.AsNoTracking().FirstOrDefaultAsync(player => player.Id == id);
        this.moviesDbContext.Players.Remove(player);
        await this.moviesDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Player>> GetAllAsync() {
        return await this.moviesDbContext.Players.AsNoTracking().ToListAsync();
    }

    public async Task<Player?> GetByIdAsync(Int32 id) {
        return await this.moviesDbContext.Players.FindAsync(id);
    }

    public async Task UpdateAsync(Player entity) {
        this.moviesDbContext.Players.Update(entity);
        await this.moviesDbContext.SaveChangesAsync();
    }
}