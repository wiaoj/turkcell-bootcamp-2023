namespace CustomMiddlewares.Middlewares;
public class JsonBodyMiddleware {
    // amaç: bir request'in POST olduğunu ve json data içerdiğini anlamak
    private readonly RequestDelegate next;

    public JsonBodyMiddleware(RequestDelegate next) {
        this.next = next;
    }

    public async Task Invoke(HttpContext context) {
        if(context.Request.Method == "POST" && context.Request.ContentType.StartsWith("application/json")) {
            using StreamReader streamReader = new(context.Request.Body);
            String jsonBody = await streamReader.ReadToEndAsync();
            context.Items["JsonBody"] = jsonBody;
        }

        await this.next(context);
    }
}