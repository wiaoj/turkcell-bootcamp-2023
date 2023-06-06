using CourseApp.Entities;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Repositories;
public sealed class FakeCourseRepository : ICourseRepository {
    private List<Course> courses;

    public FakeCourseRepository() {
        this.courses = new() {
            new() {
                Id = 1,
                Title = "Course X",
                Description = "Description X",
                Price = 1.45M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 1
            },
            new() {
                Id = 2,
                Title = "Course Y",
                Description = "Description Y",
                Price = 100.78M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 1
            },
            new() {
                Id = 3,
                Title = "Course Z",
                Description = "Description Z",
                Price = 17.95M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 1
            },
            new() {
                Id = 4,
                Title = "Course Q",
                Description = "Description Q",
                Price = 10784.874M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 1
            },
             new() {
                Id = 5,
                Title = "Course A",
                Description = "Description A",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 1
            },
            new() {
                Id = 6,
                Title = "Course B",
                Description = "Description B",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 2
            },
            new() {
                Id = 7,
                Title = "Course C",
                Description = "Description C",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 2
            },
            new() {
                Id = 8,
                Title = "Course D",
                Description = "Description D",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 2
            },
            new() {
                Id = 9,
                Title = "Course D1",
                Description = "Description D1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 2
            },
            new() {
                Id = 10,
                Title = "Course D1",
                Description = "Description D2",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 2
            },
            new() {
                Id = 11,
                Title = "Course X1",
                Description = "Description X1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            },
            new() {
                Id = 12,
                Title = "Course Y1",
                Description = "Description Y1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            },
            new() {
                Id = 13,
                Title = "Course Z1",
                Description = "Description Z1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            },
            new() {
                Id = 14,
                Title = "Course Q1",
                Description = "Description Q1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            },
             new() {
                Id = 15,
                Title = "Course A1",
                Description = "Description A1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            },
            new() {
                Id = 16,
                Title = "Course B1",
                Description = "Description B1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            },
            new() {
                Id = 17,
                Title = "Course C1",
                Description = "Description C1",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            },
            new() {
                Id = 18,
                Title = "Course D3",
                Description = "Description D3",
                Price = 1M,
                Rating = 4,
                TotalHours = 20,
                CategoryId = 3
            }
        };
    }

    public Task CreateAsync(Course entity) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public Course? Get(Int32 id) {
        return this.courses.Find(course => course.Id == id);
    }

    public IList<Course?> GetAll() {
        return this.courses;
    }

    public Task<IList<Course?>> GetAllAsync() {
        throw new NotImplementedException();
    }

    public IList<Course> GetAllWithPredicate(Expression<Func<Course, Boolean>> predicate) {
        throw new NotImplementedException();
    }

    public Task<Course?> GetAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public IEnumerable<Course> GetCoursesByCategory(Int32 categoryId) {
        return this.courses.Where(course => course.CategoryId == categoryId).AsEnumerable();
    }

    public Task<IEnumerable<Course>> GetCoursesByCategoryAsync(Int32 categoryId) {
        throw new NotImplementedException();
    }

    public IEnumerable<Course> GetCoursesByTitle(String name) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Course>> GetCoursesByTitleAsync(String title) {
        throw new NotImplementedException();
    }

    public Task<Boolean> IsExistsAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Course entity) {
        throw new NotImplementedException();
    }
}