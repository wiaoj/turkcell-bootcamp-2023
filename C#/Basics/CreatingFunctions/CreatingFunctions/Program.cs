/*
 * 1. Bir kelime koleksiyonu içinden rastgele bir kelime SEÇ
 * 2. Seçilen kelimeyi, "* * * *" biçiminde bulmacaya ÇEVİR.
 * 3. Kullanıcıdan harf İSTE.
 * 4. Girilen Harfi Kelimede ARA.
 * 5. Varsa; o yıldızı harfe çevir.
 * 6. Tüm *'lar açılana kadar bu adımları tekrar etsin.
 */

List<String> words = new() { "ayna" };
String choosingWord = getRandomWord(words);
String puzzledWord = convertToPuzzle(choosingWord);
showOnScreen(puzzledWord);
String suggestedLetter = getLetterFromUser();

if(isLetterFindInWord(choosingWord, suggestedLetter)) {
    puzzledWord = replaceStartWithLetter(choosingWord, puzzledWord, suggestedLetter);
    showOnScreen(puzzledWord);
} else {
    showOnScreen("Bir hakkınız yandı...");
}


String getRandomWord(List<String> words) { // 1.
    Int32 index = new Random().Next(words.Count);
    return words[index];
}

String convertToPuzzle(String word) { // 2.
    String puzzle = String.Empty;

    for(Int32 i = default; i < word.Length; ++i) {
        puzzle += i.Equals(word.Length - 1) ? "*" : "* ";
    }

    return puzzle;
}

void showOnScreen(String word) {
    Console.WriteLine(word);
}

String getLetterFromUser() { // 3.
    showOnScreen("Bir harf giriniz: ");
    return Console.ReadLine() ?? String.Empty;
}

Boolean isLetterFindInWord(String word, String letter) { // 4.
    return word.Contains(letter, StringComparison.InvariantCultureIgnoreCase);
}

String replaceStartWithLetter(String puzzle, String word, String letter) { // 5.

    while(word.IndexOf(letter, 0) is not -1) {
        // içi doldurularak gerekli aşağıdaki formatta çıktı alınabilir..
    }

    return "a * * a";
}

// Clean Code kitabından alıntı
// En iyi kod; tek satırdan oluşur der ve bu örneği verir:

//Boolean isEven(Int32 number) {
//    return number % 2 is 0;
//}
// Elbette, her fonksiyonu bu şekilde yazmak mümkün değildir