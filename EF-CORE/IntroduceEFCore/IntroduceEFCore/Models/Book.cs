namespace IntroduceEFCore.Models;
public class Book {
    // POCO -> bildiğin c# objesi
    // Code First
    public Int32 Id { get; set; }
    public String Title { get; set; }
    public String Description { get; set; }
    public DateTime PublishDate { get; set; }

    public Int32 AuthorId { get; set; }
    public Author Author { get; set; }
}