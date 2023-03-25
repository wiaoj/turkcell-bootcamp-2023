using SingleResponsibilty.Entities;
using SingleResponsibilty.Repository.Abstracts;

namespace SingleResponsibilty.Repository.Concretes;
public abstract class AsyncWriteRepository<Type> : AsyncRepository<Type>, IAsyncWriteRepository<Type> where Type : Entity, new() {
    public async Task DeleteAsync(Type entity) {
        await Task.CompletedTask;
        Entities.Remove(entity);
    }

    public async Task DeleteByIdAsync(Guid id) {
        Type entity = FindEntityById(id);
        await DeleteAsync(entity);
    }

    public async Task DeleteRangeAsync(IEnumerable<Type> entities) {
        await Task.CompletedTask;
        entities.Select(Entities.Remove);
    }

    public async Task InsertAsync(Type entity) {
        await Task.CompletedTask;
        Entities.Add(entity);
    }

    public async Task InsertRangeAsync(IEnumerable<Type> entities) {
        await Task.CompletedTask;
        Entities.AddRange(entities);
    }

    public async Task UpdateAsync(Type entity) {
        Type wantedEntity = FindEntityById(entity.Id);
        await this.DeleteAsync(wantedEntity);
        await this.InsertAsync(entity);
    }

    private Type FindEntityById(Guid id) {
        Type? entity = Entities.Find(entity => entity.Id == id);
        ArgumentNullException.ThrowIfNull(entity);
        return entity;
    }
}