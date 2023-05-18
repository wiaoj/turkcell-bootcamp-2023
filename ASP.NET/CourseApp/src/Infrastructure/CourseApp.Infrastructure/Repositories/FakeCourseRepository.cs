using CourseApp.Entities;

namespace CourseApp.Infrastructure.Repositories;
public sealed class FakeCourseRepository : ICourseRepository {
    private List<Course> courses;

    public FakeCourseRepository() {
        this.courses = new() {
            new() {
                Id = 1,
                Title = "Course X",
                Description = "Description X",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
            },
            new() {
                Id = 2,
                Title = "Course Y",
                Description = "Description Y",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
            },
            new() {
                Id = 3,
                Title = "Course Z",
                Description = "Description Z",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
            },
            new() {
                Id = 4,
                Title = "Course Q",
                Description = "Description Q",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
            }
        };
    }

    public Course? Get(Int32 id) {
        throw new NotImplementedException();
    }

    public IList<Course?> GetAll() {
        return this.courses;
    }

    public Task<IList<Course?>> GetAllAsync() {
        throw new NotImplementedException();
    }

    public Task<Course?> GetAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public IEnumerable<Course> GetCoursesByCategory(Int32 categoryId) {
        throw new NotImplementedException();
    }

    public IEnumerable<Course> GetCoursesByName(String name) {
        throw new NotImplementedException();
    }
}
