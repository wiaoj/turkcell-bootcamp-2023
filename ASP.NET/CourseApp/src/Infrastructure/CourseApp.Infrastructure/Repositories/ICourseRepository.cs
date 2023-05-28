using CourseApp.Entities;

namespace CourseApp.Infrastructure.Repositories;
public interface ICourseRepository : IRepository<Course> {
    public IEnumerable<Course> GetCoursesByCategory(Int32 categoryId);
    public IEnumerable<Course> GetCoursesByTitle(String title);
}