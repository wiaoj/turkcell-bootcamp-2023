using CourseApp.Entities;
using CourseApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Repositories;
public sealed class EFCategoryRepository : ICategoryRepository {
    private readonly CourseDbContext courseDbContext;

    public EFCategoryRepository(CourseDbContext courseDbContext) {
        this.courseDbContext = courseDbContext;
    }

    public async Task CreateAsync(Category entity) {
        await this.courseDbContext.Categories.AddAsync(entity);
        await this.courseDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Int32 id) {
        var deletingCategory = await this.courseDbContext.Categories.FindAsync(id);
        this.courseDbContext.Remove(id);
        await this.courseDbContext.SaveChangesAsync();
    }

    public Category? Get(Int32 id) {
        return this.courseDbContext.Categories.FirstOrDefault(category => category.Id == id);
    }

    public IList<Category?> GetAll() {
        return this.courseDbContext.Categories.AsNoTracking().ToList();
    }

    public async Task<IList<Category?>> GetAllAsync() {
        return await this.courseDbContext.Categories.AsNoTracking().ToListAsync();
    }

    public IList<Category> GetAllWithPredicate(Expression<Func<Category, Boolean>> predicate) {
        return this.courseDbContext.Categories.Where(predicate).ToList();
    }

    public Task<Category?> GetAsync(Int32 id) {
        return this.courseDbContext.Categories.FirstOrDefaultAsync(category => category.Id == id);
    }

    public async Task UpdateAsync(Category entity) {
        this.courseDbContext.Categories.Update(entity);
        await courseDbContext.SaveChangesAsync();
    }
}