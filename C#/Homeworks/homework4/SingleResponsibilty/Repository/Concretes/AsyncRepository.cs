using SingleResponsibilty.Entities;

namespace SingleResponsibilty.Repository.Concretes;
public abstract class AsyncRepository<Type> where Type : Entity, new() {
    private static List<Type> _entites = new();
    public static List<Type> Entities => _entites;
}