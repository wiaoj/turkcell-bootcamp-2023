using Domain.Entities;

namespace Infrastructure.Persistence.Repositories;
public interface IAsyncRepository<TEntity> : 
    IAsyncWriteRepository<TEntity>, 
    IAsyncReadRepository<TEntity> 
    where TEntity : Entity {

}

public interface IAsyncWriteRepository<in TEntity> where TEntity : Entity {
    Task CreateAsync(TEntity entity);
    Task RemoveAsync(String id);
    Task RemoveAsync(TEntity entity);
    Task UpdateAsync(String id, TEntity entity);
}

public interface IAsyncReadRepository<TEntity> where TEntity : Entity {
    Task<TEntity> GetAsync(String id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}