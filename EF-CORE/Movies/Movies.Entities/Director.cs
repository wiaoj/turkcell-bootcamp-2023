namespace Movies.Entities;
public class Director : IEntity {
    public Int32 Id { get; set; }
    public String Name { get; set; } = String.Empty;
    public String LastName { get; set; } = String.Empty;
    public String? Info { get; set; }

    public ICollection<Movie> Movies { get; set; }
}