using homework5.Entities.Base;
using homework5.Repository.Abstracts;

namespace homework5.Repository.Concretes;
public abstract class WriteRepository<Type> : Repository<Type>, IWriteRepository<Type> where Type : Entity, new() {
    //private Int32 MAX_GUID_LENGTH => Guid.Empty.ToString().Length;    
    private const Int32 MAX_GUID_LENGTH = 36;
    public void Delete(Type entity) {
        Entities.Remove(entity);
    }

    public void DeleteById(Guid id) {
        Type entity = this.FindEntityById(id);
        ArgumentNullException.ThrowIfNull(entity);
        this.Delete(entity);
    }

    public void DeleteById(String id) {
        if(id.Length > MAX_GUID_LENGTH) {
            throw new Exception($"Girilen id |{id}| uzunluğu {id.Length} karakter, maksimum beklenen karakter sayısı: {MAX_GUID_LENGTH}");
        } else if(id.Length < 8) {
            throw new Exception($"Girilen değer minimum 8 karakter olmalıdır, girilen karakter sayısı: {id.Length}");
        }

        if(id.Length is > 8 and < MAX_GUID_LENGTH) {
            Type? entity = Entities.SingleOrDefault(entity => entity.Id.ToString()[..id.Length] == id);
            ArgumentNullException.ThrowIfNull(entity);
            this.Delete(entity);
        }

        this.DeleteById(Guid.Parse(id));
    }

    public void DeleteRange(IEnumerable<Type> entities) {
        entities.Select(Entities.Remove);
    }

    public void Insert(Type entity) {
        Entities.Add(entity);
    }

    public void InsertRange(IEnumerable<Type> entities) {
        Entities.AddRange(entities);
    }

    public void Update(Type entity) {
        Type wantedEntity = this.FindEntityById(entity.Id);
        this.Delete(wantedEntity);
        this.Insert(entity);
    }

    private Type FindEntityById(Guid id) {
        Type? entity = Entities.Find(entity => entity.Id == id);
        ArgumentNullException.ThrowIfNull(entity);
        return entity;
    }
}