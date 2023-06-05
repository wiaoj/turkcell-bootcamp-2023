namespace CustomMiddlewares.Middlewares;
public class RequestLoggingMiddleware {
    private readonly RequestDelegate next;
    private readonly ILogger<RequestLoggingMiddleware> logger;

    public RequestLoggingMiddleware(
        RequestDelegate next,
        ILogger<RequestLoggingMiddleware> logger) {
        this.next = next;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext httpContext) {
        /*
         * Bu middleware'in amacı; API'a gelen her requesti
         * yakalamak ve bilgi vermektir
         */

        this.logger.LogInformation($"{DateTime.UtcNow} - Gelen request metodu: {httpContext.Request.Method} - Gönderildiği adres: {httpContext.Request.Path}");

        // 1. Oluşacak olan yanıtı responseBodyStream değişkeninde tut, OOP -> Heap
        Stream responseBodyStream = httpContext.Response.Body;
        // Yanıtın bir kopyasını tutmak için yeni bir bellek akışı oluşturuluyor.
        using MemoryStream responseStream = new();
        // Yanıt akışı, oluşturulan bellek akışına yönlendiriliyor.
        httpContext.Response.Body = responseStream;

        // Sonraki middleware'i çağırmak ve işlem zincirinin devamını sağlamak için await kullanılıyor.
        await this.next(httpContext);

        // Bellek akışını başa sararak yanıtın okunabilir hale getirilmesi sağlanıyor
        responseStream.Seek(default, SeekOrigin.Begin);

        // Yanıtın içeriğini okumak için bir StreamReader kullanılıyor.
        using StreamReader streamReader = new(responseStream);
        String responseBody = streamReader.ReadToEnd();

        this.logger.LogInformation($"{DateTime.UtcNow} anında response oluşturuldu.");
        this.logger.LogInformation($"Oluşan response: {httpContext.Response.StatusCode} -> {responseBody}");

        // Bellek akışını başa sararak yanıtın orijinal akışa kopyalanması sağlanıyor.
        responseStream.Seek(default, SeekOrigin.Begin);
        // önceden hazırlanan responseBodyStream'e önceden oluşan yanıtı kopyala
        await responseStream.CopyToAsync(responseBodyStream);
    }
}