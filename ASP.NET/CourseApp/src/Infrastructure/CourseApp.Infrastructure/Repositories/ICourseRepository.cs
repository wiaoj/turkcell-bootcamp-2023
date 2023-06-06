using CourseApp.Entities;

namespace CourseApp.Infrastructure.Repositories;
public interface ICourseRepository : IRepository<Course> {
    public IEnumerable<Course> GetCoursesByCategory(Int32 categoryId);
    public IEnumerable<Course> GetCoursesByTitle(String title);
    public Task<IEnumerable<Course>> GetCoursesByCategoryAsync(Int32 categoryId);
    public Task<IEnumerable<Course>> GetCoursesByTitleAsync(String title);
}