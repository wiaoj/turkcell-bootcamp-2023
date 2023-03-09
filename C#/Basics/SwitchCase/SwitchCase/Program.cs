// See https://aka.ms/new-console-template for more information
Console.WriteLine("Bir şekil seçin (Kare, Daire, Üçgen)!");
String geometry = Console.ReadLine();
if(geometry.Equals("Kare")) {
    Console.WriteLine("Kare");
} else if(geometry.Equals("Daire")) {
    Console.WriteLine("Daire");
} else if(geometry.Equals("Üçgen")) {
    Console.WriteLine("Üçgen");
}

// Mutlak eşitlikte switch kullanılması daha doğru olur
switch(geometry) {
    case "Kare":
        Console.WriteLine("Kare");
        break;
    case "Daire":
        Console.WriteLine("Daire");
        break;
    case "Üçgen":
        Console.WriteLine("Üçgen");
        break;
    default:
        break;
}

switch(DateTime.Now.DayOfWeek) {
    case DayOfWeek.Sunday:
        break;
    case DayOfWeek.Monday:
        break;
    case DayOfWeek.Tuesday:
        break;
    case DayOfWeek.Wednesday:
        break;
    case DayOfWeek.Thursday:
        break;
    case DayOfWeek.Friday:
        break;
    case DayOfWeek.Saturday:
        break;
    default:
        break;
}

Console.WriteLine("Bir sembol seçiniz (Sinek, Maça, Kupa, Karo)");
String symbol = Console.ReadLine();

switch(symbol) {
    case "Sinek" or "Maça":
        Console.WriteLine("Siyah renk");
        break;
    case "Karo":
    case "Kupa":
        Console.WriteLine("Kırmızı renk");
        break;
    default:
        break;
}
