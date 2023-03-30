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

    public static String GetPasswordStrength(this String value) {
        Boolean includeLetter = default;
        Boolean includeDigit = default;
        Boolean includeSymbol = false;

        value.ToCharArray().ToList().ForEach(character => {
            if(char.IsLetter(character)) {
                includeLetter = true;

            } else if(char.IsDigit(character)) {
                includeDigit = true;

            } else {
                includeSymbol = true;
            }
        });

        String result = String.Empty;

        if(includeLetter && includeDigit && includeSymbol) {
            result = "Güçlü";
        } else if(includeLetter && includeDigit && includeSymbol is false) {
            result = "Orta";
        } else {
            result = "Zayıf";
        }

        return result;
    }

    public static Char NextChar(this Random random, Boolean isUpper) {
        return (Char)(isUpper ? random.Next(65, 91) : random.Next(97, 123));
    }

    public static String NextWord(this Random random, Int32 length)
        => NextWord(random, length, false);

    public static String NextWord(this Random random, Int32 length, Boolean isUpper) {
        String output = String.Empty;

        for(Int32 index = default; index < length; index++) {
            output += random.NextChar(isUpper);
        }

        return output;
    }
}