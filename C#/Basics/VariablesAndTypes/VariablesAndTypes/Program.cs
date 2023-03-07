// See https://aka.ms/new-console-template for more information
using System.Numerics;

Console.WriteLine("Hello, World!");


/*
 * Sayısal
 *  - Tam Sayı
 *  - Ondalıklı Sayı
 * Sözel
 * Mantıksal
 */

//Sayısal

//Değişken tanımlama kuralı
Byte byteValue = 255; // Byte.MaxValue
SByte signedByteValue = 127; // SByte.MaxValue - SByte.MinValue = -128
Int16 int16Value = 32_767; // short
UInt16 unsignedByteValue = 65535; // ushort
UInt128 int128Value = UInt128.MaxValue;

// 8 - 16 - 32 - 64 bit olarak kullanıyoruz
// 8 bit olan hariç diğerleri varsayılan olarak negatif olabiliryor
// 8 bit negatif olması gerektiği zaman SByte olarak kullanılabilir,
// diğerleri UInt veya başına U ekleyerek kullanılabilir

Double pi = 3.14;
Single singleValue = 3.14F;
Decimal decimalValue = 3.14000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001M;


//Sözel
Char symbol = '!';
String name = "Bertan"; // Char dizisidir

//Mantıksal
Boolean isBoolean = default;

byte x = 255;
byte y = 2;
byte result = (byte)(x + y);
Console.WriteLine(result); // hata vermez sıfırlanır ve sonuç 1 olur

try {
    // checked ile otomatik dönüştürmeyi engelleyip hata fırlatmasını sağlayabiliyoruz
    checked {
        byte checkedResult = (byte)(x + y);
        Console.WriteLine(checkedResult);
    }
} catch(OverflowException) {
    Console.WriteLine($"Toplam byte sınırlarını ({byte.MaxValue}) aştığı için işlem başarısız.");
}

Console.Write("Lütfen kilonuzu giriniz: ");
Int32 weight = Int32.Parse(Console.ReadLine()); // C# convert yöntemi

Console.Write("Lütfen boyunuzu cm olarak giriniz: ");
Double height = Convert.ToDouble(Console.ReadLine()); //.Net convert yöntemi

Double bmi = weight / Math.Pow(height, 2);
Console.WriteLine(bmi);
