using Microsoft.EntityFrameworkCore;
using Movies.Data.Data;
using Movies.Entities;

namespace Movies.Data.Repositories;
public class EFDirectorRepository : IDirectorRepository {
    private readonly MoviesDbContext moviesDbContext;

    public EFDirectorRepository(MoviesDbContext moviesDbContext) {
        this.moviesDbContext = moviesDbContext;
    }

    public async Task CreateAsync(Director entity) {
        await this.moviesDbContext.Directors.AddAsync(entity);
        await this.moviesDbContext.SaveChangesAsync();
    }

    public Task DeleteAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Director>> GetAllAsync() {
        return await this.moviesDbContext.Directors.AsNoTracking().ToListAsync();
    }

    public async Task<Director?> GetByIdAsync(Int32 id) {
        return await this.moviesDbContext.Directors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        //return await this.moviesDbContext.Directors.FindAsync(id);
    }

    public async Task UpdateAsync(Director entity) {
        this.moviesDbContext.Directors.Update(entity);
        await this.moviesDbContext.SaveChangesAsync();
    }
}