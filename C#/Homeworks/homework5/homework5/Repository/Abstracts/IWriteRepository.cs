using homework5.Entities.Base;

namespace homework5.Repository.Abstracts;
public interface IWriteRepository<in Type> where Type : Entity, new() {
    public void Insert(Type entity);
    public void InsertRange(IEnumerable<Type> entities);
    public void Update(Type entity);
    public void Delete(Type entity);
    public void DeleteById(Guid id);
    public void DeleteById(String id);
    public void DeleteRange(IEnumerable<Type> entities);
}