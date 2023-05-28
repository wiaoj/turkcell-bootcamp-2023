using CourseApp.Entities;
using System.Linq.Expressions;

namespace CourseApp.Infrastructure.Repositories;
public sealed class FakeCategoryRepository : ICategoryRepository {
    private List<Category> categories;

    public FakeCategoryRepository() {
        this.categories = new() {
            new() { Id = 1, Name = "Language", },
            new() { Id = 2, Name = "Programming", },
            new() { Id = 3, Name = "Philosophy", },
        };
    }

    public Task CreateAsync(Category entity) {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public Category? Get(Int32 id) {
        throw new NotImplementedException();
    }

    public IList<Category?> GetAll() {
        return this.categories;
    }

    public Task<IList<Category?>> GetAllAsync() {
        throw new NotImplementedException();
    }

    public IList<Category> GetAllWithPredicate(Expression<Func<Category, Boolean>> predicate) {
        throw new NotImplementedException();
    }

    public Task<Category?> GetAsync(Int32 id) {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Category entity) {
        throw new NotImplementedException();
    }
}