// See https://aka.ms/new-console-template for more information

try {
    Console.Write("Bir sayı giriniz: ");
    var number1 = Convert.ToInt32(Console.ReadLine());

    Console.Write("Bir sayı daha giriniz: ");

    Int32 number2 = Convert.ToInt32(Console.ReadLine());

    Int32 dividedNumber = number1 / number2;

    Console.WriteLine($"Bölme işleminin sonucu: {dividedNumber}");

} catch(FormatException) {
    Console.WriteLine("Girilen ifade sayı değildir.");
} catch(DivideByZeroException) {
    Console.WriteLine("Herhangi bir tam sayı 0'a bölünemez.");
} catch(Exception exception) {
    Console.WriteLine($"Bir hata oluştu: {exception.Message}");
} finally {
    Console.WriteLine("Burası mutlaka çalışması gerekiyor...");
}