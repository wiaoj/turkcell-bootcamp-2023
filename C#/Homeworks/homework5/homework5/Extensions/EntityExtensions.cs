using homework5.Entities.Base;

namespace homework5.Extensions;
public static class EntityExtensions {
    public static void PrintInConsole(this IEnumerable<Entity> entities) {
        if(entities.Count() is default(Int32)) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Herhangi bir veri bulunamadı");
            return;
        }
        Int32 counter = default;
        foreach(Entity entity in entities) {
            if(++counter % 2 is default(Int32))
                Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(entity.ToString());
            Console.ResetColor();
            Thread.Sleep(10);
        }
    }
}