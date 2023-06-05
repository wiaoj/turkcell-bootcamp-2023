namespace CustomMiddlewares.Middlewares;
public class BadWordsHandlerMiddleware {
    private readonly RequestDelegate next;

    public BadWordsHandlerMiddleware(RequestDelegate next) {
        this.next = next;
    }

    public async Task Invoke(HttpContext context) {
        String? jsonBody = (String?)context.Items["JsonBody"];

        List<String> badWords = new() { "pis", "manyak", "kötü", "kelime" };
        Boolean isContainBadWords = badWords.Any(jsonBody.Contains);

        if(isContainBadWords) {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new {
                message = "Gönderdiğiniz yorumda hoş olmayan ifadeler mevcut"
            });
            return;
        }

        await this.next(context);
    }
}