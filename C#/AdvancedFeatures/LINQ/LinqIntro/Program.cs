// LINQ: Language INtegrated Query => Sorgulamak amacıyla dile entegre edilmiş sorgu
// Bir koleksiyon ile kolayca iş yapabilmektir.

using LinqIntro;

var products = new ProductService().GetProducts();

var anonymousType = new { Name = "Wiaoj", Age = 30 };

// syntax işlemi ram'e atma sırasıyla işlenir
// belleğe aktarma sırasından dolayı from product in products şeklinde yazılıyor
var nameAndPriceList = from product in products
                       where product.Price < 1000
                       select new {
                           Name = product.Name,
                           Price = product.Price,
                       };

nameAndPriceList.ToList().ForEach(x => Console.WriteLine($"{new String('.',5)}{x.Name}\t{x.Price}"));
