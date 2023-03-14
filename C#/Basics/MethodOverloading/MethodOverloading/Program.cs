// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Geometry geometry = new();
Double areaOfCircle = geometry.GetArea(5, "Daire");
Double areaOfTriangle = geometry.GetArea(3, 10, "Üçgen");

Double optionalSquare = geometry.AlternativeGetArea(5);
Double optionalCircle = geometry.AlternativeGetArea(3, geometry: "Daire");
Double optionalTriangle = geometry.AlternativeGetArea(3, unit2: 20, geometry: "üçgen");
Double optionalTriangle2 = geometry.AlternativeGetArea(unit1: 3,
                                                   geometry: "Üçgen",
                                                   unit2: 15);
public class Geometry {
    // Kare, Daire, Üçgen, Dikdörtgen
    /// <summary>
    /// Kare ya da Daire şekillerinin alanlarını hesaplamak için kullanılır.
    /// </summary>
    /// <param name="unit1">Karenin birim uzunluğu veya dairenin yarıçapı</param>
    /// <param name="geometry">Kare veya Daire kelimelerinden biri</param>
    /// <returns></returns>
    public Double GetArea(Double unit1, String geometry) {
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
    public Double GetArea(Double unit1, Double unit2, String geometry) {
        Double result = 0;

        switch(geometry) {
            case "Üçgen":
                result = unit1 * unit2 / 2;
                break;
            case "Dikdörtgen":
                result = unit1 * unit2;
                break;
            default:
                break;
        }

        return result;
    }

    /// <summary>
    /// Optional parametrelere sahip Alan hesaplama metodu
    /// </summary>
    /// <param name="unit1">[ZORUNLU] birim uzunluğu girin</param>
    /// <param name="unit2">[OPSİYONEL] birim 2</param>
    /// <param name="geometry">[OPSİYONEL] Geometrik şekil</param>
    /// <returns></returns>
    public Double AlternativeGetArea(Double unit1, Double unit2 = 1, String geometry = "Kare") {
        Double result = 0.0;
        switch(geometry) {
            case "Kare":
                result = unit1 * unit1;
                break;
            case "Daire":
                result = Math.Pow(unit1, 2) * Math.PI;
                break;
            case "Üçgen":
                result = unit1 * unit2 / 2;
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