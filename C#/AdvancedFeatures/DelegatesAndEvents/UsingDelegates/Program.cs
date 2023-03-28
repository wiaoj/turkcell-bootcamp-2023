// Delegate => bir metodu temsil eden c# işlevidir.
using UsingDelegates;

FilterHelper filterHelper = new();
List<Int32> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// .net 1.1
List<Int32> filtered1 = filterHelper.Filter(numbers, isEven);

// .net 2.0
List<Int32> filtered2 = filterHelper.Filter(numbers,
    delegate (Int32 number) { return number % 2 is 1; });

// .net 3.5
List<Int32> filtered3 = filterHelper.Filter(numbers, parameter => parameter > 5);
//List<Int32> filtered3 = filterHelper.Filter(numbers, (Int32 number) => number > 5);


//List<Int32> filtered3 = filterHelper.Filter(numbers, (Int32 number) => number % 2 is 1);



alternateShowNumbers(filtered1);
alternateShowNumbers(filtered2);
alternateShowNumbers(filtered3);

//List<Int32> filter(List<Int32> numbers) {
//    List<Int32> filtered = new();

//    foreach(Int32 number in numbers) {
//        if(isEven(number))
//            filtered.Add(number);
//    }

//    return filtered;
//}

void showNumbers(List<Int32> numbers) {
    foreach(Int32 number in numbers)
        Console.WriteLine(number);
}

void alternateShowNumbers(List<Int32> number) => numbers.ForEach(Console.Write);

Boolean isEven(Int32 number) => number % 2 is 0;
