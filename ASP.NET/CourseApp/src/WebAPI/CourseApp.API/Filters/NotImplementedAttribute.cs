using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CourseApp.API.Filters;
public class NotImplementedAttribute : ExceptionFilterAttribute {
    public override void OnException(ExceptionContext context) {
        if(context.Exception is NotImplementedException notImplementedException) {
            String message = $"İstek gönderdiğiniz adreste, herhangi bir geliştirme yapılmamıştır. İlgili adres: {context.ActionDescriptor.DisplayName}";

            context.Result = new BadRequestObjectResult(new {
                errorMessage = message
            });
        }
    }
}