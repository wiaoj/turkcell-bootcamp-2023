namespace Movies.Entities;
public class MoviesPlayer : IEntity {
    public Int32 MovieId { get; set; }
    public Movie Movie { get; set; }

    public Int32 PlayerId { get; set; }
    public Player Player { get; set; }

    public String? Role { get; set; }
}