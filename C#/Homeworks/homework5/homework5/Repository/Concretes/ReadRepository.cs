using homework5.Entities.Base;
using homework5.Repository.Abstracts;

namespace homework5.Repository.Concretes;
public abstract class ReadRepository<Type> : Repository<Type>, IReadRepository<Type> where Type : Entity, new() {
    private Int32 MAX_GUID_LENGTH => Guid.Empty.ToString().Length;
    public Int64 Count => Entities.Count;

    public Boolean Any(Guid id) {
        return Entities.Any(x => x.Id == id);
    }

    public IEnumerable<Type> FindAll(Func<Type, Boolean> predicate) {
        return Entities.Where(predicate);
    }

    public Type? Find(Func<Type, Boolean> predicate) {
        return Entities.Where(predicate).SingleOrDefault();
    }

    public IEnumerable<Type> GetAll() {
        return Entities;
    }

    public Type GetById(Guid id) {
        return this.FindById(id);
    }

    public Type GetById(String id) {
        if(id.Length > this.MAX_GUID_LENGTH) {
            throw new Exception($"Girilen id |{id}| uzunluğu {id.Length} karakter, maksimum beklenen karakter sayısı: {this.MAX_GUID_LENGTH}");
        }

        if(id.Length < this.MAX_GUID_LENGTH) {
            Type? entity = Entities.FirstOrDefault(entity => entity.Id.ToString()[..id.Length] == id);
            ArgumentNullException.ThrowIfNull(entity);
            return entity;
        }

        return this.FindById(Guid.Parse(id));
    }

    private Type FindById(Guid id) {
        Type? entity = Entities.Find(entity => entity.Id == id);
        ArgumentNullException.ThrowIfNull(entity);
        return entity;
    }
}