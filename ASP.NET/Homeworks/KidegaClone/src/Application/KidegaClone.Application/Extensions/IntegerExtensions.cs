namespace KidegaClone.Application.Extensions;
public static class IntegerExtensions {
    public static Boolean IsGreaterThanZero(this Int32 value) {
        return value > default(Int32);
    }
}