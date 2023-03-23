using BuiltInInterface;
using System.Threading.Channels;

Product product1 = new() {
    Id = Guid.NewGuid(),
    Name = "Bisiklet",
    Stock = 150,
    Price = 3500.0M
};

Product product2 = new() {
    Id = Guid.NewGuid(),
    Name = "Tenis Raketi",
    Stock = 1250,
    Price = 300.0M
};

Product product3 = new() {
    Id = Guid.NewGuid(),
    Name = "Koşu Bandı",
    Stock = 120,
    Price = 15300.0M
};

ProductCollection productCollection = new();

productCollection.Add(product1);
productCollection.Add(product2);
productCollection.Add(product3);

productCollection.SortProducts();

productCollection.GetAll().ForEach(product => Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Price}\t{product.Stock}"));

String word = "kelimelik";

foreach(Char item in word) {

}
