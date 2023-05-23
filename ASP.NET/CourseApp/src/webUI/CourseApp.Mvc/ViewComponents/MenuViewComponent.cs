using CourseApp.DataTransferObjects.Responses;
using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseApp.Mvc.ViewComponents;
public class MenuViewComponent : ViewComponent {
    private readonly ICategoryService categoryService;

    public MenuViewComponent(ICategoryService categoryService) {
        this.categoryService = categoryService;
    }

    public IViewComponentResult Invoke() {
        IEnumerable<CategoryDisplayResponse> categories = this.categoryService.GetCategoriesForList();
        return this.View(categories);
    }
}