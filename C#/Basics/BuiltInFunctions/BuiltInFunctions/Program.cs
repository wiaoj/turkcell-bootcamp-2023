// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

String word = "bilgisayar";

Console.WriteLine(word.ToUpper());
Console.WriteLine(word.Substring(5));

Int32 index = word.IndexOf('i', 0);
index = word.IndexOf('i', 2); // ilk inin indexi 1 olduğu için onu atlamasını sağlıyor
Console.WriteLine(index);

/*
 * harf bulamaz ise -1 dönüyor.
 * belirli bir noktadan aramaya başlayabiliyor.
 * ilk karşılaştığı index değerini veriyor
 * 
 * -1 olmadığı sürece
 * bir başlangıç noktasından harfi ara
 * başlangıç noktasını bulunandan bir fazlası yap
 */

Int32 startIndex = default;
//Boolean isFind = word.IndexOf('i', startIndex) is not -1;

while(word.IndexOf('i', startIndex) is not -1) {
    Int32 findingIndex = word.IndexOf('i', startIndex);
    startIndex = findingIndex + 1;
    Console.WriteLine($"i harfinin indexi: {findingIndex}");
    //isFind = word.IndexOf('i', startIndex) is not -1;
}

/*
 * 1. En az 6 karakter
 * 2. Sadece harf ya da sadece sayı ya da sadece alfanümerik olmayan ise ZAYIF
 * 3. Hem harf hem sayı ise ORTA
 * 4. Hem sayı, hem harf hemde alfanümerik olmayan bir karakter varsa GÜÇLÜ şifre desin
 * 
 * İpucu:
 * char(.)
 */