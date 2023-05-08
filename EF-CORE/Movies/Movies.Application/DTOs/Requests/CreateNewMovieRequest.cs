namespace Movies.Application.DTOs.Requests;
public record CreateNewMovieRequest {
    public String Name { get; set; }
    public DateTime? PublishDate { get; set; }
    public String? Poster { get; set; }
    public Int32? Duration { get; set; }
    public Double? Rating { get; set; }
    public Int32? DirectorId { get; set; }
}