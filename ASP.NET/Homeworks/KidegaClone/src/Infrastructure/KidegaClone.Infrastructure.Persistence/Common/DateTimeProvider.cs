using KidegaClone.Application.Common;

namespace KidegaClone.Infrastructure.Persistence.Common;
internal class DateTimeProvider : IDateTimeProvider {
    public DateTime UtcNow => DateTime.UtcNow;
}