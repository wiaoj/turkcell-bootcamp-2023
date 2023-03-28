namespace LinqIntro;
public class Product {
    public Int32 Id { get; set; }
    public String Name { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
    public Int16 Stock { get; set; }
}

public class ProductService {
    private List<Product> products;
    public ProductService() {
        this.products = new() {
            new() {
                Id = 1,
                Name = "Bisiklet",
                Description = "Spor amaçlı",
                Price = 3000M,
                Stock = 150
            },
            new() {
                Id = 2,
                Name = "Dambıl Set",
                Description = "Spor amaçlı",
                Price = 3000M,
                Stock = 150
            },
            new() {
                Id = 3,
                Name = "Şort",
                Description = "Giyim amaçlı",
                Price = 150M,
                Stock = 150
            },
            new() {
                Id = 4,
                Name = "Tişört",
                Description = "Spor amaçlı",
                Price = 200M,
                Stock = 150
            },
            new() {
                Id = 5,
                Name = "Çadır",
                Description = "Kampçılık",
                Price = 3000M,
                Stock = 150
            },
            new() {
                Id = 6,
                Name = "Eldiven",
                Description = "Spor amaçlı",
                Price = 50M,
                Stock = 150
            },
        };
    }

    public List<Product> GetProducts() => this.products;
}