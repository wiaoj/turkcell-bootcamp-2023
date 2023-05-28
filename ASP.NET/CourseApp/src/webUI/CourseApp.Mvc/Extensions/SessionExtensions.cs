using System.Text.Json;

namespace CourseApp.Mvc.Extensions;
public static class SessionExtensions {
    public static T? GetJson<T>(this ISession session, String key) where T : class, new() {
        String? serializedString = session.GetString(key);

        return serializedString is null
            ? default
            : JsonSerializer.Deserialize<T>(serializedString)!;
    }

    public static void SetJson<T>(this ISession session, String key, T value) {
        String? serialized = JsonSerializer.Serialize<T>(value);
        session.SetString(key, serialized);
    }
}