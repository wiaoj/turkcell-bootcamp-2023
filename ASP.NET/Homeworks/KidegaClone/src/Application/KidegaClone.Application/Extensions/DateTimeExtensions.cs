namespace KidegaClone.Application.Extensions;
public static class DateTimeExtensions {
    public static String ToMonthYearString(this DateTime dateTime) {
        return dateTime.ToString("MMMM/yyyy").ReplaceWithWhiteSpace(".");
    }
}