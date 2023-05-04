using Movies.Entities;

namespace Movies.Data.Repositories;
public interface IRepository<T> where T: class, IEntity, new() {
    public Task CreateAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(Int32 id);

    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> GetByIdAsync(Int32 id);
}