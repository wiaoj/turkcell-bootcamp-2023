namespace ExtensionMethods;
public static class Extensions {
    // Class static olmalıdır.
    // Extend edilen tip this ile tanımlanır.
    public static Double GetSquare(this Int32 value) {
        return Math.Pow(value, 2);
    }

    public static String MergeWords(this String value) {
        return value.Replace(" ", String.Empty);
    }
}