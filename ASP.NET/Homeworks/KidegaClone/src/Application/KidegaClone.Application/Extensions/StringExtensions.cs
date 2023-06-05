namespace KidegaClone.Application.Extensions;
public static class StringExtensions {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns>If it is null or contains empty space, return true.</returns>
    public static Boolean IsNotNullOrWhiteSpace(this String? value) {
        return String.IsNullOrWhiteSpace(value) is false;
    }
    
    public static String ReplaceWithWhiteSpace(this String value, String characterToReplace) {
        return value.Replace(characterToReplace, " ");
    }
}