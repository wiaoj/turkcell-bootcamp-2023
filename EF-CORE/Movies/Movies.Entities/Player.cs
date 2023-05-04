namespace Movies.Entities;
public class Player : IEntity {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public String LastName { get; set; }

    public ICollection<MoviesPlayer> Movies { get; set; }
}