namespace CourseApp.Entities;
public class Course : IEntity {
    public Int32 Id { get; set; }
    public String Title { get; set; }
    public String? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public Decimal? Price { get; set; }
    public Int32? TotalHours { get; set; }
    public Byte? Rating { get; set; }

    public String ImageUrl { get; set; } = "https://loremflickr.com/320/240";
    public Int32? CategoryId { get; set; }

    public Category? Category { get; set; }
}