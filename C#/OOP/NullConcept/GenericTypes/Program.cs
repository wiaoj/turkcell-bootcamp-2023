using System.Collections;

ArrayList words = new() {
    //words.Add("String");
    1
};
//words.Add(false);

//Int32 number = (Int32)words[0];
String? number = words[0] as String;

Console.WriteLine(number); // Boxing ve unboxing sadece mecbur olunca kullanılmalı

GenericPoint<Decimal> genericPoint = new();
//GenericPoint<Random> genericPoint2 = new(); Type belirlendiği için kısıtlama getirilebiliyor
String word = "Selam";
//Console.WriteLine(GetTypeOfGeneric(word, word));
//Console.WriteLine(GetTypeOfGeneric<String, String>(word, word));

String a = "Merhaba";
String b = "Selam";

Console.WriteLine($"A: {a}, B: {b}");

Swap<String>(ref a, ref b);

Console.WriteLine($"A: {a}, B: {b}");
(a, b) = (b, a);
Console.WriteLine($"A: {a}, B: {b}");

List<String> items = new();

items.Add(word);
// Generic Interface'de varyant kavramının araştırılması.


//Type GetTypeOfGeneric<Type, W>(Type type) where Type : class, new() {
//    Type t = new();
//    return t;
//}

String GetTypeOfGeneric<Type, W>(Type type, W type2) where Type : class, new()
    where W : class, new() {
    Type t = new();
    //if(type is String) {
    //    return "Bu bir stringdir.";
    //}
    return type.GetType().Name;
}


void Swap<Type>(ref Type t1, ref Type t2) {
    Type temp = t1;

    t1 = t2;
    t2 = temp;
}

public class Point {
    public Int32 X { get; set; }
    public Int32 Y { get; set; }

    public void Reset() {
        this.X = 0;
        this.Y = 0;
    }
}

public class DoublePoint {
    public Double X { get; set; }
    public Double Y { get; set; }

    public void Reset() {
        this.X = 0.0D;
        this.Y = 0.0D;
    }
}

public class ObjectPoint {
    public Object X { get; set; }
    public Object Y { get; set; }
}

public class GenericPoint<Type> where Type : struct {
    public Type X { get; set; }
    public Type Y { get; set; }

    public GenericPoint() : this(default, default) {

    }

    public GenericPoint(Type x, Type y) {
        this.X = x;
        this.Y = y;
    }

    public void Reset() {
        this.X = default;
        this.Y = default;
    }
}