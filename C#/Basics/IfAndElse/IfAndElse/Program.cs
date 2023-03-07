// See https://aka.ms/new-console-template for more information
Console.WriteLine("Kullanıcı adını giriniz");
String name = Console.ReadLine()!;
Console.WriteLine("Şifrenizi giriniz");
String password = Console.ReadLine()!;

//Parantez içine önerme deniliyor
// & => sol taraf yanlış olsa da sağ tarafı kontrol eder
// && => sol taraf yanlış ise sağ tarafı kontrol etmez
if(name.Equals("bertan", StringComparison.InvariantCultureIgnoreCase) && password.Equals("1234")) {
    Console.WriteLine("Hoşgeldin");
} else if(name.Equals("bertan1") & password.Equals("4321")) { // yukarıdaki if çalışmazsa burası çalışır mı diye kontrol ediyor
    Console.WriteLine("Bertan değil miydi?");
} else {
    Console.WriteLine("Kimsin sen?");
}

Console.WriteLine("Hangi aydasın?");
String month = Console.ReadLine();
Boolean isSpring = month.Equals("Mart")
    || month.Equals("Mayıs")
    || month.Equals("Mayıs");
// || => mart değilse diğerine bakar
// | => mart olsa bile diğer durumu da kontrol eder
if(isSpring) {
    Console.WriteLine("İlkbahar mevsimindesiniz");
}

Console.WriteLine("Bir sayı giriniz: ");
Int32 number = Convert.ToInt32(Console.ReadLine());
String message = String.Empty;

if((number % 2).Equals(default)) {
    message = "Çifttir";
} else {
    message = "Tektir";
}

// Ternary operatörü
String message2 = (number % 2).Equals(default) ? "Çifttir" : "Tektir";

String greetings = DateTime.Now.Hour <= 17 ? "İyi günler" : "İyi akşamlar";

Console.WriteLine(message2);
Console.WriteLine(greetings);
