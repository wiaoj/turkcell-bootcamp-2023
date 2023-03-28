namespace UsingDelegates;
public class FilterHelper {
    //public delegate Boolean criteria(Int32 item);
    //public List<Int32> Filter(List<Int32> numbers, criteria filterFunction) {
    //    List<Int32> filtered = new();

    //    foreach(Int32 number in numbers)
    //        if(filterFunction(number))
    //            filtered.Add(number);

    //    return filtered;
    //}

    // Değer döndürenler Func olur => yeni versiyonlardaki delegate
    // Değer döndürmeyenler Action olur list.ForEach() yapısı içine action bekler mesela;
    public List<Int32> Filter(List<Int32> numbers, Func<Int32, Boolean> filterFunction) {
        List<Int32> filtered = new();

        foreach(Int32 number in numbers) {
            if(filterFunction(number))
                filtered.Add(number);
        }

        return filtered;
    }
}