namespace Encapsulation;
public class Car {
    private Int32 speed = default;
    private Boolean isCarWork = default;

    public void Run() {
        isCarWork = true;
    }

    public void SpeedUp() {
        if(isCarWork) {
            speed++;
        } else {
            Console.WriteLine("Araba çalışmıyor!");
        }
    }

    public void Stop() {
        if(isCarWork) {
            speed = 0;
        } else {
            Console.WriteLine("Araba çalışmıyor!");
        }
    }
}