namespace BuiltInInterface;
public class Person {
    public String Name { get; set; }
    public String LastName { get; set; }
    public IAddress Address { get; set; }
}

public interface IAddress { } // Marker - İşaretçi: Bir nesnenin "ne olduğunu" belirtmek için de kullanılabilir.

public class Address : IAddress {
    public String City { get; set; }
    public String Country { get; set; }
    public String Code { get; set; }
}

public class HomeAddress : Address { }
public class WorkAddress : Address { }


public class Mouse {
    public IBattery Battery { get; set; }
}

public interface IBattery { }

public class Duracell : IBattery { }
public class Kodak : IBattery { }
public class PowerB : IBattery { }