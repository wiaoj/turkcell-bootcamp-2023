using CourseApp.Entities;
using System.Collections.Generic;
using System.Reflection;

namespace CourseApp.Infrastructure.Extensions;
public static class EntityExtensions {
    public static String GetDatabaseTableName(this IEntity entity) {
        return nameof(entity);
    }

    public static String GetInsertColumns(this IEntity entity) {
        return String.Join(", ", entity.getPropertyNames());
    }

    public static String GetInsertValues(this IEntity entity) {
        return String.Join(", ", entity.getPropertyNames(property => $"@{property.Name}"));
    }

    public static String GetUpdateColumnsValues(this IEntity entity) {
        return String.Join(", ",
            entity.getPropertyNames(property => $"{property.Name} = @{property.Name}"));
    }


    private static IEnumerable<String> getPropertyNames(this IEntity entity) {
        return entity.getEntityPropertyInfo().Select(property => $"{property.Name}");
    }

    private static IEnumerable<String> getPropertyNames(this IEntity entity, Func<PropertyInfo, String> selector) {
        return entity.getEntityPropertyInfo().Select(selector);
    }

    private static IEnumerable<PropertyInfo> getEntityPropertyInfo(this IEntity entity) {
        return typeof(IEntity).GetProperties()
                               .Where(property => 
                                       property.Name is not "Id" && 
                                       property.CanRead && 
                                       property.PropertyType.IsValueType);
    }
}