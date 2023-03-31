using homework5.Entities.Base;

namespace homework5.Extensions;
public static class ConsoleMenuExtensions {
    private const Int32 CONSOLE_COUNTER_MAX_COUNT = 5;
    private const Int32 CONSOLE_COUNTER_NOTIFICATION = 2;

    private static String readConsoleLine(Menu.Menu menu, ConsoleColor color, Action? action, String? nullOrEmptyExceptionMessage) {
        WriteConsoleLine(menu, ConsoleColor.Red, $"Çıkmak için {CONSOLE_COUNTER_MAX_COUNT} kere enter basınız.".NextLine());
        Int32 counter = default;
        while(true) {
            action?.Invoke();
            Console.ForegroundColor = color;
            String value = Console.ReadLine() ?? String.Empty;

            if(String.IsNullOrEmpty(value) is false) {
                Console.ResetColor();
                return value;
            }

            if(++counter == CONSOLE_COUNTER_MAX_COUNT) {
                WriteConsoleLine(menu, ConsoleColor.Red, $"İşlemi {CONSOLE_COUNTER_MAX_COUNT} kere yapmadığınız için iptal ediliyor");
                Thread.Sleep(1000);
                break;
            } else if(counter > CONSOLE_COUNTER_NOTIFICATION) {
                WriteConsoleLine(menu, ConsoleColor.Red, $"İşlemi tamamlamak için kalan hakkınız: {CONSOLE_COUNTER_MAX_COUNT - counter}");
                continue;
            }

            WriteConsoleLine(menu, ConsoleColor.Red, nullOrEmptyExceptionMessage ?? String.Empty);
        }

        Console.ForegroundColor = ConsoleColor.Red;
        throw new Exception($"İşlemi {CONSOLE_COUNTER_MAX_COUNT} kere yapmadığınız için iptal edildi");
    }

    public static String ReadConsoleLine(this Menu.Menu menu, ConsoleColor color, String? nullOrEmptyExceptionMessage) {
        return readConsoleLine(menu, color, null, nullOrEmptyExceptionMessage);
    }

    public static String ReadConsoleLine(this Menu.Menu menu, ConsoleColor color, String title, String? nullOrEmptyExceptionMessage) {
        return readConsoleLine(menu, color, () => {
            WriteConsole(menu, title);
        }, nullOrEmptyExceptionMessage);
    }

    public static void WriteConsoleLine(this Menu.Menu menu, String? message) {
        WriteConsole(menu, message.NextLine());
    }

    public static void WriteConsole(this Menu.Menu menu, String? message) {
        Console.Write(message ?? String.Empty);
    }

    public static void WriteConsoleLine(this Menu.Menu menu, ConsoleColor color, String message) {
        WriteConsole(menu, color, message.NextLine());
    }

    public static void WriteConsole(this Menu.Menu menu, ConsoleColor color, String message) {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }

    public static void WriteConsoleLine(this Menu.Menu menu, ConsoleColor color, Entity entity) {
        WriteConsoleLine(menu, color, entity.ToString()!);
    }

    public static void WriteConsoleLine(this Menu.Menu menu, ConsoleColor color, Action action) {
        Console.ForegroundColor = color;
        action.Invoke();
        Console.ResetColor();
    }
}