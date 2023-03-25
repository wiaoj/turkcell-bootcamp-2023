using SingleResponsibilty.Entities;
using SingleResponsibilty.Repository.Abstracts;

namespace SingleResponsibilty.Repository.Concretes;

public abstract class AsyncReadRepository<Type> : AsyncRepository<Type>, IAsyncReadRepository<Type> where Type : Entity, new() {
    public Int64 Count => Entities.Count;

    public async Task<IEnumerable<Type>> GetAllAsync() {
        await Task.CompletedTask;
        return Entities;
    }

    public async Task<Type> GetByIdAsync(Guid id) {
        await Task.CompletedTask;
        return FindById(id);
    }

    private Type FindById(Guid id) {
        Type? entity = Entities.Find(entity => entity.Id == id);
        ArgumentNullException.ThrowIfNull(entity);
        return entity;
    }
}