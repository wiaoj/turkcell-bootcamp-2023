using homework5.Entities.Base;

namespace homework5.Repository.Abstracts;
public interface IReadRepository<Type> where Type : Entity, new() {
    public Int64 Count { get; }
    public IEnumerable<Type> GetAll();
    public IEnumerable<Type> FindAll(Func<Type, Boolean> predicate);
    public Type? Find(Func<Type, Boolean> predicate);
    public Type GetById(Guid id);
    public Type GetById(String id);
    public Boolean Any(Guid id);
}