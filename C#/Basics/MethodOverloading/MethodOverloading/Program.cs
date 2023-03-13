// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Geometry geometry = new();
geometry.GetArea(5, "Daire");
geometry.GetArea(5, 5, "Üçgen");

public class Geometry {
    // Kare, Daire, Üçgen, Dikdörtgen
    /// <summary>
    /// Kare ya da Daire şekillerinin alanlarını hesaplamak için kullanılır.
    /// </summary>
    /// <param name="unit1">Karenin birim uzunluğu veya dairenin yarıçapı</param>
    /// <param name="geometry">Kare veya Daire kelimelerinden biri</param>
    /// <returns></returns>
    public double GetArea(Double unit1, String geometry) {
        Double result = 0;

        switch(geometry) {
            case "Kare":
                result = unit1 * unit1;
                break;
            case "Daire":
                result = Math.Pow(unit1, 2) * Math.PI;
                break;
            default:
                break;
        }

        return result;
    }

    /// <summary>
    /// Üçgen ya da Dikdörtgen şekillerinin alanlarını hesaplamak için kullanılır.
    /// </summary>
    /// <param name="unit1">Dikdörtgenin eni veya üçgenin tabanı</param>
    /// <param name="unit2">Boy ya da hipotenüs</param>
    /// <param name="geometry">Üçgen veya Dikdörtgen kelimeleri</param>
    /// <returns></returns>
    public double GetArea(Double unit1, Double unit2, String geometry) {
        Double result = 0;

        switch(geometry) {
            case "Üçgen":
                result = (unit1 * unit2) / 2;
                break;
            case "Dikdörtgen":
                result = unit1 * unit2;
                break;
            default:
                break;
        }

        return result;
    }
}