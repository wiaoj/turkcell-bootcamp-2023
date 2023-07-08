using Domain.Entities;

namespace Infrastructure.Persistence.Extensions;
public static class StringExtensions {
    public static string TrimEntity(this string value) {
        return value.Contains(nameof(Entity)) ? value.Replace(nameof(Entity), String.Empty) : value;
    }    
}