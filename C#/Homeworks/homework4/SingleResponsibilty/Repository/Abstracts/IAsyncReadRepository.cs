using SingleResponsibilty.Entities;

namespace SingleResponsibilty.Repository.Abstracts;
public interface IAsyncReadRepository<Type> where Type : Entity, new() {
    public Int64 Count { get; }
    public Task<IEnumerable<Type>> GetAllAsync();
    public Task<Type> GetByIdAsync(Guid id);
}