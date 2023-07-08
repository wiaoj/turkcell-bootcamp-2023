namespace Application.Services.Common;
public interface IDateTimeProvider {
    DateTime UtcNow { get; }
}