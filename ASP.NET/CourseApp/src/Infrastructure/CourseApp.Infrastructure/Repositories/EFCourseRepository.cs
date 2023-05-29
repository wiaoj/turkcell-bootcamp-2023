using CourseApp.Entities;
using CourseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Repositories;
public sealed class EFCourseRepository : ICourseRepository {
    private readonly CourseDbContext courseDbContext;

    public EFCourseRepository(CourseDbContext courseDbContext) {
        this.courseDbContext = courseDbContext;
    }
    public async Task CreateAsync(Course entity) {
        await this.courseDbContext.Courses.AddAsync(entity);
        await this.courseDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Int32 id) {
        var deletingCourse = await this.courseDbContext.Courses.FindAsync(id);
        this.courseDbContext.Remove(deletingCourse);
        await this.courseDbContext.SaveChangesAsync();
    }

    public Course? Get(Int32 id) {
        return this.courseDbContext.Courses.FirstOrDefault(category => category.Id == id);
    }

    public IList<Course?> GetAll() {
        return this.courseDbContext.Courses.AsNoTracking().ToList();
    }

    public async Task<IList<Course?>> GetAllAsync() {
        return await this.courseDbContext.Courses.AsNoTracking().ToListAsync();
    }

    public IList<Course> GetAllWithPredicate(Expression<Func<Course, Boolean>> predicate) {
        return this.courseDbContext.Courses.AsNoTracking().Where(predicate).ToList();
    }

    public async Task<Course?> GetAsync(Int32 id) {
        return await this.courseDbContext.Courses.FirstOrDefaultAsync(category => category.Id == id);
    }

    public IEnumerable<Course> GetCoursesByCategory(Int32 categoryId) {
        return this.courseDbContext.Courses.AsNoTracking().Where(course => course.CategoryId == categoryId).AsEnumerable();
    }

    public IEnumerable<Course> GetCoursesByTitle(String title) {
        return this.courseDbContext.Courses.Where(course => course.Title.Contains(title)).AsEnumerable();
    }

    public async Task UpdateAsync(Course entity) {
        this.courseDbContext.Courses.Update(entity);
        await courseDbContext.SaveChangesAsync();
    }
}