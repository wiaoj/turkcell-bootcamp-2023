using CourseApp.Entities;
using Microsoft.Extensions.Configuration;

namespace CourseApp.Infrastructure.Repositories.Dapper;
public class DapperCategoryRepository : DapperRepositoryBase<Category>, ICategoryRepository {
    public DapperCategoryRepository(IConfiguration configuration) : base(configuration) { }
}