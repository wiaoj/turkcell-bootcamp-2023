// 1. Yol: Kaç elemandan oluşacağını biliyorum ama değerlerini bilmiyorum.
String[] books = new String[8];

// 2. Yol: Kaç elemandan oluşacağını da değerlerini de biliyorum!
String[] seasons = new[] { "İlkbahar", "Yaz", "Sonbahar", "Kış" };

books[0] = "Yüzüklerin Efendisi";
books[7] = "Otostopçunun Galaksi Rehberi";

//books[8] => Runtime'da hata verir

Console.WriteLine(seasons[1]);
Console.WriteLine(seasons[3]);
Console.WriteLine(seasons[^1]); // seasons[^1]


/*
 * 42 
 * Kırk ik
 * 
 * 52418
 * 
 * 13.695.598
 * 
 */

String[] tensDigit = {
    "",
    "on",
    "yirmi",
    "otuz",
    "kırk",
    "elli",
    "altmış",
    "yetmiş",
    "seksen",
    "doksan"
};
String[] digit = {
    "",
    "bir",
    "iki",
    "üç",
    "dört",
    "beş",
    "altı",
    "yedi",
    "sekiz",
    "dokuz"
};
Console.WriteLine("İki basamaklı bir sayı giriniz: ");
Int32 number = Convert.ToInt32(Console.ReadLine());

Int32 tensDigitValue = number / 10;
Int32 digitValue = number % 10;

String response = $"{tensDigit[tensDigitValue]} {digit[digitValue]}";

Console.WriteLine(response);

for(Int32 i = 0; i < 100; i++) {
    Int32 tensDigitValue1 = i / 10;
    Int32 digitValue1 = i % 10;

    String response1 = $"{tensDigit[tensDigitValue1]} {digit[digitValue1]}";

    Console.WriteLine(response1);
}