// Boxing: Bir kutunun içerisine bir değer koymaktır.
Object @object = "Bir nesne";
@object = 9;
@object = false;
@object = new Random();

Random random = new Random();

Object empty = new Object();

Int32 x = default;
Int32 y = default;

Console.WriteLine(x == y);
Console.WriteLine(x.Equals(y));

Console.WriteLine(@object == empty);
Console.WriteLine(@object.Equals(empty));

//Object.Equals(x, y);

// ==: Referans
// Equals: Değer karşılaştırır




Address address1 = new("Hatay");
Address address2 = new("Hatay");
Address address3 = address1;


Console.WriteLine($"address1 == address2 sonucu: {address1 == address2}");
Console.WriteLine($"address1.Equals(address2) sonucu: {address1.Equals(address2)}");
Console.WriteLine("Object.ReferenceEquals: " + Object.ReferenceEquals(address1,address2));

Console.WriteLine($"address1 == address3 sonucu: {address1 == address3}");
Console.WriteLine($"address1.Equals(address3) sonucu: {address1.Equals(address3)}");

// Primitive Type => Stack'de tutulur
String deney1 = "TURKCELL";
String deney2 = "TURKCELL";
String deney3 = "TURKCELLx"[..^1]; 
// Substring [..^1] dinamik olarak son karaktere kadar alır,
// [..8] karakter seti değişse de ilk 8 karakteri alır
Object deney4 = deney3;

Console.WriteLine($"deney1 == deney2 sonucu: {deney1 == deney2}");
Console.WriteLine($"deney1.Equals(deney2) sonucu: {deney1.Equals(deney2)}");

Console.WriteLine($"deney1 {deney1.GetHashCode()} == deney3 {deney3.GetHashCode()} sonucu: {deney1 == deney3}");
Console.WriteLine($"deney1.Equals(deney3) sonucu: {deney1.Equals(deney3)}");

Console.WriteLine($"deney1 {deney1.GetHashCode()} == deney4 {deney4.GetHashCode()} sonucu: {deney1 == deney4}");
Console.WriteLine($"deney1 == (String)deney4 sonucu: {deney1 == (String)deney4}");
Console.WriteLine($"deney1 == deney4 as String sonucu: {deney1 == deney4 as String}");
Console.WriteLine($"deney1.Equals(deney4) sonucu: {deney1.Equals(deney4)}");
Console.WriteLine($"deney4.Equals(deney1) sonucu: {deney4.Equals(deney1)}");

Address? address = null; // Stackde karşılığı var ama heapde oluşmamış
Console.WriteLine(address ??= new Address("Burdur"));
Console.WriteLine(address.City);

public class Address {
    public String City { get; set; }

    public Address(String city) {
        this.City = city;
    }

    public override Boolean Equals(Object? obj) {
        Address? that = obj as Address;
        return this.City.Equals(that?.City);
    }

    public override String ToString() {
        return $"Bu adres, {this.City} şehrinde bulunuyor.";
    }

    public override Int32 GetHashCode() {
        return base.GetHashCode();
    }
}