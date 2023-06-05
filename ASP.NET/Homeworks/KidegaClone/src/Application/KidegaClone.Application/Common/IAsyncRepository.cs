using KidegaClone.Domain.Entities;

namespace KidegaClone.Application.Common;
public interface IAsyncRepository<TEntity> :
    IAsyncWriteRepository<TEntity>,
    IAsyncReadRepository<TEntity> where TEntity : Entity, new() { }