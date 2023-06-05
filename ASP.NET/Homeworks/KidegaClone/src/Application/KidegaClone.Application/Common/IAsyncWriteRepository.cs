using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Common;
public interface IAsyncWriteRepository<in TEntity> where TEntity : Entity, new() {
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task<int> SaveChangesAsync();
}