using CourseApp.Entities;

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

    public Category? Get(Int32 id) {
        throw new NotImplementedException();
    }

    public IList<Category?> GetAll() {
        return this.categories;
    }

    public Task<IList<Category?>> GetAllAsync() {
        throw new NotImplementedException();
    }

    public Task<Category?> GetAsync(Int32 id) {
        throw new NotImplementedException();
    }
}