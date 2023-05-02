namespace IntroduceEFCore.Models;
public class Review {
    public Int32 Id { get; set; }
    public String Comment { get; set; } = String.Empty;
    public String VoterName { get; set; } = String.Empty;

    public Int32? BookId { get; set; }
    public Book? Book { get; set; }
    public Double? Rating { get; set; }
}