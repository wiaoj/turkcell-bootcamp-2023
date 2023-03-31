using homework5.Entities.Base;

namespace homework5.Repository.Concretes;
public abstract class Repository<Type> where Type : Entity, new() {
    public static List<Type> Entities { get; } = new();
}