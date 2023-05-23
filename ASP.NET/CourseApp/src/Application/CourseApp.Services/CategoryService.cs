using AutoMapper;
using CourseApp.DataTransferObjects.Responses;
using CourseApp.Infrastructure.Repositories;
using CourseApp.Services.Extensions;

namespace CourseApp.Services;
public sealed class CategoryService : ICategoryService {
    private readonly IMapper mapper;
    private readonly ICategoryRepository categoryRepository;

    public CategoryService(IMapper mapper, ICategoryRepository categoryRepository) {
        this.mapper = mapper;
        this.categoryRepository = categoryRepository;
    }

    public IEnumerable<CategoryDisplayResponse> GetCategoriesForList() {
        var categories = this.categoryRepository.GetAll();
        return categories.ConvertToDto(this.mapper);
    }
}