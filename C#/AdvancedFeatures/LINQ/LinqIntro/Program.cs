// LINQ: Language INtegrated Query => Sorgulamak amacıyla dile entegre edilmiş sorgu
// Bir koleksiyon ile kolayca iş yapabilmektir.

using LinqIntro;
using System.Diagnostics;
ProductService service = new();
List<Product> products = service.GetProducts();

var anonymousType = new { Name = "Wiaoj", Age = 30 };

// syntax işlemi ram'e atma sırasıyla işlenir
// belleğe aktarma sırasından dolayı from product in products şeklinde yazılıyor
var nameAndPriceList = from product in products
                       where product.Price < 1000
                       select new {
                           Name = product.Name,
                           Price = product.Price,
                       };

nameAndPriceList.ToList().ForEach(x => Console.WriteLine($"{new String('.', 5)}{x.Name}\t{x.Price}"));

Stopwatch stopWatch = Stopwatch.StartNew();
var sameResultWithExtension = products.Where(product => product.Price < 1000)
                                    .Select(product => new {
                                        Name = product.Name,
                                        Price = product.Price
                                    }).ToList();
stopWatch.Stop();
Console.WriteLine($"Birinci sorgunun süresi: {stopWatch.ElapsedMilliseconds}");

Console.WriteLine("Extension 1");
sameResultWithExtension.ForEach(x => Console.WriteLine($"{new String('.', 5)}{x.Name}\t{x.Price}"));

stopWatch.Restart();
var same = products.ToList()
                   .Where(product => product.Price < 1000)
                   .Select(product => new {
                       Name = product.Name,
                       Price = product.Price
                   });

Console.WriteLine($"İkinci sorgunun süresi: {stopWatch.ElapsedMilliseconds}");

Console.WriteLine();
Console.WriteLine("Extension 2");
same.ToList().ForEach(x => Console.WriteLine($"{new String('.', 5)}{x.Name}\t{x.Price}"));

// iki sorgu aynı sonucu vermesine rağmen ikinci işlem daha fazla bellek kullanır.

String line = new('-', 10);
Console.WriteLine($"{line} FirstOrDefault {line}");

Product? product1 = products?.FirstOrDefault(x => x.Id == 6);
Console.WriteLine($"6 numaralı ürün: {product1?.Name}");

//Product? sportProduct = products?.SingleOrDefault(x => x.Description.Contains("Spor"));
// Birden fazla sporla alakalı açıklama olduğu için hata verecektir

List<Product>? ordered1 = products?.OrderBy(x => x.Price) // ASC sıralar
                                                          //.OrderByDescending() // DESC sıralar
                        .ThenByDescending(x => x.Stock) // Fiyatlar eşitse stoğa göre DESC olarak sıralar
                        .ToList();

Console.WriteLine();
Console.WriteLine($"{line} OrderBy Price ASC {line}");
ordered1?.ForEach(orderedProduct => Console.WriteLine($"{orderedProduct.Name} {orderedProduct.Price} {orderedProduct.Stock}"));

Decimal? averagePrice = products?.Average(product => product.Price);
Int32? totalItem = products?.Count(product => product.Description.Contains("Spor"));

Console.WriteLine($"Ortalama: {averagePrice:.##}, Toplam: {products?.Sum(x => x.Price)}");
Console.WriteLine($"İçinde spor geçenlerin sayısı: {totalItem}");


Product? mostExpensiveProduct = products.OrderByDescending(x => x.Price).FirstOrDefault();
mostExpensiveProduct = products?.FirstOrDefault(x => x.Price == products.Max(x => x.Price));
Console.WriteLine($"{mostExpensiveProduct?.Name} ₺{mostExpensiveProduct?.Price}");


// JOIN
/*
 *   Products
 *   Id         Name        CategoryId
 *   ---------------------------------
 *   1          A           1
 *   2          B           3
 *   
 *   Categories
 *   Id         Name
 *   ---------------
 *   1          X
 *   2          Y
 *   3          Z
 *   
 *   Belli bir kolon(değer) üzerinden kesişim kümesini alıyoruz
 *   
 *   Output
 *   1      A       X
 *   2      B       Z
 */

List<Category> categories = service.GetCategories();
var joinQuery = categories.Join(products, // bağlanılacak koleksiyon
                                category => category, // inner koleksiyondan nereyi eşleştireceksin
                                product => product.Category, // bağlanacağın yerde neyle eşleştireceksin
                                (category, product) => new { // birleştirme işlemi
                                    CategoryName = category.Name,
                                    ProductName = product.Name,
                                }).ToList();

Console.WriteLine($"{line} Join Query {line}");
joinQuery.ForEach(result => {
    Console.WriteLine($"{result?.ProductName} {result?.CategoryName}");
});

Console.WriteLine();
Console.WriteLine($"{line} Alternative Join Query {line}");
var joinQuery2 = products.Select(product => new {
    CategoryName = product.Category?.Name,
    ProductName = product.Name,
}).ToList();

joinQuery2.ForEach(result => {
    Console.WriteLine($"{result?.ProductName} {result?.CategoryName}");
});
// Group by -> koleksiyonu değere göre gruplar

var group = products.GroupBy(
                             product => product.Category?.Name, // neye göre gruplanacak
                             result => new { // kalan kısımdan ad ve fiyata göre koleksiyon al
                                 result.Name,
                                 result.Price,
                             },
                             (categoryName, products) => new { // birleştir
                                 Key = categoryName,
                                 Count = products.Count(),
                                 MinPrice = products.Min(x => x.Price),
                                 MaxPrice = products.Max(x => x.Price)
                             });

Console.WriteLine($"{line} Group By {line}");
foreach(var item in group) {
    Console.WriteLine($"Kategori: {item.Key}");
    Console.WriteLine($"Adet: {item.Count}");
    Console.WriteLine($"En ucuz ürün: {item.MinPrice}");
    Console.WriteLine($"En pahalı ürün: {item.MaxPrice}");
    Console.WriteLine($"{line}{line}{line}");
}