Random randomNumberGenerator = new();

Int32 minValue = Int32.MaxValue, maxValue = default;
Int64 sum = default;

while(true) {
    Console.Write("0 - 100.000 aralığında kaç tane rastgele sayı oluşturulsun: ");
    try {
        Int16 arrayCount = Convert.ToInt16(Console.ReadLine());

        Int32[] numbers = new Int32[arrayCount];

        for(Int32 index = default; index < numbers.Length; ++index) {
            numbers[index] = randomNumberGenerator.Next(100_000);
        }

        for(Int32 index = default; index < numbers.Length; ++index) {
            Int32 currentValue = numbers[index];
            sum += currentValue;

            FindMinimumAndMaximumNumber(currentValue);
        }

        ShowInConsole(numbers.Length, minValue, maxValue, sum);
    } catch(Exception exception) {
        switch(exception) { // veya birden fazla catch içinde de yakayabiliriz
            // iki durumda da aynı işlemi yapacağım için switch tercih ettim
            case FormatException:
            case OverflowException:
                Console.WriteLine($"{Int16.MinValue} - {Int16.MaxValue} aralığında bir sayı giriniz!");
                break;
            case OutOfMemoryException:
                Console.WriteLine("??");
                break;
            default:
                Console.WriteLine($"Bir şey oldu, biz de anlamadık. {exception.Message}");
                break;
        }
    }
}


void FindMinimumAndMaximumNumber(Int32 currentValue) {
    if(currentValue > maxValue) {
        maxValue = currentValue;
    } else if(currentValue < minValue) {
        minValue = currentValue;
    } /*else { //bu şekilde veya minValue = Int32.MaxValue; başlangıç olarak verilebilir
        if(currentValue < minValue) {
            minValue = currentValue;
            continue;
        }
        minValue = currentValue;
    }*/
}

static Int64 CalculateAverage(Int64 sum, Int32 divideCount) {
    return sum / divideCount;
}

static void ShowInConsole(Int32 numbersLength, Int32 minValue, Int32 maxValue, Int64 sum) {
    Console.WriteLine($"MaxValue: {maxValue}");
    Console.WriteLine($"MinValue: {minValue}");
    Console.WriteLine($"Sum: {sum}");
    Console.WriteLine($"Average: {CalculateAverage(sum, numbersLength)}");
}