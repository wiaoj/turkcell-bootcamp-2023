// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Sayı bulmaca oyunu
// Bilgisayar bir sayı tutsun
// 2. adım kullanıcı tahmin etmeye çalışsın
// Tahmin ile sayı bulunana dek; 2. adım tekrarlansın

Random randomNumberGenerator = new();
Int32 puzzle = randomNumberGenerator.Next(0, 100);
Boolean isWin = false;

while(isWin is false) {
    Console.Write("Lütfen tahminizi girin: ");
    Int32 suggest = Convert.ToInt32(Console.ReadLine());

    if(suggest < puzzle) {
        Console.WriteLine("Yukarı");
    } else if(suggest > puzzle) {
        Console.WriteLine("Aşağı");
    } else {
        isWin = true;
        Console.WriteLine("Doğru cevap!");
    }
}

Int32[] numbers = { 13, 46, 0, 1, 18, -9 };

/*
 * Index değeri numbers array'inin eleman sayısından az olduğu sürece
 * numbers array'inin her index'indeki değeri ekranda göster
 * ardından index değerini arttır
 */
Int32 index = default;
while(index < numbers.Length) {
    Console.WriteLine(numbers[index++]);
}