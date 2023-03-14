// See https://aka.ms/new-console-template for more information
using Encapsulation;

Console.WriteLine("Hello, World!");

Car car = new();
car.Run();
car.SpeedUp();
car.Stop();


Product product = new();

Console.Write("Ürün fiyatını girin: ");
Int32 price = Int32.Parse(Console.ReadLine());

//if(price > 0) {
//    product.Price = price;
//} else {
//    Console.WriteLine("Fiyat 1 den düşük olamaz!");
//} // bunun yerine

product.SetPrice(price); // bu şekilde kullanılır.
Console.WriteLine(product.GetPrice());

product.Name = "Telefon";

product.Stock = 1000;
