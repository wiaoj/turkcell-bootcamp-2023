namespace IntroduceEFCore.Models;
public class Author {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public String LastName { get; set; }

    public IList<Book> Books { get; set; }
}