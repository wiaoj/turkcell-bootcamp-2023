namespace homework3;

public interface IEntity<Type> {
    public Type Id { get; }
    public DateTime Created { get; }
}