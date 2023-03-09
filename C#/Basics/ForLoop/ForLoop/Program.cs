// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Int32[] numbers = { 13, 46, 0, 1, 18, -9 };

for(Int32 i = 0; i < numbers.Length; i++) {
    Console.WriteLine(numbers[i]);
}

String[] countries = { "Türkiye", "Almanya", "Hollanda", "İsveç", "Kıbrıs" };

Console.Write("Bir ülke giriniz: ");
String country = Console.ReadLine();

Boolean isFind = default; // Flag
for(int index = 0; index < countries.Length; index++) {
    if(countries[index].Equals(country, StringComparison.CurrentCultureIgnoreCase)) {
        isFind = true;
        break;
    }
}

String message = isFind ? "Array içerisinde bulunuyor!" : "Array içerisinde bulunmuyor!";
Console.WriteLine(message);