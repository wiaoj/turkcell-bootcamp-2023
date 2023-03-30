using ExtensionMethods;

Int32 number = 8;

Console.WriteLine(number.GetSquare());

String name = "Order Details";
Console.WriteLine(name.MergeWords());

String password = "abc!123";
Console.WriteLine(password.GetPasswordStrength());

Console.WriteLine(new Random().NextWord(6));
