namespace CourseApp.Entities;
public class Category : IEntity {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public String? Description { get; set; }

    public ICollection<Course> Courses { get; set; }
}