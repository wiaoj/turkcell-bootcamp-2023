using homework3;

try {
    Product product1 = Product.Create("Ürün 1", 150);

        product1.Add(7000);
    
} catch(Exception exception) {
    Console.WriteLine(exception.Message);
}