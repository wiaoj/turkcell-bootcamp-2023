using CourseApp.Entities;
using CourseApp.Infrastructure.Extensions;
using Dapper;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;

namespace CourseApp.Infrastructure.Repositories.Dapper;
public class DapperCourseRepository : DapperRepositoryBase<Course>, ICourseRepository {
    public DapperCourseRepository(IConfiguration configuration) : base(configuration) { }

    public IEnumerable<Course> GetCoursesByCategory(Int32 categoryId) {
        IEnumerable<Course> courses =
            this.connection.Query<Course>(
                $@"SELECT * FROM {Entity.GetDatabaseTableName()} 
                WHERE CategoryId = @CategoryId",
                new { CategoryId = categoryId });
        return courses;
    }

    public IEnumerable<Course> GetCoursesByTitle(String title) {
        IEnumerable<Course> courses =
            this.connection.Query<Course>(
                $@"SELECT * FROM {Entity.GetDatabaseTableName()}
                WHERE Title LIKE CONCAT('%', @Title, '%')",
                new { Title = title });
        return courses;
    }
}