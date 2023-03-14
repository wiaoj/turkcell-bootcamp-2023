// See https://aka.ms/new-console-template for more information
using ClassVsObject;

/*
    Stack     -      Heap
 int x = 5;
 x <= 5
 yap();

 p1 = A00000FFFF     Name
                     IsInStock

 p2 = p1 => A00000FFFF bu kısım kopyalanır
 new kelimesi otomatik olarak alan belirtip bunu p1'e verir
 yani new ile heap üzerinde yeni alan açılır

 stack ile iletişime geçip heap alanındaki değeri elde ediyoruz
 */

Product p1 = new();
p1.Name = "Laptop";

Product p2 = p1;
p2.Name = "Telefon";

Console.WriteLine(p1.Name);
