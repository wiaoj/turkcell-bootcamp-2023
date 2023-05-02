namespace IntroduceEFCore.Models;
public class Book {
    // POCO -> bildiğin c# objesi
    // Code First
    public Int32 Id { get; set; }
    public String Title { get; set; }
    public String Description { get; set; }
    public DateTime? PublishDate { get; set; }

    public List<Author>? Authors { get; set; }
    public List<Review>? Reviews { get; set; }
}