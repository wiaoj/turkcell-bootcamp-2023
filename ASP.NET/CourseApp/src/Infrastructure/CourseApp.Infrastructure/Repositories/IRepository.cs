using CourseApp.Entities;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Repositories;
public interface IRepository<TEntity> where TEntity : class, IEntity, new() {
    public TEntity? Get(Int32 id);
    public Task<TEntity?> GetAsync(Int32 id);

    public IList<TEntity?> GetAll();
    public Task<IList<TEntity?>> GetAllAsync();

    IList<TEntity> GetAllWithPredicate(Expression<Func<TEntity, Boolean>> predicate);

    Task CreateAsync(TEntity entity);
    Task DeleteAsync(Int32 id);
    Task UpdateAsync(TEntity entity);
}