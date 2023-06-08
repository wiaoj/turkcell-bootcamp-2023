using CourseApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseApp.API.Filters;
public class IsExistsFilter : IAsyncActionFilter {
    private readonly ICourseService courseService;

    public IsExistsFilter(ICourseService courseService) {
        this.courseService = courseService;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {

        //Boolean idParametersIsExists = context.ActionArguments.ContainsKey("id");

        //if(idParametersIsExists is false) {
        //    context.Result = new BadRequestObjectResult(new {
        //        message = $"{context.ActionDescriptor.DisplayName} id parametresini içermelidir"
        //    });
        //}

        //Int32 id = (Int32)context.ActionArguments["id"];
        //if(await this.courseService.CourseIsExists(id) is false) {
        //    context.Result = new NotFoundObjectResult(new {
        //        message = $"{id}'li kurs bulunamadı"
        //    });
        //}

        Boolean idParametersIsExists = context.ActionArguments.TryGetValue("id", out object? id);
        if(idParametersIsExists is false) {
            context.Result = new BadRequestObjectResult(new {
                message = $"{context.ActionDescriptor.DisplayName} id parametresini içermelidir"
            });
        }

        if(await this.courseService.CourseIsExists((Int32)id!) is false) {
            context.Result = new NotFoundObjectResult(new {
                message = $"{id}'li kurs bulunamadı"
            });
        }

        await next.Invoke();
    }
}