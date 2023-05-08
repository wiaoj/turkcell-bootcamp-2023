namespace Movies.Entities;
public class Movie : IEntity {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public DateTime? PublishDate { get; set; }
    public String? Poster { get; set; }
    public Int32? Duration { get; set; }
    public Double? Rating { get; set; }

    //Navigation Property:
    public Int32? DirectorId { get; set; }
    public Director? Director { get; set; }

    public ICollection<MoviesPlayer> Players { get; set; } = new HashSet<MoviesPlayer>();
}