namespace Application.Services.Common;
internal sealed class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}