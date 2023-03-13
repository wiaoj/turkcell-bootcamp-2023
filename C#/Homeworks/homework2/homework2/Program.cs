/*
 * 1. En az 6 karakter
 * 2. Sadece harf ya da sadece sayı ya da sadece alfanümerik olmayan ise ZAYIF
 * 3. Hem harf hem sayı ise ORTA
 * 4. Hem sayı, hem harf hemde alfanümerik olmayan bir karakter varsa GÜÇLÜ şifre desin
 * 
 * İpucu:
 * char(.)
 */
Boolean isContainsWord = default,
        isContainsNumber = default,
        isContainsAlphanumerics = default;

Console.Write("Bir şifre giriniz: ");
String? password = Console.ReadLine();

if(password?.Length < 6) {
    Console.WriteLine($"Şifreniz en az 6 karakter olmalıdır siz {password.Length} karakter girdiniz.");
    return;
}

CheckPassword(isContainsWord, isContainsNumber, isContainsAlphanumerics, password!);

ShowOnScreen();

void ShowOnScreen() {
    String message = String.Empty;
    if(isContainsWord && isContainsNumber && isContainsAlphanumerics) {
        message = "Güçlü";
    } else if(isContainsWord && isContainsNumber) {
        message = "Orta";
    } else {
        message = "Zayıf";
    }

    Console.WriteLine(message);
}

static Boolean CheckWords(Char character) {
    const String words = "abcdefghijklmnopqrstuvwxyz";
    return words.IndexOf(character, 0) is not -1;
}

static Boolean CheckNumbers(Char character) {
    const String numbers = "0123456789";
    return numbers.IndexOf(character, 0) is not -1;
}

static Boolean CheckAlphanumerics(Char character) {
    const String alphanumerics = "@$#*&{}[]–=,.();+‘/";
    return alphanumerics.IndexOf(character, 0) is not -1;
}

static void CheckPassword(Boolean isContainsWord, Boolean isContainsNumber, Boolean isContainsAlphanumerics, String password) {
    foreach(Char character in password) {
        isContainsWord = isContainsWord is false && CheckWords(character);

        isContainsNumber = isContainsNumber is false && CheckNumbers(character);

        isContainsAlphanumerics = isContainsAlphanumerics is false && CheckAlphanumerics(character);
    }
}