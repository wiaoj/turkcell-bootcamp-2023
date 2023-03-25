using SingleResponsibilty.Entities;

namespace SingleResponsibilty.Repository.Abstracts;

public interface IAsyncWriteRepository<in Type> where Type : Entity, new() {
    public Task InsertAsync(Type entity);
    public Task InsertRangeAsync(IEnumerable<Type> entities);
    public Task UpdateAsync(Type entity);
    public Task DeleteAsync(Type entity);
    public Task DeleteByIdAsync(Guid id);
    public Task DeleteRangeAsync(IEnumerable<Type> entities);
}