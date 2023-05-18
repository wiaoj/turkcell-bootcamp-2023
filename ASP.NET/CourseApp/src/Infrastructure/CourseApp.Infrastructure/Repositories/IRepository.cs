using CourseApp.Entities;

namespace CourseApp.Infrastructure.Repositories;
public interface IRepository<TEntity> where TEntity : class, IEntity, new() {
    public TEntity? Get(Int32 id);
    public Task<TEntity?> GetAsync(Int32 id);

    public IList<TEntity?> GetAll();
    public Task<IList<TEntity?>> GetAllAsync();
}