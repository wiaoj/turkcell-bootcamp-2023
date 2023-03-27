/*
 * Liskov diyor ki:
 * Bir sınıf bir başkasına miras veriyorsa; bu sınıflar BİRBİRLERİNİN YERİNE KULLANILABİLİR olmalı.
 * Bir sınıf miras aldığı sınıfın özelliklerini AYNEN KULLANMAK ZORUNDADIR.
 * 
 * Miras alan yerde if & try - catch kullanılmaz
 */

using LiskovSubstution;

//Rectangle rectangle = new() { With = 5, Height = 4 };
//Console.WriteLine($"Rectangle: {rectangle.GetArea()}");

//Square square = new() { With = 10 };
//Console.WriteLine($"Square: {square.GetArea()}");


//var rectangle2 = GeometryLibrary.RectangleFactory();
//rectangle2.With = 10;
//rectangle2.Height = 5;
//Console.WriteLine($"Rectangle2: {rectangle2.GetArea()}");

IAreaCalcutable rectangle = GeometryLibrary.RectangleFactory(5, 4);
rectangle = GeometryLibrary.RectangleFactory(5);
Console.WriteLine($"Dörtgen alanı: {rectangle.GetArea()}");